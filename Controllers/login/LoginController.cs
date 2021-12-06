using ekitchen.Entidades.EF;
using ekitchen.Entidades.Usuarios;
using ekitchen.Models.UsuariosModel;
using ekitchen.Models.Mappings;
using ekitchen.Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ekitchen.Controllers.login
{
    public class LoginController : Controller
    {
        private IUsuarioServicio _ServicioUsuario;

       public LoginController(IUsuarioServicio usuarioServicio)
        {
            _ServicioUsuario = usuarioServicio;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                Usuario UsuarioLogueado = _ServicioUsuario.Existe(usuario.Email, usuario.Password);
                if (UsuarioLogueado != null)
                {
                    HttpContext.Session.SetString("Nombre", UsuarioLogueado.Nombre);
                    HttpContext.Session.SetInt32("Perfil", UsuarioLogueado.Perfil);
                    HttpContext.Session.SetInt32("IdUsuario", UsuarioLogueado.IdUsuario);
                    if (typeof(Cocinero).IsInstanceOfType(UsuarioLogueado))
                    {
                        HttpContext.Session.SetString("EmailCocinero", UsuarioLogueado.Email);
                        HttpContext.Session.SetString("FechaRegistracionCocinero", UsuarioLogueado.FechaRegistracion.ToString());
                        return RedirectToAction("Perfil", "Cocinero");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Comensal");
                    }

                }
                TempData["Error"] = $"El correo no esta registrado en el sistema";
                return View();
            }
            TempData["Error"] = $"Los datos ingresados no son correctos";
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarUsuario(UsuarioModel userModel)
        {
            if (ModelState.IsValid)
            {
                Usuario UsuarioLogueado = _ServicioUsuario.Existe(userModel.Email, userModel.Password);
                if (UsuarioLogueado == null){

                        Usuario usuario = userModel.UsuarioModelToUsuario();
                        _ServicioUsuario.AgregarUsuario(usuario);
                        TempData["Resultado"] = $"Se registrado correctamente: {usuario.Nombre}";
                        return RedirectToAction("Login");
                  
                }
                TempData["Error"] = $"Usuario {userModel.Email} existe";
                return View("Login");
            }
            TempData["Error"] = $"No se pudieron grabar los datos";
            return View("RegisterUser");
        }

        public IActionResult RegisterUser()
        {
            return View("RegisterUser");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Default");
        }
    }
}

