using Newtonsoft.Json;
using TestTask.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var data = GetHousesCities(1);
        foreach (var el in data) 
        {
            Console.WriteLine(el);
        }
    }

    public static List<Cities> GetCities() 
    {
        string data = GetString("https://localhost:44315/cities");
        List<Cities>? cities = JsonConvert.DeserializeObject<List<Cities>>(data);
        return cities;
    }
    public static List<Streets> GetStreets(int city_id)
    {
        string data = GetString($"https://localhost:44315/cities/{city_id}/streets");
        List<Streets>? streets = JsonConvert.DeserializeObject<List<Streets>>(data);
        return streets;
    }
    public static List<Houses> GetHousesCities(int city_id)
    {
        string data = GetString($"https://localhost:44315/cities/{city_id}/houses");
        List<Houses>? houses = JsonConvert.DeserializeObject<List<Houses>>(data);
        return houses;
    }
    public static List<Houses> GetHousesStreets(int street_id)
    {
        string data = GetString($"https://localhost:44315/streets/{street_id}/houses");
        List<Houses>? houses = JsonConvert.DeserializeObject<List<Houses>>(data);
        return houses;
    }
    public static List<Houses> GetHousesFull(int city_id, int street_id)
    {
        string data = GetString($"https://localhost:44315/streets/{street_id}/houses");
        List<Houses>? houses = JsonConvert.DeserializeObject<List<Houses>>(data);
        return houses;
    }

    public static string GetString(string url)
    {
        string res = "";
        try
        {
            using (var client = new HttpClient())
            {
                res = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            }
        }
        catch (Exception)
        {
            res = "ErrorConnection";
        }
        return res;
    }
}
