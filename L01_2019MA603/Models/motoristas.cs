using System.ComponentModel.DataAnnotations;

namespace L01_2019MA603.Models
{
    public class motoristas
    {
        //internal int id_clienteld;
        //internal int id_clientes;
        //internal object descripcion;

        [Key]
        public int id_motoristald { get; set; }
        public string motoristald { get; set; }
        public string nombreMotoristald { get; set; }
    }
}
