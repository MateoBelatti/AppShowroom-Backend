using biblioteca.dtos.detalleCarrito;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Services.detalleCarrito;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class detalleCarritoController : ControllerBase
    {
        private readonly IDetalleCarritoService _detalleCarritoService;

        public detalleCarritoController(IDetalleCarritoService detalleCarritoService)
        {
            _detalleCarritoService = detalleCarritoService;
        }

        // GET: /api/detalleCarrito/carrito/5
        [HttpGet("{idCarrito}")]
        public async Task<IActionResult> FindAllByIdCarrito(int idCarrito)
        {
            var detalles = await _detalleCarritoService.findAllByIdCarrito(idCarrito);
            return Ok(detalles);
        }

        // POST: /api/detalleCarrito/create
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DetalleCarritoCreateDto dataDto)
        {
            var detalleCreado = await _detalleCarritoService.create(dataDto);
            return CreatedAtAction(nameof(FindAllByIdCarrito), new {idCarrito = detalleCreado.CarritoId}, detalleCreado);
        }

        // PUT: /api/detalleCarrito/update
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DetalleCarritoUpdateDto dataDto)
        {
            var detalleActualizado = await _detalleCarritoService.Update(dataDto);
            return detalleActualizado is null ? NotFound() : Ok(detalleActualizado);
        }

        // DELETE: /api/detalleCarrito/delete/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _detalleCarritoService.delete(id);
            return eliminado ? NoContent() : NotFound();
        }
    }
}
