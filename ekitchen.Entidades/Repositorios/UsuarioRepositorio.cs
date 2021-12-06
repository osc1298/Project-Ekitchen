using ekitchen.Entidades.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekitchen.Entidades.Repositorios.Interfaces
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private _20212C_TPContext _ctx;

        public UsuarioRepositorio(_20212C_TPContext ctx)
        {
            _ctx = ctx;
        }

        public EF.Usuario Existe(string Email, string Password)
        {
            EF.Usuario usuario = null;
            try
            {
                usuario = _ctx.Usuarios.First(u => u.Email == Email && u.Password == Password);
            }
            catch (Exception e) {
                string mensaje=e.Message;
            }

            return usuario;
           
        }



        public void AgregarUsuario(EF.Usuario chef)
        {
            _ctx.Usuarios.Add(chef);
            _ctx.SaveChanges();
        }
    }
}
