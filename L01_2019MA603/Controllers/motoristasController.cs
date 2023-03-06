using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2019MA603.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace L01_2019MA603.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class motoristasController : ControllerBase
    {

        private readonly motoristasContext _motoristasContexto;

        public motoristasController(motoristasContext motoristasContexto)
        {
            _motoristasContexto = motoristasContexto;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<motoristas> listadomotoristas = (from e in _motoristasContexto.motoristas
                                                  select e).ToList();

            if (listadomotoristas.Count() == 0)
            {
                return NotFound();
            }

            return Ok(listadomotoristas);
            //Aqui termina la guia 1
        }

        // INICIO DE LA GUIA2
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            motoristas? motorista = (from e in _motoristasContexto.motoristas
                                     where e.id_motoristald == id
                                     select e).FirstOrDefault();


            if (motorista == null)
            {
                return NotFound();
            }

            return Ok(motorista);
        }
        //CREAR      

        [Route("Find/{filtro}")]
        public IActionResult FindByDescription(string filtro)
        {
            motoristas? motorista = (from e in _motoristasContexto.motoristas
                                     where e.nombreMotoristald.Contains(filtro)
                                     select e).FirstOrDefault();

            if (motorista == null)
            {
                return NotFound();
            }

            return Ok(motorista);
        }

        //MODIFICAR

        [HttpPut]
        [Route("actualizar/{id}")]
        public IActionResult ActualizarEquipo(int id, [FromBody] motoristas motoristasModificar)
        {
            try
            {
                motoristas? motoristaActual = (from e in _motoristasContexto.motoristas
                                               where e.id_motoristald == id
                                               select e).FirstOrDefault();
                if (motoristaActual == null)
                {
                    return NotFound();
                }
                motoristaActual.nombreMotoristald = motoristasModificar.nombreMotoristald;
                // motoristaActual.direccion = equipoModificar.direccion;

                return Ok(motoristasModificar);
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
                motoristas? motorista = (from e in _motoristasContexto.motoristas
                                         where e.id_motoristald == id
                                         select e).FirstOrDefault();
                if (motorista == null)
                {
                    return NotFound();
                }

                _motoristasContexto.motoristas.Attach(motorista);
                _motoristasContexto.motoristas.Remove(motorista);
                _motoristasContexto.SaveChanges();
                return Ok(motorista);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }
    }
}

