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
    public class RecetaServicio : IRecetaServicio
    {
        private IRecetaRepositorio _recetaRepositorio;

        public RecetaServicio(IRecetaRepositorio recetaRepositorio)
        {
            _recetaRepositorio = recetaRepositorio;
        }

        public Boolean BorrarReceta(int idCocinero, int IdReceta)
        {
           
            return _recetaRepositorio.BorrarReceta(idCocinero,IdReceta);
        }

        public void Crear(Receta receta)
        {
            _recetaRepositorio.Crear(receta);

        }

        public List<Receta> ObtenerRecetas(int IdCocinero)
        {
            return _recetaRepositorio.ObtenerRecetas(IdCocinero);
        }
    }
}
