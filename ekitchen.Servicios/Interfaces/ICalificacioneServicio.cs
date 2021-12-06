using ekitchen.Entidades.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekitchen.Servicios.Interfaces
{
    public interface ICalificacioneServicio
    {
        Boolean RegistrarCalificacion(Calificacione comentario);
        Boolean VerificarCalificacionPorIdComensalYIdEvento(int id, int idEvento);

       List<Calificacione> obtenerMisCalificaciones(int idComensal);

        List<Calificacione> ObtenerCalificacionesPorIdEvento(int IdEvento);
    }
}
