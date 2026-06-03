using biblioteca.clases;
using biblioteca.dtos.carrito;
using biblioteca.dtos.detalleCarrito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository;
using AutoMapper;
using Services.Services.detalleCarrito;
using Api.Errors;

namespace Services.Services.carrito
{
    public class CarritoService : ICarritoService
    {
        private readonly ICarritoRepository _carritoRepository;
        private readonly IDetalleCarritoRepository _detalleCarritoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public CarritoService(
            ICarritoRepository carritoRepository,
            IDetalleCarritoRepository detalleCarritoRepository,
            IUsuarioRepository usuarioRepository,
            IMapper mapper)
        {
            _carritoRepository = carritoRepository;
            _detalleCarritoRepository = detalleCarritoRepository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }   

        public async Task<CarritoDto> Create(CarritoCreateDto carrito)
        {
            var usuario = await _usuarioRepository.GetById(carrito.UsuarioId);
            if (usuario == null)
            {
                throw new AppException("El usuario especificado no existe.", 404, "CarritoService.Create");
            }

            var nuevoCarrito = _mapper.Map<Carrito>(carrito);

            var carritoCreado = await _carritoRepository.Create(nuevoCarrito);
            return _mapper.Map<CarritoDto>(carritoCreado);
        }

        public async Task<bool> Delete(int idCarrito)
        {
            var carritoExistente = await _carritoRepository.GetById(idCarrito);
            if (carritoExistente == null)
            {
                return false;
            }

            await _detalleCarritoRepository.DeleteAllByCarritoId(idCarrito);
            await _carritoRepository.Delete(idCarrito);
            return true;
        }

        public async Task<CarritoDto> GetById(int id)
        {
            var carrito = await _carritoRepository.GetById(id);
            if (carrito == null) return null;

            var carritoDto = _mapper.Map<CarritoDto>(carrito);
            var detalles = await _detalleCarritoRepository.GetByCarritoId(id);
            if (detalles != null && detalles.Any())
            {
                carritoDto.Detalles = _mapper.Map<List<DetalleCarritoDto>>(detalles);
            }
            
            return carritoDto;
        }

        public async Task<CarritoDto> GetByUsuarioId(int idUsuario)
        {
            var carrito = await _carritoRepository.GetByUsuarioId(idUsuario);
            if (carrito == null) return null;
            var detalles = await _detalleCarritoRepository.GetByCarritoId(carrito.Id);
            if (detalles != null && detalles.Any())
            {
                carrito.Detalles = detalles.ToList();
            }
            return _mapper.Map<CarritoDto>(carrito);
        }

        public async Task<CarritoDto> Update(int id, CarritoUpdateDto carritoDto)
        {
            var carritoExistente = await _carritoRepository.GetById(id);
            if (carritoExistente == null)
            {
                throw new AppException("No se encontrÃ³ el carrito especificado.", 404, "CarritoService.Update");
            }

            carritoExistente.UltimaVez = DateTime.Now;
            _mapper.Map(carritoDto, carritoExistente);
            var result = await _carritoRepository.Update(carritoExistente);
            return _mapper.Map<CarritoDto>(result);
        }
    }
}
