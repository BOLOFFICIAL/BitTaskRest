using Newtonsoft.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        string res = GetString("https://localhost:44315/Currencies");

        Console.WriteLine(res);
        List<Currency> currencies = JsonConvert.DeserializeObject<List<Currency>>(res);
        foreach (var el in currencies)
        {
            Console.WriteLine(el.Name);
        }
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

public class Currency
{
    public string Name { get; set; }
    public int Id { get; set; }
}