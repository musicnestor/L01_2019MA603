using System.ComponentModel.DataAnnotations;

namespace L01_2019MA603.Models
{
    public class platos
    {
        [Key]
        public int id_platold { get; set; }

        public string nombrePlato { get; set; }

        public int precio { get; set; }


    }
}
