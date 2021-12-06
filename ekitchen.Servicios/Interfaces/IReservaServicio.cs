using ekitchen.Entidades.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekitchen.Servicios.Interfaces
{
    public interface IReservaServicio
    {
        List<Evento> EventosDisponibles();
        List<Receta> obtenerEventoPorId(int id);
        Boolean registrarReserva(int idEvento, int idComensal,int idReceta,int cantidad);

        int CantidadComensalesReservaPorEvento(int idEvento);
        int LugaresDisponibles(int idEvento);
        int CantidadComensalesEvento(int idEvento);

        List<Evento> ObtenerMisReservasPorId(int idComensal);

    }
}
