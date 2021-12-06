using ekitchen.Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using ekitchen.Entidades.EF;
namespace ekitchen.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private IEventoServicio _EventoServicio;
        public EventoController(IEventoServicio eventoServicio)
        {
            _EventoServicio = eventoServicio;
        }

        [HttpPost]
        [Route("/Evento/CancelarEvento/{IdEvento}")]
        public String CancelarEvento(int IdEvento)
        {
            Boolean resultado = _EventoServicio.CancelarEvento(IdEvento);
            return JsonConvert.SerializeObject(resultado);
        }

        [HttpGet]
        [Route("/Evento/EventosConComentarios")]
        public IEnumerable<Evento> Get()
        {
            return _EventoServicio.ObtenerEventosFinalizadosConComentarios().ToArray();
        }

    }
}
