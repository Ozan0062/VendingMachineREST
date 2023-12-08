using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

public class SMS
{
    public static async Task SendMessage()
    {
        string username = "+4540688969";
        string password = "zZBhFeKR";
        string tophonenumberwithcountrycode = "+4560532652";
        string fromMax11Char = "Vending Machine";
        string theMessage = $"Dit kodeord er: {password}";

        try
        {
            // Opret URL med parametre
            string pathtouse = $"https://api.suresms.com/Script/SendSMS.aspx?login={username}&password={password}&to={tophonenumberwithcountrycode}&from={fromMax11Char}&Text={WebUtility.UrlEncode(theMessage)}";

            // Lav en webanmodning
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(pathtouse);

                // Håndter responsen efter behov (kan tilpasses efter API'ets krav)
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("SMS sendt med succes.");
                }
                else
                {
                    Console.WriteLine($"Fejl ved afsendelse af SMS. Statuskode: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fejl ved afsendelse af SMS: {ex.Message}");
        }
    }
}
