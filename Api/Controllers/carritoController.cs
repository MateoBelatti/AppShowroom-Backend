using biblioteca.dtos.carrito;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Services.carrito;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class carritoController : ControllerBase
    {
        private readonly ICarritoService _carritoService;

        public carritoController(ICarritoService carritoService)
        {
            _carritoService = carritoService;
        }

        // GET: /api/carrito/usuario/5
        [HttpGet("usuario/{idUsuario}")]
        public async Task<IActionResult> GetByUsuarioId(int idUsuario)
        {
            var carrito = await _carritoService.GetByUsuarioId(idUsuario);
            return carrito is null ? NotFound() : Ok(carrito);
        }

        // GET: /api/carrito/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var carrito = await _carritoService.GetById(id);
            return carrito is null ? NotFound() : Ok(carrito);
        }

        // POST: /api/carrito/Create
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CarritoCreateDto dataDto)
        {
            var carritoCreado = await _carritoService.Create(dataDto);
            // Assuming CarritoDto has an Id property.
            return CreatedAtAction(nameof(GetById), new { id = carritoCreado.Id }, carritoCreado);
        }

        // PUT: /api/carrito/Update/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CarritoUpdateDto dataDto)
        {
            var carritoActualizado = await _carritoService.Update(id, dataDto);
            return carritoActualizado is null ? NotFound() : Ok(carritoActualizado);
        }

        // DELETE: /api/carrito/Delete/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _carritoService.Delete(id);
            return eliminado ? NoContent() : NotFound();
        }
    }
}
