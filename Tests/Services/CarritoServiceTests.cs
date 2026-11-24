using AutoMapper;
using biblioteca.clases;
using biblioteca.Errors;
using biblioteca.mappers;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Repository;
using Services;
using Services.Services.carrito;
using Xunit;

namespace AppShowroom.Tests.Services;

public class CarritoServiceTests
{
    private static CarritoService CrearService(
        Mock<ICarritoRepository>? carritos = null,
        Mock<IDetalleCarritoRepository>? detalles = null,
        Mock<IUsuarioRepository>? usuarios = null,
        int usuarioId = 1)
    {
        carritos ??= new Mock<ICarritoRepository>();
        detalles ??= new Mock<IDetalleCarritoRepository>();
        usuarios ??= new Mock<IUsuarioRepository>();

        var currentUser = new Mock<ICurrentUser>();
        currentUser.SetupGet(u => u.UsuarioId).Returns(usuarioId);

        var mapper = new MapperConfiguration(cfg => cfg.AddProfile<CarritoProfile>(), NullLoggerFactory.Instance)
            .CreateMapper();

        return new CarritoService(carritos.Object, detalles.Object, usuarios.Object, mapper, currentUser.Object);
    }

    [Fact]
    public async Task FindById_CuandoElCarritoEsDeOtroUsuario_Lanza403()
    {
        var carritos = new Mock<ICarritoRepository>();
        carritos.Setup(r => r.GetById(10)).ReturnsAsync(new Carrito { Id = 10, UsuarioID = 2 });
        var service = CrearService(carritos);

        var ex = await Assert.ThrowsAsync<AppException>(() => service.findById(10));

        Assert.Equal(403, ex.StatusCode);
    }

    [Fact]
    public async Task FindByIdUsuario_CuandoPideOtroUsuario_Lanza403()
    {
        var service = CrearService();

        var ex = await Assert.ThrowsAsync<AppException>(() => service.findByIdUsuario(2));

        Assert.Equal(403, ex.StatusCode);
    }

    [Fact]
    public async Task Create_UsaElUsuarioAutenticadoYFechasUtc()
    {
        var usuarios = new Mock<IUsuarioRepository>();
        usuarios.Setup(r => r.FindById(1)).ReturnsAsync(new Usuario());

        var carritos = new Mock<ICarritoRepository>();
        Carrito? creado = null;
        carritos.Setup(r => r.Create(It.IsAny<Carrito>()))
            .Callback<Carrito>(c => creado = c)
            .ReturnsAsync((Carrito c) =>
            {
                c.Id = 20;
                return c;
            });

        var service = CrearService(carritos, usuarios: usuarios);

        var dto = await service.create();

        Assert.NotNull(creado);
        Assert.Equal(1, creado!.UsuarioID);
        Assert.Equal(DateTimeKind.Utc, creado.FechaCreacion.Kind);
        Assert.Equal(DateTimeKind.Utc, creado.UltimaVez.Kind);
        Assert.Equal(20, dto.Id);
    }
}
