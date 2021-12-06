using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ekitchen.Entidades.Dishes;


namespace ekitchen.Servicios.Dishes
{
    public class DishServicio
    {
        public static List<Dish> ObtenerListaPlatos()
        {

            List<Dish> lista = new List<Dish>();

            lista.Add(new Dish() { Id = 1, Descripcion = "Tortellini Ricotta y Espinacas con manzana y salchicha", UrlImage = "TortelliniRicottayEspinacasconmanzanaysalchicha.jpg" });
            lista.Add(new Dish() { Id = 2, Descripcion = "Tortellini Ricotta y Espinacas con atun y tomate seco", UrlImage = "TortelliniRicottayEspinacasConAtunyTomateSeco.jpg" });
            lista.Add(new Dish() { Id = 3, Descripcion = "Ravioli Bio Espinaca, Ricotta y Burrata", UrlImage = "RavioliBioEspinacaRicottayBurrata.jpg" });
            lista.Add(new Dish() { Id = 4, Descripcion = "Tortellini Ricotta y Espinacas con Pimientos", UrlImage = "TortelliniRicottayEspinacasConPimientos.jpg" });
            lista.Add(new Dish() { Id = 5, Descripcion = "Ensalada de Ravioli Bio ", UrlImage = "EnsaladaRavioliBio.jpg" });
            lista.Add(new Dish() { Id = 6, Descripcion = "Ravioli Bio Ricotta y Burrata con Ragu de Verduras", UrlImage = "RavioliBioRicottaBurrataRaguVerduras.jpg" });
            lista.Add(new Dish() { Id = 7, Descripcion = "Ravioli Gorgonzola y Speck Salsa de Setas", UrlImage = "RavioliGorgonzolaSpeckSalsaSetas.jpg" });
            lista.Add(new Dish() { Id = 8, Descripcion = "Ravioli 4 Quesos Salsa Gorgonzola y Longaniza", UrlImage = "Ravioli4QuesosGorgonzolaLonganiza.jpg" });

            return lista;
        }
    }
}
