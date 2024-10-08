﻿using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        //Lista de productos centralizada en memoria 
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();


        //Hace una petición a la API de todos los productos
        public async Task GetProductsAsync()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<ProductModel>>>("api/product");
            if(result !=null && result.Data != null) 
            {
                Products = result.Data;
            }
        }

        //Pide un producto en función de la ID
        public async Task<ServiceResponse<ProductModel>> GetProductAsync(int productId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<ProductModel>>($"api/product/{productId}");
            return result;
        }

    }
}
