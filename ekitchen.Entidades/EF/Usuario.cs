using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace ekitchen.Entidades.EF
{
    public partial class Usuario
    {
        public Usuario()
        {
            Calificaciones = new HashSet<Calificacione>();
            Eventos = new HashSet<Evento>();
            Reservas = new HashSet<Reserva>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }


       

        [Required(ErrorMessage = "Debe Ingresar un Correo Electronico Valido ")]
        [EmailAddress(ErrorMessage = "No respeta el formato de correo electronico.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Clave Incorrecta ")]


        public string Password { get; set; }
        public int Perfil { get; set; }
        public DateTime FechaRegistracion { get; set; }

        public virtual ICollection<Calificacione> Calificaciones { get; set; }
        public virtual ICollection<Evento> Eventos { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
