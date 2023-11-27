using MauiApp1.API;
using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Utils
{
    internal class Utils
    {

        static public APIService _APIService = new APIService();

        static public List<Producto> ListaProductos = new List<Producto>()
        {
            new Producto
            {
                IdProducto = 1,
                Nombre = "p1",
                Descripcion = "D1",
                Cantidad = 1
            },

            new Producto
            {
                IdProducto = 2,
                Nombre = "p2",
                Descripcion = "D1",
                Cantidad = 2
            },

            new Producto
            {
                IdProducto = 3,
                Nombre = "p3",
                Descripcion = "D1",
                Cantidad = 3
            },

            new Producto
            {
                IdProducto = 4,
                Nombre = "p4",
                Descripcion = "D1",
                Cantidad = 4
            }

        };
    }
}
