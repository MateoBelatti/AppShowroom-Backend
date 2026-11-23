using biblioteca.Errors;
using AutoMapper;
using biblioteca.clases;
using biblioteca.dtos.detalleCarrito;
using Repository;
using Services.Services.carrito;

namespace Services.Services.detalleCarrito
{
    public class DetalleCarritoService : IDetalleCarritoService
    {
        private readonly IDetalleCarritoRepository _detalleCarritoRepository;
        private readonly ICarritoService _carritoService;
        private readonly ICarritoRepository _carritoRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _currentUser;

        public DetalleCarritoService(
            ICarritoService carritoService,
            ICarritoRepository carritoRepository,
            IDetalleCarritoRepository detalleCarritoRepository,
            IMapper mapper,
            ICurrentUser currentUser
            )
        {
            _carritoService = carritoService;
            _carritoRepository = carritoRepository;
            _detalleCarritoRepository = detalleCarritoRepository;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        private void ValidarPropietario(Carrito carrito, string origen)
        {
            if (carrito.UsuarioID == _currentUser.UsuarioId) return;

            throw new AppException("No tenés permiso para acceder a este carrito.", 403, origen);
        }

        private async Task ValidarCarrito(int idCarrito, string origen)
        {
            var carrito = await _carritoRepository.GetById(idCarrito);
            if (carrito is null)
            {
                throw new AppException("No se encontró el carrito especificado.", 404, origen);
            }

            ValidarPropietario(carrito, origen);
        }

        private async Task<int> ResolverCarritoId(int carritoIdSolicitado)
        {
            if (carritoIdSolicitado > 0)
            {
                var carritoSolicitado = await _carritoRepository.GetById(carritoIdSolicitado);
                if (carritoSolicitado is not null)
                {
                    ValidarPropietario(carritoSolicitado, "DetalleCarritoService.create");
                    return carritoSolicitado.Id;
                }
            }

            var carritoDelUsuario = await _carritoRepository.GetByUsuarioId(_currentUser.UsuarioId);
            if (carritoDelUsuario is not null)
            {
                return carritoDelUsuario.Id;
            }

            var carritoNuevo = await _carritoService.create();
            return carritoNuevo.Id;
        }

        public async Task<DetalleCarritoDto> create(DetalleCarritoCreateDto detalleCarrito)
        {
            var carritoId = await ResolverCarritoId(detalleCarrito.CarritoID);

            var detalleCrear = new DetalleCarrito
            {
                CarritoID = carritoId,
                ProductoID = detalleCarrito.ProductoId,
                Cantidad = detalleCarrito.Cantidad
            };

            var detalleCreado = await _detalleCarritoRepository.Create(detalleCrear);
            var detalleConProducto = await _detalleCarritoRepository.GetById(detalleCreado.Id);
            return _mapper.Map<DetalleCarritoDto>(detalleConProducto ?? detalleCreado);
        }

        public async Task<bool> delete(int idDetalleCarrito)
        {
            var detalleExistente = await _detalleCarritoRepository.GetById(idDetalleCarrito);
            if (detalleExistente is null)
            {
                return false;
            }

            await ValidarCarrito(detalleExistente.CarritoID, "DetalleCarritoService.delete");
            await _detalleCarritoRepository.Delete(idDetalleCarrito);
            return true;
        }

        public async Task<IEnumerable<DetalleCarritoDto>> findAllByIdCarrito(int idCarrito)
        {
            await ValidarCarrito(idCarrito, "DetalleCarritoService.findAllByIdCarrito");

            var detalles = await _detalleCarritoRepository.FindByCarritoID(idCarrito);
            return _mapper.Map<IEnumerable<DetalleCarritoDto>>(detalles);
        }

        public async Task<DetalleCarritoDto> Update(DetalleCarritoUpdateDto detalleCarrito)
        {
            var detalleExistente = await _detalleCarritoRepository.GetById(detalleCarrito.Id);
            if (detalleExistente is null)
            {
                throw new AppException("No se encontro un DetalleCarrito para actualizar", 404, "DetalleCarritoService.Update");
            }

            await ValidarCarrito(detalleExistente.CarritoID, "DetalleCarritoService.Update");

            _mapper.Map(detalleCarrito, detalleExistente);
            var detalleActualizado = await _detalleCarritoRepository.Update(detalleExistente);
            return _mapper.Map<DetalleCarritoDto>(detalleActualizado);
        }
    }
}
