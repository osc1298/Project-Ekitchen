using ekitchen.Entidades.EF;
using ekitchen.Entidades.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekitchen.Entidades.Repositorios
{
    public class CalificacioneRespositorio : ICalificacioneRepositorio
    {
        private _20212C_TPContext _ctx;

        public CalificacioneRespositorio(_20212C_TPContext ctx)
        {
            _ctx = ctx;
        }

        public List<Calificacione> ObtenerCalificacionesPorIdEvento(int IdEvento)
        {
            return (List<Calificacione>)_ctx.Calificaciones.Where(calif => calif.IdEvento == IdEvento).ToList();
        }

        public List<Calificacione> obtenerMisCalificaciones(int idComensal)
        {
            List<Calificacione> lista = new List<Calificacione>();
            return lista = (from c in _ctx.Calificaciones where c.IdComensal == idComensal select c).ToList();
        }

        public void RegistrarCalificacion(Calificacione comentario)
        {
            _ctx.Calificaciones.Add(comentario);
            _ctx.SaveChanges();
        }

        public List<Calificacione> VerificarCalificacionPorIdComensalYIdEvento(int id, int idEvento)
        {
            List<Calificacione> c = (from e in _ctx.Calificaciones where e.IdComensal == id && e.IdEvento == idEvento select e).ToList();
            return c;
        }
    }
}
