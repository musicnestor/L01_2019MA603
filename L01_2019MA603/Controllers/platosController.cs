using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2019MA603.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace L01_2019MA603.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class platosController : ControllerBase
    {
        private readonly platosContext _platosContexto;

        public platosController(platosContext platosContexto)
        {
            _platosContexto = platosContexto;

        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<platos> listadoplatos = (from e in _platosContexto.platos
                                              select e).ToList();

            if (listadoplatos.Count() == 0)
            {
                return NotFound();
            }

            return Ok(listadoplatos);
            //Aqui termina la guia 1

        }

        // INICIO DE LA GUIA2
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            platos? plato = (from e in _platosContexto.platos
                                 where e.id_platold == id
                                 select e).FirstOrDefault();


            if (plato == null)
            {
                return NotFound();
            }

            return Ok(plato);
        }

        //CREAR
        [HttpGet]
        [Route("Find/{filtro}")]
        public IActionResult FindByDescription(string filtro)
        {
            platos? plato = (from e in _platosContexto.platos
                                 where e.nombrePlato.Contains(filtro)
                                 select e).FirstOrDefault();

            if (plato == null)
            {
                return NotFound();
            }

            return Ok(plato);
        }
        //AGREGAR
        [HttpPost]
        [Route("Add")]
        public IActionResult Guardarclientes([FromBody] platos plato)
        {
            try
            {
                _platosContexto.platos.Add(plato);
                _platosContexto.SaveChanges();
                return Ok(plato);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            
            }
        //MODIFICAR

        [HttpPut]
        [Route("actualizar/{id}")]
        public IActionResult ActualizarPlato(int id, [FromBody] platos platoModificar)
        {
            try
            {
                platos? platoActual = (from e in _platosContexto.platos
                                           where e.id_platold == id
                                           select e).FirstOrDefault();
                if (platoActual == null)
                {
                    return NotFound();
                }
                platoActual.nombrePlato = platoModificar.nombrePlato;
                platoActual.precio = platoModificar.precio;

                return Ok(platoModificar);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // ELIMINAR

        [HttpDelete]
        [Route("eliminar/{id}")]
        public IActionResult EliminarPlatos(int id)
        {
            try
            {
                platos? plato = (from e in _platosContexto.platos
                                     where e.id_platold == id
                                     select e).FirstOrDefault();
                if (plato == null)
                {
                    return NotFound();
                }

                _platosContexto.platos.Attach(plato);
                _platosContexto.platos.Remove(plato);
                _platosContexto.SaveChanges();
                return Ok(plato);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
