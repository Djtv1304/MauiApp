using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.API
{
    internal interface IAPIService
    {

        Task<List<Producto>> GetProducto();

        Task<Producto> CreateProducto(Producto newProduct);

        Task<Producto> GetProductoByID(int IdProducto);

        Task<Producto> UpdateProducto(Producto newProduct, int IdProducto);

        Task<string> DeleteProducto(int IdProducto);

    }
}
