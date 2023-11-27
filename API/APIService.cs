using MauiApp1.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.API
{
    internal class APIService : IAPIService
    {
        private static string _baseURL;

        HttpClient httpClient = new HttpClient();



        public APIService()
        {

            _baseURL = "http://192.168.100.156:5149/";

            httpClient.BaseAddress = new Uri(_baseURL);

        }

        public async Task<Producto> CreateProducto(Producto newProduct)
        {

            var json = JsonConvert.SerializeObject(newProduct);

            var newProductJSON = new StringContent(json, Encoding.UTF8, "application/json");

            // Send a POST request to the API
            HttpResponseMessage response = await httpClient.PostAsync(_baseURL + "api/Producto", newProductJSON);

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to a list of Producto objects
                Producto productoModificado = JsonConvert.DeserializeObject<Producto>(content);

                return productoModificado;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

        }

        public async Task<string> DeleteProducto(int IdProducto)
        {

            // Send a GET request to the API
            HttpResponseMessage response = await httpClient.DeleteAsync(_baseURL + "api/Producto/" + IdProducto);

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string mensaje = await response.Content.ReadAsStringAsync();

                return mensaje;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

        }

        public async Task<List<Producto>> GetProducto()
        {

            // Send a GET request to the API
            HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "api/Producto");

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to a list of Producto objects
                List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(content);

                return productos;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

        }

        public async Task<Producto> GetProductoByID(int IdProducto)
        {

            // Send a GET request to the API
            HttpResponseMessage response = await httpClient.GetAsync(_baseURL + "api/Producto/" + IdProducto);

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to a list of Producto objects
                Producto productoEncontrado = JsonConvert.DeserializeObject<Producto>(content);

                return productoEncontrado;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }

        public async Task<Producto> UpdateProducto(Producto newProduct, int IdProducto)
        {

            var json = JsonConvert.SerializeObject(newProduct);

            var newProductJSON = new StringContent(json, Encoding.UTF8, "application/json");

            // Send a PUT request to the API
            HttpResponseMessage response = await httpClient.PutAsync(_baseURL + "api/Producto/" + IdProducto, newProductJSON);

            // Ensure the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                string content = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string to a list of Producto objects
                Producto productoModificado = JsonConvert.DeserializeObject<Producto>(content);

                return productoModificado;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }
    }
}
