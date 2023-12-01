using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BlazorApp.Helpers;
using Serilog;
using BlazorApp.Services;

namespace Shabstec.BaggageSystem.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
         Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            // configure http client
            builder.Services.AddScoped(x => {
                var apiUrl = new Uri(builder.Configuration["apiUrl"]);
                return new HttpClient() { BaseAddress = apiUrl };
            });
            
            builder.Services
               .AddScoped<IAccountService, AccountService>()
               .AddScoped<IAlertService, AlertService>()
               .AddScoped<IHttpService, HttpService>()
               .AddScoped<ILocalStorageService, LocalStorageService>();
            await builder.Build().RunAsync();
        }
    }
}
