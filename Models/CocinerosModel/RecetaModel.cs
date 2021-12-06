using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ekitchen.Models.CocinerosModel
{
    public class RecetaModel
    {
        public int IdCocinero { get; set; }

        [Required(ErrorMessage = "Debe Ingresar Nombre ")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe Ingresar Tiempo de Coccion ")]
        [RegularExpression("([0-9]+)", ErrorMessage = "El valor ingresado no es numerico")]
        public int TiempoCoccion { get; set; }

        [Required(ErrorMessage = "Debe Ingresar Descripcion ")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Debe Ingresar Ingredientes ")]
        public string Ingredientes { get; set; }

        [Required(ErrorMessage = "Debe Seleccionar Tipo de Receta ")]
        public int IdTipoReceta { get; set; }


    }
}
