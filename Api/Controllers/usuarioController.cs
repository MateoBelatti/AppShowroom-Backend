using biblioteca.dtos.usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Services.usuarios;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class usuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public usuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        // GET: /api/usuario
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _usuarioService.GetAll();
            return Ok(usuarios);
        }
        // GET: /api/usuario/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _usuarioService.GetById(id);
            return usuario is null ? NotFound() : Ok(usuario);
        }
        // POST: /api/usuario
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioCreateDto dataDto)
        {
            var usuarioCreado = await _usuarioService.Create(dataDto);
            return CreatedAtAction(nameof(GetById), new { id = usuarioCreado.Id }, usuarioCreado);
        }
        // PUT: /api/usuario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioUpdateDto dataDto)
        {

            var usuarioActualizado = await _usuarioService.Update(id, dataDto);
            return usuarioActualizado is null ? NotFound() : Ok(usuarioActualizado);
        }
        // DELETE: /api/usuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _usuarioService.Delete(id);
            return resultado ? NoContent() : NotFound();
        }
    }
}