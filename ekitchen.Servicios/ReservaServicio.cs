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
    public class ReservaServicio : IReservaServicio
    {
        private IReservaRepositorio reservaRepositorio;

        public ReservaServicio(IReservaRepositorio reservaRepo)
        {
            reservaRepositorio = reservaRepo;
        }
        public List<Evento> EventosDisponibles()
        {

            List<Evento> lista = new List<Evento>();
            foreach (var item in reservaRepositorio.EventosDisponibles())
            {
                if (DateTime.Now <= item.Fecha && item.Estado == 1)
                {
                    lista.Add(item);
                }

            }
            return lista;
        }

        public int CantidadComensalesReservaPorEvento(int idEvento)
        {
            return reservaRepositorio.CantidadComensalesReservaPorEvento(idEvento);
        }

        public List<Receta> obtenerEventoPorId(int id)
        {
          return  reservaRepositorio.obtenerEventoPorId(id);
        }

        public int LugaresDisponibles(int idEvento)
        {
            int lugaresDisponibles = CantidadComensalesEvento(idEvento) - CantidadComensalesReservaPorEvento(idEvento);
            return lugaresDisponibles;

        }
        public Boolean registrarReserva(int idEvento, int idComensal, int idReceta, int cantidad)
        {
            Boolean hayLugar = (LugaresDisponibles(idEvento) > 0);
            int lugaresLibres = LugaresDisponibles(idEvento);
            if(hayLugar)
            {
                /*tuve que agregar aqui una validacion mas ya que anteriormente 
                 si habia lugar te deja reservar, pero no validaba que los espacios disponibles sean igual o menor a la cantidad ingresa por el cliente
                ejemplo (quedaban 3 lugares y el cliente pedia ingresar 7 personas, la reserva la hacia y guardaba, pero cuando querias hacer una tercera reserva no te dejaba hacerla)*/
                if (cantidad <= lugaresLibres)
                {
                    Reserva reserva = new Reserva();
                    reserva.IdEvento = idEvento;
                    reserva.IdComensal = idComensal;
                    reserva.IdReceta = idReceta;
                    reserva.CantidadComensales = cantidad;
                    reserva.FechaCreacion = DateTime.Now;
                    reservaRepositorio.registrarReserva(reserva);
                    return true;
                }
            }
            else
            {
                return false;
            }
            return false;
        }

        public int CantidadComensalesEvento(int idEvento)
        {
            return reservaRepositorio.CantidadComensalesEvento(idEvento);

        }

        public List<Evento> ObtenerMisReservasPorId(int idComensal)
        {
            return reservaRepositorio.ObtenerMisReservasPorId(idComensal);
        }
    }
}
