using ekitchen.Entidades.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekitchen.Entidades.Repositorios.Interfaces
{
    public interface IRecetaRepositorio
    {
        void Crear(Receta receta);
        List<Receta> ObtenerRecetas(int IdCocinero);
        Boolean BorrarReceta(int idCocinero, int idReceta);
    }
}
