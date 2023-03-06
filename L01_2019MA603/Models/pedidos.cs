
using System.ComponentModel.DataAnnotations;

namespace L01_2019MA603.Models
{
    public class pedidos
    {

        [Key]

        public int id_pedidold { get; set; }

        public string motoristald { get; set; }

        public string clienteld { get; set; }

        public string platold { get;}

        public int cantidad { get; set; }

        public int precio { get; set; }




    }
}
