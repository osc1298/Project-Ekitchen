using ekitchen.Entidades.EF;
using ekitchen.Entidades.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekitchen.Entidades.Repositorios
{
    public class ReservaRepositorio : IReservaRepositorio
    {
        private _20212C_TPContext _ctx;
       
        public ReservaRepositorio(_20212C_TPContext ctx)
        {
            _ctx = ctx;
        }

        public int CantidadComensalesReservaPorEvento(int idEvento)
        {
            int totalComensales = 0;
            /*List<int> valores = new List<int>();
            valores = (from e in _ctx.Reservas where e.IdEvento == idEvento select e.CantidadComensales).ToList();
            foreach(var item in valores)
            {
               totalComensales =+ item;
            }*/
            var valores = (from e in _ctx.Reservas where e.IdEvento == idEvento select e.CantidadComensales).ToList();
            var sum = valores.ToList().Sum();
            return totalComensales= sum;
        }

        public List<Receta> obtenerEventoPorId(int id)
        {
            List<Receta> lista = new List<Receta>();
            return   lista = (from ER in _ctx.EventosRecetas
                     join R in _ctx.Recetas on ER.IdReceta equals R.IdReceta
                     where ER.IdEvento == id
                     select R).ToList();
        }

        public void registrarReserva(Reserva reserva)
        {
            _ctx.Reservas.Add(reserva);
            _ctx.SaveChanges();
        }

        public List<Evento> EventosDisponibles()
        {
            List<Evento> p = new List<Evento>();
            var c = (from a in _ctx.Eventos select a);
            foreach (var item in c)
            {
                p.Add(item);
            }

            return p;
        }

        public int CantidadComensalesEvento(int idEvento)
        {
            Evento evento=_ctx.Eventos.First(e => e.IdEvento == idEvento);
            return evento.CantidadComensales;
        }

        public List<Evento> ObtenerMisReservasPorId(int idComensal)
        {
            List<Evento> lista = new List<Evento>();
            var e = (from f in _ctx.Eventos join r in _ctx.Reservas on f.IdEvento equals r.IdEvento
                     where r.IdComensal == idComensal select f);
                     foreach(var item in e)
            {
                lista.Add(item);
            }
            return lista;
            
        }
    }
}
