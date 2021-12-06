using ekitchen.Entidades.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ekitchen.Models.CocinerosModel
{
    public class PerfilModel
    {
        public string Email { get; set; }
        public DateTime FechaRegistracion { get; set; }
        public int CantidadRecetas { get; set; }
        public List<Receta> ListaRecetas { get; set; }
        public List<Evento> ListaEventos { get; set; }

        public  PerfilModel (
            string emailCocinero,
            string fechaRegistracionCocinero,
            List<Receta> listaRecetas,
            List<Evento> listaEventos
            )
        {
            DateTime FechaRegistracion = Convert.ToDateTime(fechaRegistracionCocinero);
            
            this.Email = emailCocinero;
            this.FechaRegistracion = FechaRegistracion;
            this.ListaRecetas = listaRecetas;
            this.ListaEventos = listaEventos;
            this.CantidadRecetas = listaRecetas.Count();

        }
    }
}
