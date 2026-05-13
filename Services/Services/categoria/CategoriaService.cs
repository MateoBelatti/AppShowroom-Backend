using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using biblioteca.clases;
using biblioteca.dtos.categoria;
using Repository;

namespace Services.Services.categoria
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;
        public CategoriaService(
            ICategoriaRepository categoriaRepository,
            IMapper mapper
            )
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }
        public async Task<CategoriaDto> create(CategoriaCreateDto data)
        {
            var producto = _mapper.Map<Categoria>(data);
            var result = await _categoriaRepository.Create(producto);
            return _mapper.Map<CategoriaDto>(result);
        }

        public async Task<bool> delete(int idCategoria)
        {
            var result = await _categoriaRepository.GetById(idCategoria);
            if (result is null)
            {
                return false;
            }
            await _categoriaRepository.Delete(idCategoria);
            return true;
        }

        public async Task<IEnumerable<CategoriaDto>> findAll()
        {
            var categorias = await _categoriaRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoriaDto>>(categorias);
        }

        public async Task<CategoriaDto> findById(int id)
        {
            var result = await _categoriaRepository.GetById(id);
            return _mapper.Map<CategoriaDto>(result);
        }

        public async Task<CategoriaDto> update(int idCat, CategoriaUpdateDto data)
        {
            var result = await _categoriaRepository.GetById(idCat);
            if (result is null)
            {
                throw new Exception("No se encontro categoria para updatear");
            }
            _mapper.Map(data, result);
            var categoria = await _categoriaRepository.Update(result);
            return _mapper.Map<CategoriaDto>(categoria);
        }
    }
}
