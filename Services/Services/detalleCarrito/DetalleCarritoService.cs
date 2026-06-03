using Api.Errors;
using AutoMapper;
using biblioteca.clases;
using biblioteca.dtos.carrito;
using biblioteca.dtos.detalleCarrito;
using Repository;
using Services.Services.carrito;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Services.Services.detalleCarrito
{
    public class DetalleCarritoService : IDetalleCarritoService
    {
        private readonly IDetalleCarritoRepository _detalleCarritoRepository;
        private readonly ICarritoService _carritoService;
        private readonly IMapper _mapper;

        public DetalleCarritoService(
            ICarritoService carritoService,
            IDetalleCarritoRepository detalleCarritoRepository,
            IMapper mapper
            )
        {
            _carritoService = carritoService;
            _detalleCarritoRepository = detalleCarritoRepository;
            _mapper = mapper;
        }

        public async Task<DetalleCarritoDto> Create(DetalleCarritoCreateDto detalleCarrito)
        {
            if (!(await ValidarCarritoExistente(detalleCarrito.CarritoID)))
            {
                throw new AppException("El carrito no existe", 400, "DetalleCarrito.Create");
            }
            var detalleCrear = _mapper.Map<DetalleCarrito>(detalleCarrito);
            var detalleCreado = await _detalleCarritoRepository.Create(detalleCrear);
            return _mapper.Map<DetalleCarritoDto>(detalleCreado);
        }

        public async Task<bool> Delete(int idDetalleCarrito)
        {
            var detalleExistente = await _detalleCarritoRepository.GetById(idDetalleCarrito);
            if (detalleExistente is null)
            {
                return false;
            }
            await _detalleCarritoRepository.Delete(idDetalleCarrito);
            return true;
        }

        public async Task<IEnumerable<DetalleCarritoDto>> GetByCarritoId(int idCarrito)
        {
            var detalles = await _detalleCarritoRepository.GetByCarritoId(idCarrito);
            return _mapper.Map<IEnumerable<DetalleCarritoDto>>(detalles);
        }

        public async Task<DetalleCarritoDto> Update(DetalleCarritoUpdateDto detalleCarrito)
        {
            var detalleExistente = await _detalleCarritoRepository.GetById(detalleCarrito.Id);
            if (detalleExistente is null)
            {
                throw new AppException("No se encontro un DetalleCarrito para actualizar", 404, "DetalleCarritoService.Update");
            }
            _mapper.Map(detalleCarrito, detalleExistente);
            var detalleActualizado = await _detalleCarritoRepository.Update(detalleExistente);
            Console.WriteLine(detalleActualizado);
            return _mapper.Map<DetalleCarritoDto>(detalleActualizado);
        }

        private async Task<bool> ValidarCarritoExistente(int idCarrito)
        {
            var carrito = await _carritoService.GetById(idCarrito);
            if (carrito is null) return false;
            return true;
        }
    }
}
