using ekitchen.Entidades.EF;
using ekitchen.Entidades.Repositorios.Interfaces;
using ekitchen.Entidades.Usuarios;
using ekitchen.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekitchen.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServicio(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public void AgregarUsuario(Usuario chef)
        {
            _usuarioRepositorio.AgregarUsuario(chef);
        }

        public Usuario Existe(string Email, string Password)
        {
            Usuario UsuarioLogueado= _usuarioRepositorio.Existe(Email, Password);
            
            if (UsuarioLogueado != null)
            {

                if (UsuarioLogueado.Perfil == 1)
                {

                    Cocinero cocinero = new Cocinero();
                    cocinero.Nombre = UsuarioLogueado.Nombre;
                    cocinero.IdUsuario = UsuarioLogueado.IdUsuario;
                    cocinero.Email = UsuarioLogueado.Email;
                    cocinero.Password = UsuarioLogueado.Password;
                    cocinero.Perfil = UsuarioLogueado.Perfil;
                    cocinero.FechaRegistracion = UsuarioLogueado.FechaRegistracion;
                    return cocinero;

                    //return UsuarioLogueado as Cocinero;

                }
                else
                {
                    Comensal comensal = new Comensal();
                    comensal.Nombre = UsuarioLogueado.Nombre;
                    comensal.IdUsuario = UsuarioLogueado.IdUsuario;
                    comensal.Email = UsuarioLogueado.Email;
                    comensal.Password = UsuarioLogueado.Password;
                    comensal.Perfil = UsuarioLogueado.Perfil;
                    comensal.FechaRegistracion = UsuarioLogueado.FechaRegistracion;
                    return comensal;
                }
            }
            return null;
        }
    }

}