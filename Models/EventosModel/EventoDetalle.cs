using ekitchen.Entidades.EF;
using ekitchen.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ekitchen.Models.EventosModel
{
    public class EventoDetalle
    {
        public string Foto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string NombreCocinero { get; set; }

        public List<Calificacione> Calificacione { get; set; }
    }
}
