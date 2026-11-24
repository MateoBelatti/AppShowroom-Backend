using AutoMapper;
using biblioteca.clases;
using biblioteca.Errors;
using biblioteca.mappers;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Repository;
using Services.Services.producto;
using Xunit;

namespace AppShowroom.Tests.Services;

public class ProductoServiceTests
{
    private static ProductoService CrearService(
        Mock<IProductoRepository> productos,
        Mock<ICategoriaRepository> categorias)
    {
        var mapper = new MapperConfiguration(cfg => cfg.AddProfile<ProductoProfile>(), NullLoggerFactory.Instance)
            .CreateMapper();
        return new ProductoService(productos.Object, categorias.Object, mapper);
    }

    [Fact]
    public async Task FindByCategoria_CuandoNoExisteCategoria_Lanza404YNoConsultaProductos()
    {
        var productos = new Mock<IProductoRepository>();
        var categorias = new Mock<ICategoriaRepository>();
        categorias.Setup(r => r.GetById(5)).ReturnsAsync((Categoria?)null);
        var service = CrearService(productos, categorias);

        var ex = await Assert.ThrowsAsync<AppException>(() => service.findByCategoria(5));

        Assert.Equal(404, ex.StatusCode);
        productos.Verify(r => r.GetAllActivos(), Times.Never);
        productos.Verify(r => r.GetAllActivosByCategoria(It.IsAny<int>()), Times.Never);
    }

    [Fact]
    public async Task FindByCategoria_ConsultaElRepositorioFiltradoYNoTraeTodos()
    {
        var productos = new Mock<IProductoRepository>();
        productos.Setup(r => r.GetAllActivosByCategoria(5))
            .ReturnsAsync(new[] { new Producto { Id = 1, Nombre = "Vela" } });
        var categorias = new Mock<ICategoriaRepository>();
        categorias.Setup(r => r.GetById(5)).ReturnsAsync(new Categoria { Id = 5, Nombre = "Velas" });
        var service = CrearService(productos, categorias);

        var result = (await service.findByCategoria(5)).ToList();

        Assert.Single(result);
        Assert.Equal("Vela", result[0].Nombre);
        productos.Verify(r => r.GetAllActivos(), Times.Never);
        productos.Verify(r => r.GetAllActivosByCategoria(5), Times.Once);
    }
}
