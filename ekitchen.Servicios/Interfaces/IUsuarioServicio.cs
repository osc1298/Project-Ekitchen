using ekitchen.Entidades.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekitchen.Servicios.Interfaces
{
    public interface IUsuarioServicio
    {
        public Usuario Existe(string Email, string Password);
        void AgregarUsuario(Usuario chef);
    }
}
