using ekitchen.Entidades.EF;
using ekitchen.Entidades.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekitchen.Entidades.Repositorios
{
    public class EventoRecetaRepositorio : IEventoRecetaRepositorio
    {
        private _20212C_TPContext _ctx;

        public EventoRecetaRepositorio(_20212C_TPContext ctx)
        {
            _ctx = ctx;
        }
        public void AsociarRecetasAEvento(List<EventosReceta> lista)
        {
            lista.ForEach(
                delegate (EventosReceta eventoReceta)
                {
                    _ctx.EventosRecetas.Add(eventoReceta);
                    _ctx.SaveChanges();
                }
            );
        }
    }
}
