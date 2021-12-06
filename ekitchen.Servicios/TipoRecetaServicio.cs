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
    public class TipoRecetaServicio : ITipoRecetaServicio
    {
        private ITipoRecetaRepositorio _tipoRecetaRepositorio;

        public TipoRecetaServicio(ITipoRecetaRepositorio tipoRecetaRepositorio)
        {
            _tipoRecetaRepositorio = tipoRecetaRepositorio;
        }
        public List<TipoReceta> ObtenerTiposRecetas()
        {
            return _tipoRecetaRepositorio.ObtenerTiposRecetas();
        }
    }
}
