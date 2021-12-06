using ekitchen.Entidades.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekitchen.Entidades.Repositorios.Interfaces
{
    public interface ITipoRecetaRepositorio
    {
        List<TipoReceta> ObtenerTiposRecetas();
    }
}
