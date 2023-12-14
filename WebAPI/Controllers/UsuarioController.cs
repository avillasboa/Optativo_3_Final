using Microsoft.AspNetCore.Mvc;
using Infraestructura.Modelos;
using Infraestructura.Datos;
using Servicios.CiudadService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private UsuarioService usuarioService;
        private const string ConexionString = "Server=localhost;Port=5432;User Id=postgres;Password=fullstack;Database=Proyecto_Segundo_Parcial;";

        public UsuarioController()
        {
            usuarioService = new UsuarioService(ConexionString);
        }

        // GET: api/<UsuarioController>
        [HttpGet("por-ruta/{idusuario}")]
        public IActionResult obtenerUsuario([FromRoute] int idusuario)
        {
            var usuarios = usuarioService.obtenerUsuario(idusuario);
            return Ok(usuarios);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("por-parametro")]
        public IActionResult obtenerUsuario2([FromRoute] int idusuario)
        {

            var usuarios = usuarioService.obtenerUsuario(idusuario);
            return Ok(usuarios);

        }


        // POST api/<UsuarioController>
        [HttpPost]
        public OkObjectResult Post([FromBody] UsuarioModel usuarioModel)
        {
            usuarioService.InsertarUsuario(usuarioModel);
            return Ok(new { Message = "Usuario insertado correctamente." });

        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("por-ruta/{idusuario}")]
        public IActionResult eliminarUsuario([FromRoute] int idusuario)
        {
            var usuarios = usuarioService.eliminarUsuario(idusuario);
            
            return Ok(usuarios);
            
        }
    }
}
