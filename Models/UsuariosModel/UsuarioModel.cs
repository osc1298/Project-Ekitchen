using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ekitchen.Models.UsuariosModel
{
    public class UsuarioModel
    {

       
        [Required(ErrorMessage = "Debe Ingresar Nombre ")]
        public String Nombre { get; set; }

        [Required(ErrorMessage = "Debe Ingresar Email ")]
        [EmailAddress(ErrorMessage = "Debe Ingresar un correo electronico.")]
        public String Email { get; set; }

        //[RegularExpression(@"^(?=.*[A-Za-z])^[A-Z](?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "solo mayúsuclas para {0}")]
        [Required(ErrorMessage = "Debe Ingresar Password ")]
        public String Password { get; set; }

        [Required(ErrorMessage = "Debe confirmarPassword ")]
        [Compare("Password", ErrorMessage = "El password no coincide")]
        public String ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Debe elegir un perfil ")]
        public String Perfil { get; set; }
    }
}
