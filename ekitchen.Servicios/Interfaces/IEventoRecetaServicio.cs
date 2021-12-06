

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekitchen.Servicios.Interfaces
{
    public interface IEventoRecetaServicio
    {
        void AsociarRecetasAEvento(int idEvento, List<int> listaRecetas);
    }
}
