using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ekitchen.Entidades.EF;
using ekitchen.Servicios.Interfaces;
using Newtonsoft.Json;

namespace ekitchen.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecetaController : ControllerBase
    {
        private IRecetaServicio _RecetaServicio;
        public RecetaController(IRecetaServicio recetaServicio)
        {
            _RecetaServicio = recetaServicio;
        }

        [HttpGet]
        public IEnumerable<Receta> Get(int IdCocinero)
        {
            return _RecetaServicio.ObtenerRecetas(IdCocinero).ToArray();
        }

        [HttpPost]
        [Route ("/Receta/BorrarReceta/{IdCocinero}/{IdReceta}")]
        public String BorrarReceta(int IdCocinero,int IdReceta)
        {
            return JsonConvert.SerializeObject(_RecetaServicio.BorrarReceta(IdCocinero, IdReceta));
        }
    }
}
