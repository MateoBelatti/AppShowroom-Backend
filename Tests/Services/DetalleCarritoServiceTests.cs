using AutoMapper;
using biblioteca.clases;
using biblioteca.dtos.detalleCarrito;
using biblioteca.mappers;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Repository;
using Services;
using Services.Services.carrito;
using Services.Services.detalleCarrito;
using Xunit;

namespace AppShowroom.Tests.Services;

public class DetalleCarritoServiceTests
{
    [Fact]
    public async Task Create_NoModificaElDtoEntranteYUsaElCarritoDelUsuario()
    {
        var currentUser = new Mock<ICurrentUser>();
        currentUser.SetupGet(u => u.UsuarioId).Returns(1);

        var carritos = new Mock<ICarritoRepository>();
        carritos.Setup(r => r.GetByUsuarioId(1)).ReturnsAsync(new Carrito { Id = 10, UsuarioID = 1 });

        var detalles = new Mock<IDetalleCarritoRepository>();
        DetalleCarrito? entityCreada = null;
        detalles.Setup(r => r.Create(It.IsAny<DetalleCarrito>()))
            .Callback<DetalleCarrito>(d => entityCreada = d)
            .ReturnsAsync((DetalleCarrito d) =>
            {
                d.Id = 11;
                return d;
            });
        detalles.Setup(r => r.GetById(11)).ReturnsAsync(new DetalleCarrito
        {
            Id = 11,
            CarritoID = 10,
            ProductoID = 5,
            Cantidad = 2,
            Producto = new Producto { Id = 5, Nombre = "Vela", Imagen = "vela.png", Precio = 12.5m }
        });

        var mapper = new MapperConfiguration(cfg => cfg.AddProfile<DetalleCarritoProfile>(), NullLoggerFactory.Instance)
            .CreateMapper();
        var carritoService = new Mock<ICarritoService>();
        var service = new DetalleCarritoService(
            carritoService.Object, carritos.Object, detalles.Object, mapper, currentUser.Object);

        var dtoEntrante = new DetalleCarritoCreateDto
        {
            UsuarioId = 99,
            CarritoID = 0,
            ProductoId = 5,
            Cantidad = 2
        };

        var resultado = await service.create(dtoEntrante);

        Assert.Equal(99, dtoEntrante.UsuarioId);
        Assert.Equal(0, dtoEntrante.CarritoID);
        Assert.NotNull(entityCreada);
        Assert.Equal(10, entityCreada!.CarritoID);
        Assert.Equal(5, entityCreada.ProductoID);
        Assert.Equal("Vela", resultado.NombreProducto);
        Assert.Equal(25m, resultado.Subtotal);
        carritoService.Verify(s => s.create(), Times.Never);
    }
}
