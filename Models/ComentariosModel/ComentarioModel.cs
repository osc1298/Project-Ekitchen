using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ekitchen.Models.ComentariosModel
{
    public class ComentarioModel
    {

        public int IdEvento { get; set; }
        public int IdComensal { get; set; }
        [Required(ErrorMessage ="ingrese una calificacion entre 1 a 5")]
        [Range(typeof(int),"1","5")]
        public int Calificacion { get; set; }
        [Required(ErrorMessage = "Debe Ingresar un comentario")]
        public string Comentarios { get; set; }

    }
}
