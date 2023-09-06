using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Respiri.BusinessModels.Dto;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Respiri.Console
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GetApiBaseUrl());

                    var message = await client.GetStringAsync("/api/Person/GetVersion");
                    System.Console.WriteLine(message);


                    var person = await client.GetFromJsonAsync<GetPersonByIdDto>("/api/Person/1");
                    System.Console.WriteLine(JsonConvert.SerializeObject(person));

                    var people = await client.GetFromJsonAsync<List<GetPersonDto>>("/api/Person");
                    System.Console.WriteLine(JsonConvert.SerializeObject(people));
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                System.Console.WriteLine(ex.StackTrace);
            }

            System.Console.Read();
        }

        static string GetApiBaseUrl()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json");

            var config = configuration.Build();
            var baseUrl = config["RespiriApi:BaseUrl"];

            return baseUrl;
        }
    }
}