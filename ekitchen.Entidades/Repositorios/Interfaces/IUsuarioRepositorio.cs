using ekitchen.Entidades.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekitchen.Entidades.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        public EF.Usuario Existe(string Email, string Password);
        void AgregarUsuario(EF.Usuario chef);
    }
}
