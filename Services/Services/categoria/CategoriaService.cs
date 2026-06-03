using System;
using System.Collections.Generic;
using System.Text;
using Api.Errors;
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
        public async Task<CategoriaDto> Create(CategoriaCreateDto data)
        {
            var producto = _mapper.Map<Categoria>(data);
            var result = await _categoriaRepository.Create(producto);
            return _mapper.Map<CategoriaDto>(result);
        }

        public async Task<bool> Delete(int idCategoria)
        {
            var result = await _categoriaRepository.GetById(idCategoria);
            if (result is null)
            {
                return false;
            }
            await _categoriaRepository.Delete(idCategoria);
            return true;
        }

        public async Task<IEnumerable<CategoriaDto>> GetAll()
        {
            var categorias = await _categoriaRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoriaDto>>(categorias);
        }

        public async Task<CategoriaDto> GetById(int id)
        {
            var result = await _categoriaRepository.GetById(id);
            return _mapper.Map<CategoriaDto>(result);
        }

        public async Task<CategoriaDto> Update(int id, CategoriaUpdateDto data)
        {
            var result = await _categoriaRepository.GetById(id);
            if (result is null)
            {
                throw new AppException("No se encontro categoria para updatear", 404, "CategoriaService.Update");
            }
            _mapper.Map(data, result);
            var categoria = await _categoriaRepository.Update(result);
            return _mapper.Map<CategoriaDto>(categoria);
        }
    }
}
