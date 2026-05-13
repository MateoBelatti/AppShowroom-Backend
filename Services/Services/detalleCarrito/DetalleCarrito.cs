using AutoMapper;
using biblioteca.clases;
using biblioteca.dtos.detalleCarrito;
using Repository;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Services.Services.detalleCarrito
{
    public class DetalleCarritoService : IDetalleCarritoService
    {
        private readonly IDetalleCarritoRepository _detalleCarritoRepository;
        private readonly IMapper _mapper;

        public DetalleCarritoService(
            IDetalleCarritoRepository detalleCarritoRepository,
            IMapper mapper
            )
        {
            _detalleCarritoRepository = detalleCarritoRepository;
            _mapper = mapper;
        }

        public async Task<DetalleCarritoDto> create(DetalleCarritoCreateDto detalleCarrito)
        {
            var detalleCrear = _mapper.Map<DetalleCarrito>(detalleCarrito);
            var detalleCreado = await _detalleCarritoRepository.Create(detalleCrear);
            return _mapper.Map<DetalleCarritoDto>(detalleCreado);
        }

        public async Task<bool> delete(int idDetalleCarrito)
        {
            var detalleExistente = await _detalleCarritoRepository.GetById(idDetalleCarrito);
            if (detalleExistente is null)
            {
                return false;
            }
            await _detalleCarritoRepository.Delete(idDetalleCarrito);
            return true;
        }

        public async Task<IEnumerable<DetalleCarritoDto>> findAllByIdCarrito(int idCarrito)
        {
            var detalles = await _detalleCarritoRepository.FindByCarritoID(idCarrito);
            return _mapper.Map<IEnumerable<DetalleCarritoDto>>(detalles);
        }

        public async Task<DetalleCarritoDto> Update(int idDetalleCarrito, DetalleCarritoUpdateDto detalleCarrito)
        {
            var detalleExistente = await _detalleCarritoRepository.GetById(idDetalleCarrito);
            if (detalleExistente is null)
            {
                throw new Exception("No se encontro un DetalleCarrito para actualizar");
            }
            _mapper.Map(detalleCarrito, detalleExistente);
            var detalleActualizado = await _detalleCarritoRepository.Update(detalleExistente);
            return _mapper.Map<DetalleCarritoDto>(detalleActualizado);
        }
    }
}
