using biblioteca.clases;
using biblioteca.dtos.producto;
using biblioteca.mappers;
using System;
using System.Collections.Generic;
using System.Text;
using Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using System.Reflection.Metadata.Ecma335;
using Api.Errors;

namespace Services.Services.producto
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public ProductoService(
            IProductoRepository productoRepository,
            ICategoriaRepository categoriaRepository,
            IMapper mapper
            )
        {
            _productoRepository = productoRepository;
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<ProductoDto> create(ProductoCreateDto producto)
        {
            var nuevoProducto = _mapper.Map<Producto>(producto);
            if (producto.CategoriasIds != null)
            {
                var categorias = await _categoriaRepository.GetAllByIds(producto.CategoriasIds);
                if (categorias.Count() != producto.CategoriasIds.Count())
                {
                    throw new AppException("Una o mas categorias no existen", 400, "ProductoService.create");
                }
                nuevoProducto.Categorias = categorias.ToList();
            }
            var productoCreado = await _productoRepository.Create(nuevoProducto);
            return _mapper.Map<ProductoDto>(productoCreado);
        }

        public async Task<bool> delete(int idProducto)
        {
            var productoExistente = await _productoRepository.GetById(idProducto);
            if (productoExistente is null)
            {
                return false;
            }
            await _productoRepository.Delete(idProducto);
            return true;
        }

        public async Task<IEnumerable<ProductoDto>> findAll()
        {
            var productos = await _productoRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductoDto>>(productos);
        }

        public async Task<IEnumerable<ProductoDto>> findAllActivos()
        {
            var productos = await _productoRepository.GetAllActivos();
            return _mapper.Map<IEnumerable<ProductoDto>>(productos);
        }

        public async Task<IEnumerable<ProductoDto>> findByCategoria(int idCategoria)
        {
            var categoria = await _categoriaRepository.GetById(idCategoria);

            if (categoria is null)
            {
                throw new AppException("No se encontraron resultados para la categoria especificada", 404, "ProductoService.findByCategoria");
            }
            var productos = await _productoRepository.GetAllActivos();

            var filtrados = productos.Where(p => p.Categorias.Any(c => c.Id == idCategoria));
            return _mapper.Map<IEnumerable<ProductoDto>>(filtrados);
        }

        public async Task<ProductoDto?> findById(int id)
        {
            var producto = await _productoRepository.GetById(id);
            if (producto is null) return null;
            return _mapper.Map<ProductoDto>(producto);
        }

        public async Task<ProductoDto> update(int idProducto, ProductoUpdateDto producto)
        {
            var productoExistente = await _productoRepository.GetById(idProducto);
            if (productoExistente is null)
            {
                throw new AppException("No se encontró el producto especificado", 404, "ProductoService.update");
            }
            _mapper.Map(producto, productoExistente);
            var productoActualizado = await _productoRepository.Update(productoExistente);
            return _mapper.Map<ProductoDto>(productoActualizado);

        }
    } 
}
