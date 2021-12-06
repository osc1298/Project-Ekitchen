using ekitchen.Entidades.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekitchen.Entidades.Repositorios.Interfaces
{
    public interface IReservaRepositorio
    {
        List<Evento> EventosDisponibles();
        List<Receta> obtenerEventoPorId(int id);
        void registrarReserva(Reserva reserva);

        int CantidadComensalesReservaPorEvento(int idEvento);
        int CantidadComensalesEvento(int idEvento);

        List<Evento> ObtenerMisReservasPorId(int idComensal);
    }
}
