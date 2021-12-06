using ekitchen.Entidades.EF;
using ekitchen.Entidades.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekitchen.Entidades.Repositorios
{
    public class TipoRecetaRepositorio : ITipoRecetaRepositorio
    {
        private _20212C_TPContext _ctx;

        public TipoRecetaRepositorio(_20212C_TPContext ctx)
        {
            _ctx = ctx;
        }


        public List<TipoReceta> ObtenerTiposRecetas()
        {
            return _ctx.TipoRecetas.ToList();
        }

    }
}
