using ekitchen.Entidades.EF;
using ekitchen.Entidades.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekitchen.Entidades.Repositorios
{
    public class RecetaRepositorio : IRecetaRepositorio
    {
        private _20212C_TPContext _ctx;

        public RecetaRepositorio(_20212C_TPContext ctx)
        {
            _ctx = ctx;
        }

        public Boolean BorrarReceta(int idCocinero, int idReceta)
        {

            Receta receta = _ctx.Recetas.Where(receta => receta.IdCocinero == idCocinero  &&  receta.IdReceta == idReceta).Single();
            _ctx.Recetas.Remove(receta);
            _ctx.SaveChanges();
            return true;
        }

        public void Crear(Receta receta)
        {
            _ctx.Recetas.Add(receta);
            _ctx.SaveChanges();
        }

        public List<Receta> ObtenerRecetas(int IdCocinero)
        {
            return _ctx.Recetas.Where(r => r.IdCocinero==IdCocinero).ToList();
        }
    }
}
