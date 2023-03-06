using System.ComponentModel.DataAnnotations;

namespace L01_2019MA603.Models
{
    public class clientes
    {
       // internal object clientes;

        [Key]
        public int id_clienteld { get; set; }

        public string nombreCliente { get; set; }

        public string direccion { get; set; }

    }
}
