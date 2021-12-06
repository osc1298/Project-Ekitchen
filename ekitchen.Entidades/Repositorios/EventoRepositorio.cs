using ekitchen.Entidades.EF;
using ekitchen.Entidades.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekitchen.Entidades.Repositorios
{
    public class EventoRepositorio : IEventoRepositorio
    {
        private _20212C_TPContext _ctx;
        public int limite = 0;

        public EventoRepositorio(_20212C_TPContext ctx)
        {
            _ctx = ctx;
        }
        public int Crear(Evento evento)
        {
            _ctx.Eventos.Add(evento);
            _ctx.SaveChanges();
            return evento.IdEvento;
        }

        public List<Evento> ObtenerEventos(int IdCocinero)
        {
            return _ctx.Eventos.Where(r => r.IdCocinero == IdCocinero).ToList();
        }

        public List<Evento> ObtenerEventosCancelables(int IdCocinero)
        {
            DateTime hoy = DateTime.Today;
            return _ctx.Eventos.Where(r => r.IdCocinero == IdCocinero 
                                    && r.Fecha.Date > hoy 
                                    && r.Estado ==1).ToList();
        }

        public Boolean CancelarEvento(int IdEvento)
        {
            Evento evento = _ctx.Eventos.First(e => e.IdEvento == IdEvento);
            evento.Estado = 4;
            int res = 0;
            try
            {
                res = _ctx.SaveChanges();
            }catch(Exception ex)
            {
                string m=ex.Message;
                m.Trim();
                return false;
            }
            return true;
        }

        public List<Evento> ObtenerEventosFinalizadosConComentarios()
        {
            List<Evento> lista= _ctx.Eventos.Where(evento => evento.Estado == 3 
                                && evento.Calificaciones.Count > 0)
                                .OrderByDescending(evento=> evento.Fecha)
                                .Skip(0).Take(6).ToList();

            return lista;
        }

        public Evento ObtenerEventoPorId(int idEvento)
        {
            Evento evento = new Evento();
            evento = (from e in _ctx.Eventos where e.IdEvento == idEvento select e).FirstOrDefault();
            return evento;
        }

        public Usuario ObtenerCocineroPorId(int IdCocinero)
        {
            return _ctx.Usuarios.Where(cocinero => cocinero.IdUsuario == IdCocinero).FirstOrDefault();
        }
    }
}
