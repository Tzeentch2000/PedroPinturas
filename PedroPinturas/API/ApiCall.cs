using System.Text.Json;
using System.Net.Http.Json;
using System.Net.Http;
using System.Threading.Tasks;

//SI QUIERO QUE NO ME MAPEE [NotMapped]
public static class ApiCall
{

    //Que ignore
    static JsonSerializerOptions options = new JsonSerializerOptions()
    {
        PropertyNameCaseInsensitive = true
    };

    // Insertar!!!
    public static async Task<bool> Insertar<T>(string url, T entity) where T : class
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.PostAsJsonAsync(url, entity);
            return response.IsSuccessStatusCode;
        }
    }

}