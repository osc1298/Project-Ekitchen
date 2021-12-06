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
    public class CalificacioneServicio : ICalificacioneServicio
    {

        private ICalificacioneRepositorio _RepositorioCalificacione;

        public CalificacioneServicio(ICalificacioneRepositorio repositorioCalificacione)
        {
            _RepositorioCalificacione = repositorioCalificacione;
        }

        public List<Calificacione> ObtenerCalificacionesPorIdEvento(int IdEvento)
        {
            return _RepositorioCalificacione.ObtenerCalificacionesPorIdEvento(IdEvento);
        }

        public List<Calificacione> obtenerMisCalificaciones(int idComensal)
        {
          return  _RepositorioCalificacione.obtenerMisCalificaciones(idComensal);
        }

        public Boolean RegistrarCalificacion(Calificacione comentario)
        {
            if (VerificarCalificacionPorIdComensalYIdEvento(comentario.IdComensal, comentario.IdEvento) == true)
            {
                _RepositorioCalificacione.RegistrarCalificacion(comentario);
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool VerificarCalificacionPorIdComensalYIdEvento(int id, int idEvento)
        {
            return (_RepositorioCalificacione.VerificarCalificacionPorIdComensalYIdEvento(id, idEvento).Count() == 0);
            
        }
    }
}
