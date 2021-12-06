using ekitchen.Entidades.EF;
using ekitchen.Models.CocinerosModel;
using ekitchen.Models.Mappings;
using ekitchen.Servicios.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ekitchen.Controllers.cocinero
{
    public class CocineroController : Controller
    {
        private IRecetaServicio _RecetaServicio;
        private IEventoServicio _EventoServicio;
        private IEventoRecetaServicio _EventoRecetaServicio;
        private ITipoRecetaServicio _tipoRecetaServicio;
        private readonly IWebHostEnvironment hostEnvironment;

        public CocineroController(IRecetaServicio recetaServicio,
            IEventoServicio eventoServicio,
            IEventoRecetaServicio eventoRecetaServicio,
            ITipoRecetaServicio tipoRecetaServicio, 
            IWebHostEnvironment hostEnvironment )
        {
            _RecetaServicio = recetaServicio;
            _EventoServicio = eventoServicio;
            _EventoRecetaServicio = eventoRecetaServicio;
            _tipoRecetaServicio = tipoRecetaServicio;
            this.hostEnvironment = hostEnvironment;
        }

        public Boolean puedeInjectar()
        {
            if(HttpContext.Session.GetInt32("IdUsuario")!=null &&
               HttpContext.Session.GetInt32("Perfil") == 1)
            {
                return true;
            }
            return false;

        }

        public IActionResult Perfil()
        {
            if (puedeInjectar())
            {
                int idCocinero = (int)HttpContext.Session.GetInt32("IdUsuario");
                string emailCocinero = (string)HttpContext.Session.GetString("EmailCocinero");
                string fechaRegistracionCocinero = (string)HttpContext.Session.GetString("FechaRegistracionCocinero");
                List<Receta> ListaRecetas = _RecetaServicio.ObtenerRecetas(idCocinero);
                List<Evento> ListaEventos = _EventoServicio.ObtenerEventos(idCocinero);
                PerfilModel Perfil = new PerfilModel(emailCocinero, fechaRegistracionCocinero, ListaRecetas, ListaEventos);

                return View(Perfil);
            }
            else
            {
                return View("InjectionComensalError");
            }
        }

        public IActionResult Recetas()
        {
            if (puedeInjectar())
            {
                int idCocinero = (int)HttpContext.Session.GetInt32("IdUsuario");
                List<Receta> ListaRecetas = _RecetaServicio.ObtenerRecetas(idCocinero);
                return View(ListaRecetas);
            }
            else
            {
                return View("InjectionComensalError");
            }
        }

        [HttpPost]
        public IActionResult CrearReceta(RecetaModel recetaModel)
        {
            if (puedeInjectar())
            {
                if (ModelState.IsValid)
                {
                    Receta receta = recetaModel.RecetaModelToReceta((int)HttpContext.Session.GetInt32("IdUsuario"));
                    _RecetaServicio.Crear(receta);
                    @TempData["Resultado"] = "Nueva receta agregada";
                    return RedirectToAction("Recetas", "Cocinero");
                }
                TempData["Error"] = "No se pudieron grabar los datos";
                return View("Recetas");
            }
            else
            {
                return View("InjectionComensalError");
            }
        }

        [HttpGet]
        public IActionResult NuevaReceta()
        {
            if (puedeInjectar())
            {
                int idCocinero = (int)HttpContext.Session.GetInt32("IdUsuario");
                List<TipoReceta> ListaTipoRecetas = _tipoRecetaServicio.ObtenerTiposRecetas();
                List<TipoRecetaModel> listaTipoRecetas = ListaTipoRecetas.TipoRecetaToTipoRecetaModel();
                ViewBag.ListaTipoRecetas = listaTipoRecetas;
                return View("NuevaReceta");
            }
            else
            {
                return View("InjectionComensalError");
            }
        }
        
        public IActionResult CancelarReceta()
        {
            if (puedeInjectar())
            {
                int idCocinero = (int)HttpContext.Session.GetInt32("IdUsuario");
                List<Receta> ListaRecetas = MetodosExtendidos.CancelarRecetaRest(idCocinero);
                return View(ListaRecetas);
            }
            else
            {
                return View("InjectionComensalError");
            }
        }

        [HttpGet]
        public IActionResult BorrarReceta(int IdReceta)
        {
            if (puedeInjectar())
            {
                int IdCocinero = (int)HttpContext.Session.GetInt32("IdUsuario");

                var status = MetodosExtendidos.BorrarRecetaRest(IdReceta, IdCocinero);
                if (status)
                {
                    TempData["OK"] = "Se borro de forma satisfactoria";
                }
                else
                {
                    TempData["Error"] = "Error al borrar la receta";
                }

                return RedirectToAction("Perfil", "Cocinero");
            }
            else
            {
                return View("InjectionComensalError");
            }
        }
        
        public IActionResult Evento()
        {
            if (puedeInjectar())
            {
                int idCocinero = (int)HttpContext.Session.GetInt32("IdUsuario");
                List<Receta> ListaRecetas = _RecetaServicio.ObtenerRecetas(idCocinero);
                List<RecetaOpcionModel> listaRecetas = ListaRecetas.RecetaToRecetaOpcionModel();
                ViewBag.ListaRecetas = listaRecetas.Count() > 0 ? listaRecetas : null;
                return View();
            }
            else
            {
                return View("InjectionComensalError");
            }

        }
        
        [HttpPost]
        public async Task<IActionResult> Evento(EventoModel eventoModel)
        {
            if (puedeInjectar())
            {
                if (ModelState.IsValid)
                {
                    int idCocinero = (int)HttpContext.Session.GetInt32("IdUsuario");
                    // Guarda la foto del evento con el guid generado
                    Task<string> nombreFoto = eventoModel.Foto.GuardarFotoEvento(hostEnvironment.WebRootPath);
                    // Mapea el EventoModel al Evento
                    Evento evento = eventoModel.EventoModelToEvento(idCocinero, nombreFoto.Result);
                    // Persiste Evento en DB
                    int idEvento = _EventoServicio.Crear(evento);
                    // Obtiene ids de las recetas relacionadas al evento
                    List<int> listaRecetas = eventoModel.IdsRecetas;
                    // Relacion las recetas al evento
                    _EventoRecetaServicio.AsociarRecetasAEvento(idEvento, listaRecetas);
                    TempData["Resultado"] = $"evento guardado";
                    return RedirectToAction("Eventos", "Cocinero");

                }
                TempData["Error"] = $"No se pudieron grabar los datos";
                return View("Evento");
            }
            else
            {
                return View("InjectionComensalError");
            }
        }
        public IActionResult Eventos()
        {
            if (puedeInjectar())
            {
                int idCocinero = (int)HttpContext.Session.GetInt32("IdUsuario");
                List<Evento> cancelables = _EventoServicio.ObtenerEventosCancelables(idCocinero);
                if (cancelables.Count() == 0)
                {
                    TempData["hayEventos"] = "no";
                }
                return View(cancelables);
            }
            else
            {
                return View("InjectionComensalError");
            }
        }

        [HttpGet]
        public IActionResult CancelarEvento(int IdEvento)
        {
            if (puedeInjectar())
            {
                var status = MetodosExtendidos.CancelarEventoRest(IdEvento);
                if (status)
                {
                    TempData["OK"] = "Se cancelo el evento";
                }
                else
                {
                    TempData["Error"] = "No se pudo cancelar el evento";
                }

                return RedirectToAction("Eventos", "Cocinero");
            }
            else
            {
                return View("InjectionComensalError");
            }
        }
    }
}
