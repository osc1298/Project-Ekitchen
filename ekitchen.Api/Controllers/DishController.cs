using ekitchen.Entidades.Dishes;
using ekitchen.Servicios.Dishes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ekitchen.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DishController : ControllerBase
    {
        
        [HttpGet]
        public IEnumerable<Dish> Get()
        {
            return DishServicio.ObtenerListaPlatos().ToArray();
        }
    }
}
