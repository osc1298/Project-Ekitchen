using ekitchen.Entidades.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ekitchen.Servicios.Interfaces
{
    public interface IEventoServicio
    {
        int Crear(Evento evento);
        List<Evento> ObtenerEventos(int IdCocinero);
        List<Evento> ObtenerEventosCancelables(int IdCocinero);
        Boolean CancelarEvento(int IdEvento);
        List<Evento> ObtenerEventosFinalizadosConComentarios();

        Evento ObtenerEventoPorId(int idEvento);

        Usuario ObtenerCocineroPorId(int IdCocinero);
    }
}
