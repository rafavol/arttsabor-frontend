using ArttSaborBlazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace ArttSaborBlazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            var lista = Environment.GetEnvironmentVariables().ToString();
            var backendPort = Environment.GetEnvironmentVariable("BACKEND_PORT");
            Console.WriteLine(@$"http://localhost:{backendPort}");
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(@$"http://localhost:{backendPort}") });

            await builder.Build().RunAsync();
        }
    }
}