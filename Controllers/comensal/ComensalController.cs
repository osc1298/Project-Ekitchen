using ekitchen.Entidades.EF;
using ekitchen.Models.ComensalesModel;
using ekitchen.Models.ComentariosModel;
using ekitchen.Models.Mappings;
using ekitchen.Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ekitchen.Controllers.comensal
{
    public class ComensalController : Controller
    {
        private IReservaServicio _ServicioReserva;
        private IEventoServicio _ServicioEvento;
        private ICalificacioneServicio _ServicioCalificacione;
        public ComensalController(IReservaServicio ServicioReserva, IEventoServicio servicioEvento, ICalificacioneServicio servicioCalificacione)
        {
            _ServicioReserva = ServicioReserva;
            _ServicioEvento = servicioEvento;
            _ServicioCalificacione = servicioCalificacione;
        }

        public Boolean puedeInjectar()
        {
            if (HttpContext.Session.GetInt32("IdUsuario") != null &&
               HttpContext.Session.GetInt32("Perfil") == 2)
            {
                return true;
            }
            return false;

        }

        public IActionResult Index()
        {
            if (puedeInjectar())
            {
                int idComensal = (int)HttpContext.Session.GetInt32("IdUsuario");
                List<Evento> EventosComensal = _ServicioReserva.ObtenerMisReservasPorId(idComensal);
                List<EventoComentarioModel> EventosComentarios = EventosComensal.EventoToEventoComentarioModel();
                return View(EventosComentarios);
            }
            else
            {
                return View("InjectionCocineroError");
            }
        }

     
        
        public IActionResult Reserva()
        {
            if (puedeInjectar())
            {
                return View(_ServicioReserva.EventosDisponibles());
            }
            else
            {
                return View("InjectionCocineroError");
            }
        }

        [HttpGet]
        [Route("Comensal/Reservar/{idEvento}")]
        public IActionResult Reserva(int idEvento)
        {
            if (puedeInjectar())
            {
                ReservaModel reservaModel = new ReservaModel();
                // Obtiene lista de recetas del evento
                List<Receta> listaRecetas = _ServicioReserva.obtenerEventoPorId(idEvento);
                // Mapea las recetas al model de receta de Comensal
                List<ComensalRecetaOpcionModel> recetas = listaRecetas.RecetaToComensalRecetaOpcionModel();
                // Setea la lista de recetas model de comensal para el formulario
                ViewBag.ListaRecetas = recetas;
                reservaModel.IdEvento = idEvento;

                return View("EventoAReservar", reservaModel);
            }
            else
            {
                return View("InjectionCocineroError");
            }
        }

        public IActionResult GuardarReserva(ReservaModel reservaModel)
        {
            if (puedeInjectar())
            {
                int idComensal = (int)HttpContext.Session.GetInt32("IdUsuario");
                Boolean registro=_ServicioReserva.registrarReserva(reservaModel.IdEvento, idComensal, reservaModel.RecetaSeleccionada, reservaModel.CantidadComensales);
                if (registro)
                {
                    TempData["Reseva"] = "Reserva realizada con éxito";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "La cantidad de comensales que indicaste supera la capacidad que tenemos";
                    return RedirectToAction("Reserva");
                }
            }
            else
            {
                return View("InjectionCocineroError");
            }
        }

        //este vendria hacer donde si entras a mis comentarios te muestra los comentarios que hiciste//
       public IActionResult Comentarios()
        {
            if (puedeInjectar())
            {
                int idComensal = (int)HttpContext.Session.GetInt32("IdUsuario");
                //aqui tuve que buscar los eventos y las calificaciones para poder recorrerlos//
                //y rellenar la informacion de todos los eventos que comento//
                ViewBag.Evento = _ServicioReserva.ObtenerMisReservasPorId(idComensal);
                return View("IndexComentarios", _ServicioCalificacione.obtenerMisCalificaciones(idComensal));
            }
            else
            {
                return View("InjectionCocineroError");
            }

        }

        //aqui te direcciona cuando desde la vista de mis reservas queres comentar//
        [HttpGet]
        [Route("Comensal/Comentar/{idEvento}")]
        public IActionResult Comentar(int idEvento)
        {
            if (puedeInjectar())
            {
                int IdComensal = (int)HttpContext.Session.GetInt32("IdUsuario");

                ViewBag.idevento = idEvento;
                return View("Comentarios");
            }
            else
            {
                return View("InjectionCocineroError");
            }
        }


        //aqui es donde se llama al metodo para guardar el comentario de dicho evento
        [HttpPost]
        public IActionResult Comentario(ComentarioModel comentarioModel)
        {
            if (puedeInjectar())
            {
                if (ModelState.IsValid)
                {
                    int idComensal = (int)HttpContext.Session.GetInt32("IdUsuario");
                    Calificacione comentario = comentarioModel.ComentariosModelToCalificacione(idComensal);
                    if (_ServicioCalificacione.RegistrarCalificacion(comentario) == true)
                    {
                        @TempData["ComentarioCreado"] ="Comentario guardado";
                        return RedirectToAction("Comentarios");
                    }
                    else
                    {
                        return RedirectToAction("Comentar", comentario.IdEvento);
                    }
                }
                else
                {
                    return RedirectToAction("Comentar", comentarioModel.IdEvento);
                }
            }
            else
            {
                return View("InjectionCocineroError");
            }
        }

    }
}
