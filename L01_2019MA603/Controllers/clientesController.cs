using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2019MA603.Models;
using Microsoft.EntityFrameworkCore;



namespace L01_2019MA603.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class clientesController : ControllerBase
    {
        private readonly clientesContext _clientesContexto;
        public clientesController(clientesContext clientesContexto)
        {
            _clientesContexto = clientesContexto;
        }
        [HttpGet]
        [Route("GetAll")]XmlConfigurationExtensions
        public IActionResult Get()
        {
            List<clientes> Listado = (from e in _clientesContexto.clientes select e).ToList();
            if (Listadoclientes.Count == 0)
            {
                return NotFound();
            }
            return Ok(Listadoclientes);

        }
    }



}
