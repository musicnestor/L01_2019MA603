using System.ComponentModel.DataAnnotations;

namespace L01_2019MA603.Models
{
    public class clientes
    {
        internal int id_clienteld;
        internal int id_clientes;
        internal object descripcion;

        [Key]
        public int id { get; set; }
        public string nombreCliente { get; set; }
        public string direccion { get; set; }
      
       


    }
}
