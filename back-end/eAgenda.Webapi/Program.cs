using eAgenda.Infra.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace eAgenda.Webapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfiguracaoLogseAgenda.ConfigurarEscritaLogs();

            Log.Logger.Information("Iniciando o servidor da aplica��o e-Agenda...");

            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception exc)
            {
                Log.Logger.Fatal(exc, "O servidor da aplica��o e-Agenda parou inesperadamente.");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
