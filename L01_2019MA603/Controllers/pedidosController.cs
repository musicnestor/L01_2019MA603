using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using L01_2019MA603.Models;
using Microsoft.EntityFrameworkCore;

namespace L01_2019MA603.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pedidosController : ControllerBase
    {
        private readonly pedidosContext _pedidosContexto;

        public pedidosController(pedidosContext pedidosContexto)
        {
            _pedidosContexto = pedidosContexto;

        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<pedidos> listapedidos = (from e in _pedidosContexto.pedidos
                                          select e).ToList();

            if (listapedidos.Count() == 0)
            {
                return NotFound();
            }

            return Ok(listapedidos);
            //Aqui termina la guia 1
        }

        // INICIO DE LA GUIA2
        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            pedidos? pedido = (from e in _pedidosContexto.pedidos
                               where e.id_pedidold == id
                               select e).FirstOrDefault();


            if (pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }

        //CREAR
        [HttpGet]
        [Route("Find/{filtro}")]
        public IActionResult FindByDescription(string filtro)
        {
            pedidos? pedido = (from e in _pedidosContexto.pedidos
                               where e.clienteld.Contains(filtro)
                               select e).FirstOrDefault();

            if (pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }

        //MODIFICAR

        [HttpPut]
        [Route("actualizar/{id}")]
        public IActionResult ActualizarEquipo(int id, [FromBody] clientes pedidoModificar)
        {
            try
            {
                pedidos? pedidoActual = (from e in _pedidosContexto.pedidos
                                         where e.id_pedidold == id
                                         select e).FirstOrDefault();
                if (pedidoActual == null)
                {
                    return NotFound();
                }



                return Ok(pedidoModificar);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        // ELIMINAR

        [HttpDelete]
        [Route("eliminar/{id}")]
        public IActionResult EliminarPedido(int id)
        {
            try
            {
                pedidos? pedido = (from e in _pedidosContexto.pedidos
                                   where e.id_pedidold == id
                                   select e).FirstOrDefault();
                if (pedido == null)
                {
                    return NotFound();
                }

                _pedidosContexto.pedidos.Attach(pedido);
                _pedidosContexto.pedidos.Remove(pedido);
                _pedidosContexto.SaveChanges();
                return Ok(pedido);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
