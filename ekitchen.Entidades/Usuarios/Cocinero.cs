using ekitchen.Entidades.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekitchen.Entidades.Usuarios
{
    public partial class Cocinero : EF.Usuario
    {
        public Cocinero() : base() { }

        public Cocinero(EF.Usuario usuario) { }
        public Evento CrearEvento()
        {
            return null;
        }

        public Receta CrearReceta()
        {
            return null;
        }
    }
}
