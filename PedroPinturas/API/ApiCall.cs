using System.Text.Json;
using System.Net.Http.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;
using System.Reflection;
using PedroPinturas.Models;

public static class ApiCall
{

    //Que ignore
    static JsonSerializerOptions options = new JsonSerializerOptions()
    {
        PropertyNameCaseInsensitive = true
    };

    // Getear!!!
    public static async Task<List<T>> Get<T>(string url) where T : class
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStreamAsync();
                List<T>? entitys = JsonSerializer.Deserialize<List<T>>(content, options);
                return entitys;
            }
            else
            {
                return null;
            }
        }
    }

    // Getear!!!
    public static async Task<T> GetParamas<T>(string url) where T : new() 
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStreamAsync();
                T entity = JsonSerializer.Deserialize<T>(content, options);
                return entity;
            }
            else
            {
                // NO PUEDO DEVOLVER NULL
                return new T();
            }
        }
    }

    // Getear!!!
    public static async Task<List<T>> GetParamasList<T>(string url) where T : new()
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStreamAsync();
                List<T> entity = JsonSerializer.Deserialize<List<T>>(content, options);
                return entity;
            }
            else
            {
                // NO PUEDO DEVOLVER NULL
                return new List<T>();
            }
        }
    }

    // Insertar!!!
    public static async Task<bool> Post<T>(string url, T entity) where T : class
    {
        using (var httpClient = new HttpClient())
        {
            string jsonString = JsonSerializer.Serialize(entity);
            var response = await httpClient.PostAsJsonAsync(url, entity);
            Console.WriteLine(response.ToString());
            return response.IsSuccessStatusCode;
        }
    }

    // Login!!!
    public static async Task<int> Login(string url, Usuario entity)
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.PostAsJsonAsync(url, entity);
            var customerJsonString = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Your response data is: " + customerJsonString);
            var deserialized = JsonSerializer.Deserialize<int>(customerJsonString)!;
            return deserialized;
        }
    }

    // CheckProduct!!!
    public static async Task<T> Check<T>(string url, T entity) where T : class
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.PostAsJsonAsync(url, entity);
            var customerJsonString = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Encontrado!: " + customerJsonString);
            var deserialized = JsonSerializer.Deserialize<T>(customerJsonString,options);
            return deserialized;
        }
    }

    // Compras!!!
    public static async Task<List<Compra>> Compras(string url, List<Compra> compras)
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.PostAsJsonAsync(url, compras);
            var customerJsonString = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Your response data is: " + customerJsonString);
            var deserialized = JsonSerializer.Deserialize<List<Compra>>(customerJsonString)!;
            return deserialized;
        }
    }
}