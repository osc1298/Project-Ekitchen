using ekitchen.Entidades.Dishes;
using ekitchen.Entidades.EF;
using ekitchen.Models.EventosModel;
using ekitchen.Models.Mappings;
using ekitchen.Servicios.Dishes;
using ekitchen.Servicios.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace ekitchen.Controllers.inicio
{

    public class DefaultController : Controller
    {
        //private readonly ILogger<InicioController> _logger;
        private readonly IWebHostEnvironment _appEnvironment;
        private IEventoServicio _eventoServicio;
        private ICalificacioneServicio _calificacioneServicio;
        
        public DefaultController(IWebHostEnvironment appEnvironment, IEventoServicio eventoServicio, ICalificacioneServicio calificacioneServicio)
        {
            _appEnvironment = appEnvironment;
            _eventoServicio = eventoServicio;
            _calificacioneServicio = calificacioneServicio;
        }

        public IActionResult Index()
        {
            
          //  var client = new RestClient("https://localhost:44315/Evento/EventosConComentarios");
          //  client.Timeout = -1;
          //  var request = new RestRequest(Method.GET);
          //  var body = @"";
          //  request.AddParameter("text/plain", body, ParameterType.RequestBody);
          //  IRestResponse response = client.Execute(request);
          //  var lista = JsonConvert.DeserializeObject<List<Evento>>(response.Content);
            List<Evento> ListaEventos = _eventoServicio.ObtenerEventosFinalizadosConComentarios();
            List<EventoPuntuacionModel> eventoPuntuacionModels = ListaEventos.ListaEventosToListaEventoPuntuacionModel();
            return View(eventoPuntuacionModels);
        }

        public IActionResult DetalleEvento(int IdEvento)
        {
            Evento evento = _eventoServicio.ObtenerEventoPorId(IdEvento);
            Usuario usuario = _eventoServicio.ObtenerCocineroPorId(evento.IdCocinero);
            List<Calificacione> calificaciones = _calificacioneServicio.ObtenerCalificacionesPorIdEvento(IdEvento);

            EventoDetalle eventoDetalles = MetodosExtendidos.BuildEventoDetalleModel(evento, usuario, calificaciones);
            return View(eventoDetalles);
        }

       
    }
}