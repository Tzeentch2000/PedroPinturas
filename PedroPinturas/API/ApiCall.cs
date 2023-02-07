using System.Text.Json;
using System.Net.Http.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using PedroPinturas.Models;

//SI QUIERO QUE NO ME MAPEE [NotMapped]
public class ApiCall{

    //Que ignore
    JsonSerializerOptions options = new JsonSerializerOptions() {
        PropertyNameCaseInsensitive = true
    };

    public async Task api(){
        var url = "http://localhost:5257/colores";
        using(var httpClient = new HttpClient()){
    /*var response = await httpClient.GetAsync(url);
    if(response.IsSuccessStatusCode){
        var content = await response.Content.ReadAsStreamAsync();
        List<Color>? colors = JsonSerializer.Deserialize<List<Color>>(content, options);
        foreach(var color in colors){
            Console.WriteLine(color.Name);
        }
    }*/
    var response = await httpClient.PostAsJsonAsync(url,new Color{Name="Blanco",Code="#FFF"});
    if(response.IsSuccessStatusCode)
        Console.WriteLine("Color agregado");
    else 
        Console.WriteLine("Error");
    /*var response = await httpClient.PutAsJsonAsync(url,new Color{Name="Blanco",Code="#FFF"});
    if(response.IsSuccessStatusCode)
        Console.WriteLine("Color agregado");
    else 
        Console.WriteLine("Error");*/

    /*var response = await httpClient.DeleteAsync(url);
    if(response.IsSuccessStatusCode)
        Console.WriteLine("Color agregado");
    else 
        Console.WriteLine("Error");
    */
    
    }

    Console.WriteLine("Hello, World!");
    }

}