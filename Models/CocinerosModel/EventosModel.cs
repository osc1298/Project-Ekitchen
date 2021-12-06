using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ekitchen.Models.CocinerosModel
{
    public class EventoModel
    {
        public int IdCocinero { get; set; }

        [Required(ErrorMessage = "Debe Ingresar Nombre ")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe Seleccionar Fecha")]
        [DataType(DataType.Date)]
        public DateTime? Fecha { get; set; }

        [Required(ErrorMessage = "Debe Ingresar Cantidad de Comensales")]
        [RegularExpression("([0-9]+)", ErrorMessage = "El valor ingresado no es numerico")]
        public int CantidadComensales { get; set; }

        [Required(ErrorMessage = "Debe Ingresar Ubicacion")]
        public string Ubicacion { get; set; }

        [NotMapped]
        [DisplayName("Subir Foto..")]
        public IFormFile Foto { get; set; }

        [Required(ErrorMessage = "Debe Ingresar Precio")]
        public decimal Precio { get; set; }

        public int Estado { get; set; }

        [Required(ErrorMessage = "Debe Seleccionar al menos una receta")]
        public List<int> IdsRecetas { get; set; }
        
    }
}
