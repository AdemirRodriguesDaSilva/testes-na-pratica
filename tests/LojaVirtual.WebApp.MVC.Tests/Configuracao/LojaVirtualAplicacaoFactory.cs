using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace LojaVirtual.WebApp.MVC.Tests.Configuracao
{
    public class LojaVirtualAplicacaoFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseStartup<TStartup>();
            builder.UseEnvironment("DefaultConnection"); // buscar a configuração de conexão do teste
        }

        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return base.CreateWebHostBuilder()
                .UseStartup<TStartup>()
                .UseEnvironment("DefaultConnection");// buscar a configuração de conexão do teste;
        }
    }
}