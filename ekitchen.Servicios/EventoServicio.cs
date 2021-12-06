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
    public class EventoServicio : IEventoServicio
    {
        private IEventoRepositorio _eventoRepositorio;

        public EventoServicio(IEventoRepositorio eventoRepositorio)
        {
            _eventoRepositorio = eventoRepositorio;
        }

        public Boolean CancelarEvento(int IdEvento)
        {
            return _eventoRepositorio.CancelarEvento(IdEvento);
        }

        public int Crear(Evento evento)
        {
            int idEvento= _eventoRepositorio.Crear(evento);
            return idEvento;
        }

        public Usuario ObtenerCocineroPorId(int IdCocinero)
        {
           return _eventoRepositorio.ObtenerCocineroPorId(IdCocinero);
        }

        public Evento ObtenerEventoPorId(int idEvento)
        {
            return _eventoRepositorio.ObtenerEventoPorId(idEvento);
        }

        public List<Evento> ObtenerEventos(int IdCocinero)
        {
            return _eventoRepositorio.ObtenerEventos(IdCocinero);
        }

        public List<Evento> ObtenerEventosCancelables(int IdCocinero)
        {
            return _eventoRepositorio.ObtenerEventosCancelables(IdCocinero);
        }

        public List<Evento> ObtenerEventosFinalizadosConComentarios()
        {
            return _eventoRepositorio.ObtenerEventosFinalizadosConComentarios();
        }
    }
}
