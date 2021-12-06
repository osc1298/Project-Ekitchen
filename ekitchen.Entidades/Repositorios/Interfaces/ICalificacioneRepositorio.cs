using ekitchen.Entidades.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekitchen.Entidades.Repositorios.Interfaces
{
    public interface ICalificacioneRepositorio
    {
        void RegistrarCalificacion(Calificacione comentario);
        List<Calificacione> VerificarCalificacionPorIdComensalYIdEvento(int id, int idEvento);

      List<Calificacione>  obtenerMisCalificaciones(int idComensal);

        List<Calificacione> ObtenerCalificacionesPorIdEvento( int IdEvento);
    }
}
