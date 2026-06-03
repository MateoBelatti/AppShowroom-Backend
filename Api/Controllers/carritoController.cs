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
        public async Task<IActionResult> FindByIdUsuario(int idUsuario)
        {
            var carrito = await _carritoService.findByIdUsuario(idUsuario);
            return carrito is null ? NotFound() : Ok(carrito);
        }

        // GET: /api/carrito/5
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            var carrito = await _carritoService.findById(id);
            return carrito is null ? NotFound() : Ok(carrito);
        }

        // POST: /api/carrito/create
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CarritoCreateDto dataDto)
        {
            var carritoCreado = await _carritoService.create(dataDto);
            // Assuming CarritoDto has an Id property.
            return CreatedAtAction(nameof(FindById), new { id = carritoCreado.Id }, carritoCreado);
        }

        // PUT: /api/carrito/update/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CarritoUpdateDto dataDto)
        {
            var carritoActualizado = await _carritoService.update(id, dataDto);
            return carritoActualizado is null ? NotFound() : Ok(carritoActualizado);
        }

        // DELETE: /api/carrito/delete/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _carritoService.delete(id);
            return eliminado ? NoContent() : NotFound();
        }
    }
}
