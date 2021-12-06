using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ekitchen.Models.ComensalesModel
{
    public class ReservaModel
    {
        public int IdEvento { get; set; }
        public int RecetaSeleccionada { get; set; }
        public int CantidadComensales { get; set; }
    }
}
