using AutoMapper;
using biblioteca.clases;
using biblioteca.dtos.detalleCarrito;
using biblioteca.mappers;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace AppShowroom.Tests.Mappers;

public class DetalleCarritoProfileTests
{
    private readonly IMapper _mapper = new MapperConfiguration(
            cfg => cfg.AddProfile<DetalleCarritoProfile>(), NullLoggerFactory.Instance)
        .CreateMapper();

    [Fact]
    public void Map_ConProducto_CompletaDatosDelProductoYSubtotal()
    {
        var detalle = new DetalleCarrito
        {
            Id = 7,
            CarritoID = 3,
            ProductoID = 5,
            Cantidad = 2,
            Producto = new Producto { Id = 5, Nombre = "Vela", Imagen = "vela.png", Precio = 12.5m }
        };

        var dto = _mapper.Map<DetalleCarritoDto>(detalle);

        Assert.Equal(7, dto.Id);
        Assert.Equal(3, dto.CarritoId);
        Assert.Equal(5, dto.ProductoId);
        Assert.Equal(2, dto.Cantidad);
        Assert.Equal("Vela", dto.NombreProducto);
        Assert.Equal("vela.png", dto.ImagenProducto);
        Assert.Equal(12.5m, dto.PrecioUnitario);
        Assert.Equal(25m, dto.Subtotal);
    }

    [Fact]
    public void Map_SinProducto_DejaValoresPorDefecto()
    {
        var detalle = new DetalleCarrito { Id = 8, ProductoID = 5, Cantidad = 3 };

        var dto = _mapper.Map<DetalleCarritoDto>(detalle);

        Assert.Equal(string.Empty, dto.NombreProducto);
        Assert.Equal(string.Empty, dto.ImagenProducto);
        Assert.Equal(0m, dto.PrecioUnitario);
        Assert.Equal(0m, dto.Subtotal);
    }
}
