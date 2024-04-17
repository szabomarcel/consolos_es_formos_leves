using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _consolos_leves_
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await levesekadatok();
            Console.ReadKey();
        }
        private static async Task levesekadatok()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/_levesek_vizsgaszeru_/backendleves/index.php?leves");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();            
            var levesek = JsonConvert.DeserializeObject<Levesek[]>(responseContent);
            Levesek maxKaloriaLeves = levesek[0];
            foreach (var leves in levesek)
            {
                if (leves.Kaloria > maxKaloriaLeves.Kaloria)
                {
                    maxKaloriaLeves = leves;
                }
            }
            Console.WriteLine($"A legnagyobb kalóriatartalmú leves: {maxKaloriaLeves.Megnevezes} ({maxKaloriaLeves.Kaloria} kalória)");
            Console.WriteLine(await response.Content.ReadAsStringAsync());

        }
    }
}
