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
using biblioteca.Errors;

namespace Services.Services.carrito
{
    public class CarritoService : ICarritoService
    {
        private readonly ICarritoRepository _carritoRepository;
        private readonly IDetalleCarritoRepository _detalleCarritoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _currentUser;

        public CarritoService(
            ICarritoRepository carritoRepository,
            IDetalleCarritoRepository detalleCarritoRepository,
            IUsuarioRepository usuarioRepository,
            IMapper mapper,
            ICurrentUser currentUser)
        {
            _carritoRepository = carritoRepository;
            _detalleCarritoRepository = detalleCarritoRepository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        private void ValidarPropietario(Carrito carrito, string origen)
        {
            if (carrito.UsuarioID == _currentUser.UsuarioId) return;

            throw new AppException("No tenés permiso para acceder a este carrito.", 403, origen);
        }

        public async Task<CarritoDto> create()
        {
            var usuario = await _usuarioRepository.FindById(_currentUser.UsuarioId);
            if (usuario == null)
            {
                throw new AppException("El usuario especificado no existe.", 404, "CarritoService.create");
            }

            var ahora = DateTime.UtcNow;
            var nuevoCarrito = new Carrito
            {
                UsuarioID = _currentUser.UsuarioId,
                FechaCreacion = ahora,
                UltimaVez = ahora
            };

            var carritoCreado = await _carritoRepository.Create(nuevoCarrito);
            return _mapper.Map<CarritoDto>(carritoCreado);
        }

        public async Task<bool> delete(int idCarrito)
        {
            var carritoExistente = await _carritoRepository.GetById(idCarrito);
            if (carritoExistente == null)
            {
                return false;
            }

            ValidarPropietario(carritoExistente, "CarritoService.delete");

            await _detalleCarritoRepository.DeleteAllByCarritoId(idCarrito);
            await _carritoRepository.Delete(idCarrito);
            return true;
        }

        public async Task<CarritoDto?> findById(int id)
        {
            var carrito = await _carritoRepository.GetById(id);
            if (carrito == null) return null;

            ValidarPropietario(carrito, "CarritoService.findById");

            var carritoDto = _mapper.Map<CarritoDto>(carrito);
            var detalles = await _detalleCarritoRepository.FindByCarritoID(id);
            if (detalles != null && detalles.Any())
            {
                carritoDto.Detalles = _mapper.Map<List<DetalleCarritoDto>>(detalles);
            }
            
            return carritoDto;
        }

        public async Task<CarritoDto?> findByIdUsuario(int idUsuario)
        {
            if (idUsuario != _currentUser.UsuarioId)
            {
                throw new AppException("No tenés permiso para acceder a este carrito.", 403, "CarritoService.findByIdUsuario");
            }

            var carrito = await _carritoRepository.GetByUsuarioId(_currentUser.UsuarioId);
            if (carrito == null) return null;
            var detalles = await _detalleCarritoRepository.FindByCarritoID(carrito.Id);
            if (detalles != null && detalles.Any())
            {
                carrito.Detalles = detalles.ToList();
            }
            return _mapper.Map<CarritoDto>(carrito);
        }

        public async Task<CarritoDto> update(int id)
        {
            var carritoExistente = await _carritoRepository.GetById(id);
            if (carritoExistente == null)
            {
                throw new AppException("No se encontró el carrito especificado.", 404, "CarritoService.update");
            }

            ValidarPropietario(carritoExistente, "CarritoService.update");

            carritoExistente.UltimaVez = DateTime.UtcNow;
            var result = await _carritoRepository.Update(carritoExistente);
            return _mapper.Map<CarritoDto>(result);
        }
    }
}
