using ekitchen.Entidades.EF;
using ekitchen.Entidades.Repositorios.Interfaces;
using ekitchen.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekitchen.Servicios
{
    public class EventoRecetaServicio : IEventoRecetaServicio
    {
        private IEventoRecetaRepositorio _EventoRecetaRepositorio;

        public EventoRecetaServicio(IEventoRecetaRepositorio EventoRecetaRepositorio)
        {
            _EventoRecetaRepositorio = EventoRecetaRepositorio;
        }
        public void AsociarRecetasAEvento(int idEvento, List<int> listaRecetas)
        {
            List<EventosReceta> listaEventosReceta = new List<EventosReceta>();
            listaRecetas.ForEach(
                delegate (int idReceta)
                {
                    EventosReceta eventoReceta = new EventosReceta();
                    eventoReceta.IdEvento = idEvento;
                    eventoReceta.IdReceta = idReceta;
                    listaEventosReceta.Add(eventoReceta);
                }
            );

            _EventoRecetaRepositorio.AsociarRecetasAEvento(listaEventosReceta);

        }
    }
}
