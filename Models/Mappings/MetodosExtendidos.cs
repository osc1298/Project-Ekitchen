using ekitchen.Entidades.EF;
using ekitchen.Models.CocinerosModel;
using ekitchen.Models.UsuariosModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using ekitchen.Models.ComensalesModel;
using ekitchen.Models.EventosModel;
using System.Security.Cryptography;
using RestSharp;
using Newtonsoft.Json;
using ekitchen.Models.ComentariosModel;

namespace ekitchen.Models.Mappings
{
    public static class MetodosExtendidos
    {
        
        public static Usuario UsuarioModelToUsuario(this UsuarioModel userModel)
        {
                Usuario usuario = new Usuario();
                usuario.Nombre = userModel.Nombre;
                usuario.Email = userModel.Email;
                usuario.Password = userModel.Password;//Aca se llamaba al metodo encriptador pero el tamaño en la db es de 30 caracteres
                usuario.Perfil = int.Parse(userModel.Perfil);
                usuario.FechaRegistracion = DateTime.Today;

                return usuario;   
        }

        public static Receta RecetaModelToReceta(this RecetaModel recetaModel,int idCocinero)
        {
            Receta receta = new Receta();
            receta.IdCocinero = idCocinero;
            receta.Nombre = recetaModel.Nombre;
            receta.TiempoCoccion = recetaModel.TiempoCoccion;
            receta.Descripcion = recetaModel.Descripcion;
            receta.Ingredientes = recetaModel.Ingredientes;
            receta.IdTipoReceta = recetaModel.IdTipoReceta;

            return receta;
        }

        public static Evento EventoModelToEvento(this EventoModel eventoModel, int idCocinero, string nombreFoto)
        {
            
            Evento evento = new Evento();
            evento.IdCocinero = idCocinero;
            evento.Nombre = eventoModel.Nombre;
            evento.Fecha = (DateTime)eventoModel.Fecha;
            evento.CantidadComensales = eventoModel.CantidadComensales;
            evento.Ubicacion = eventoModel.Ubicacion;
            evento.Foto = nombreFoto;
            evento.Precio = eventoModel.Precio;
            evento.Estado = 1;

            return evento;
        }

        public static async Task<string> GuardarFotoEvento(this IFormFile fotoFile, string WebRootPath)
        {
            Guid guid = Guid.NewGuid();

            string fotoPath = WebRootPath;
            string fotoNombre = guid.ToString();
            string fotoExtension = Path.GetExtension(fotoFile.FileName);
            fotoNombre = fotoNombre + fotoExtension;
            string path = Path.Combine(fotoPath + "/images/carrousel", fotoNombre);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await fotoFile.CopyToAsync(fileStream);
            }

            return fotoNombre;
        }

        public static List<TipoRecetaModel> TipoRecetaToTipoRecetaModel(this List<TipoReceta> tiposRecetas)
        {

            List<TipoRecetaModel> listaTipoRecetas = new List<TipoRecetaModel>();
            foreach (var rece in tiposRecetas)
            {
                TipoRecetaModel tr = new TipoRecetaModel();
                tr.Id = rece.IdTipoReceta;
                tr.Descripcion = rece.Nombre;
                listaTipoRecetas.Add(tr);
            }

            return listaTipoRecetas;
        }

        public static List<RecetaOpcionModel> RecetaToRecetaOpcionModel(this List<Receta> recetas)
        {

            List<RecetaOpcionModel> listaRecetas = new List<RecetaOpcionModel>();
            foreach (var rece in recetas)
            {
                RecetaOpcionModel r = new RecetaOpcionModel();
                r.IdReceta = rece.IdReceta;
                r.Descripcion = rece.Descripcion;
                listaRecetas.Add(r);
            }

            return listaRecetas;
        }

        public static List<ComensalRecetaOpcionModel> RecetaToComensalRecetaOpcionModel(this List<Receta> listaRecetas)
        {
           List<ComensalRecetaOpcionModel> recetas = new List<ComensalRecetaOpcionModel>();
            
            foreach (var r in listaRecetas)
            {
                ComensalRecetaOpcionModel opcion = new ComensalRecetaOpcionModel();
                opcion.IdReceta = r.IdReceta;
                opcion.Descripcion = r.Descripcion;
                recetas.Add(opcion);
            }

            return recetas;
        }

