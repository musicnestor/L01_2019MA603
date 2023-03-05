using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2019MA603.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<clientes> listadoclientes = (from e in _clientesContexto.clientes
                                              select e).ToList();

            if (listadoclientes.Count() == 0)
            {
                return NotFound();
            }

            return Ok(listadoclientes);
            //Aqui termina la guia 1
        }
        // INICIO DE LA GUIA2
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            clientes? cliente = (from e in _clientesContexto.clientes
                               where e.id_clientes == id
                               select e).FirstOrDefault();


            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        //TERCERA PARTE
        [HttpGet]
        [Route("Find/{filtro}")]
        public IActionResult FindByDescription(string filtro)
        {
            clientes? cliente = (from e in _clientesContexto.clientes
                                //where e.descripcion.Contains(filtro)
                                 select e).FirstOrDefault();

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        //AGREGAR
        [HttpPost]
        [Route("Add")]
        public IActionResult Guardarclientes([FromBody] clientes equipo)
        {
            try
            {
                _clientesContexto.clientes.Add(equipo);
                _clientesContexto.SaveChanges();
                return Ok(equipo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        //MODIFICAR

        [HttpPut]
        [Route("actualizar/{id}")]
        public IActionResult ActualizarEquipo(int id, [FromBody] clientes equipoModificar)
        {
            try
            {
                clientes? clienteActual = (from e in _clientesContexto.clientes
                                         where e.id_clientes == id
                                         select e).FirstOrDefault();
                if (clienteActual == null)
                {
                    return NotFound();
                }
                clienteActual.nombreCliente = equipoModificar.nombreCliente;
                clienteActual.direccion = equipoModificar.direccion;
                
                return Ok(equipoModificar);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // ELIMINAR

        [HttpDelete]
        [Route("eliminar/{id}")]
        public IActionResult EliminarEquipo(int id)
        {
            try
            {
                clientes? cliente = (from e in _clientesContexto.clientes
                                   where e.id_clientes == id
                                   select e).FirstOrDefault();
                if (cliente == null)
                {
                    return NotFound();
                }

                _clientesContexto.clientes.Attach(cliente);
                _clientesContexto.clientes.Remove(cliente);
                _clientesContexto.SaveChanges();
                return Ok(cliente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

}







