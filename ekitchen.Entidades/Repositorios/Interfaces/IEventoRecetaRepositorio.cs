using ekitchen.Entidades.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekitchen.Entidades.Repositorios.Interfaces
{
    public interface IEventoRecetaRepositorio
    {
        void AsociarRecetasAEvento(List<EventosReceta> lista);
    }
}