        public static List<EventoPuntuacionModel> ListaEventosToListaEventoPuntuacionModel(this List<Evento> listaEventos)
        {
            List<EventoPuntuacionModel> listaEventoPuntuacionModel = new List<EventoPuntuacionModel>();
            foreach (var evento in listaEventos)
            {
                int suma = 0;
                double promedio = 0.0;
                EventoPuntuacionModel eventoPuntuacionModel = new EventoPuntuacionModel();
                eventoPuntuacionModel.IdEvento = evento.IdEvento;
                eventoPuntuacionModel.Nombre = evento.Nombre;
                eventoPuntuacionModel.Foto = evento.Foto;
                eventoPuntuacionModel.Precio = evento.Precio;
                foreach (Calificacione ca in evento.Calificaciones)
                {
                    suma += ca.Calificacion;
                }
                promedio = (suma / (double) evento.Calificaciones.Count());
                eventoPuntuacionModel.Puntiacion = promedio;
                listaEventoPuntuacionModel.Add(eventoPuntuacionModel);
            }
            return listaEventoPuntuacionModel;
        }
        public static string encriptar(string text)
        {
            string resultado = "";
            SHA256CryptoServiceProvider x1 = new SHA256CryptoServiceProvider();

            byte[] bs1 = System.Text.Encoding.UTF8.GetBytes(text);
            bs1 = x1.ComputeHash(bs1);
            System.Text.StringBuilder s1 = new System.Text.StringBuilder();

            foreach (byte b in bs1)
            {
                s1.Append(b.ToString("x2").ToLower());
            }
            resultado = s1.ToString();

            return resultado;
        }

        public static List<Receta> ObtenerRecetasRest(int IdCocinero)
        {
            var client = new RestClient($"https://localhost:44315/Receta?IdCocinero={IdCocinero}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var lista = JsonConvert.DeserializeObject<List<Receta>>(response.Content);
            List<Receta> ListaRecetas = lista.ToList();
            return ListaRecetas;
        }

        public static List<Receta> CancelarRecetaRest(int IdCocinero)
        {
            var client = new RestClient($"https://localhost:44315/Receta?IdCocinero={IdCocinero}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var lista = JsonConvert.DeserializeObject<List<Receta>>(response.Content);
            List<Receta> ListaRecetas = lista.ToList();
            return ListaRecetas;
        }

        public static bool BorrarRecetaRest(int IdReceta,int IdCocinero)
        {
            var client = new RestClient($"https://localhost:44315/Receta/BorrarReceta/{IdCocinero}/{IdReceta}");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<Boolean>(response.Content);

        }

        public static bool CancelarEventoRest(int IdEvento)
        {
            var client = new RestClient($"https://localhost:44315/Evento/CancelarEvento/{IdEvento}");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            IRestResponse response = client.Execute(request);
            return JsonConvert.DeserializeObject<Boolean>(response.Content);

        }

        public static Calificacione ComentariosModelToCalificacione(this ComentarioModel comentarioModel, int IdComensal)
        {
            Calificacione comentarios = new Calificacione();
            comentarios.IdComensal = IdComensal;
            comentarios.IdEvento = comentarioModel.IdEvento;
            comentarios.Calificacion = comentarioModel.Calificacion;
            comentarios.Comentarios = comentarioModel.Comentarios;

            return comentarios;
        }

        public static EventoDetalle BuildEventoDetalleModel(Evento evento, Usuario cocinero, List<Calificacione> calificaciones)
        {
            EventoDetalle eventoDetalles = new EventoDetalle();

            eventoDetalles.Foto = evento.Foto;
            eventoDetalles.Nombre = evento.Nombre;
            eventoDetalles.Precio = evento.Precio;
            eventoDetalles.NombreCocinero = cocinero.Nombre;
            eventoDetalles.Calificacione = calificaciones;

            return eventoDetalles;
        }

        public static List<EventoComentarioModel> EventoToEventoComentarioModel(this List<Evento> EventosComensal)
        {

            List<EventoComentarioModel> EventosComentarios = new List<EventoComentarioModel>();
            foreach (var evento in EventosComensal)
            {
                EventoComentarioModel ec = new EventoComentarioModel();
                ec.IdEvento = evento.IdEvento;
                ec.Nombre = evento.Nombre;
                ec.Fecha = evento.Fecha;
                ec.Estado = evento.Estado;
                ec.CantidadCalificaciones = evento.Calificaciones.Count();
                EventosComentarios.Add(ec);
            }

            return EventosComentarios;
        }
    }
}
