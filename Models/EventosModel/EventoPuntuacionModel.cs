using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ekitchen.Models.EventosModel
{
    public class EventoPuntuacionModel
    {
       public int IdEvento { get; set; }
        public string Foto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public double Puntiacion { get; set; }
    }
}
