using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;

namespace LojaVirtual.WebApp.MVC.Tests.Configuracao
{
    public class IntegrationTestsFixture<TStartup> : IDisposable where TStartup : class
    {
        public readonly LojaVirtualAplicacaoFactory<TStartup> factory;
        public HttpClient client;

        public IntegrationTestsFixture()
        {
            var clientOptions = new WebApplicationFactoryClientOptions
            {
            };

            factory = new LojaVirtualAplicacaoFactory<TStartup>();
            client = factory.CreateClient();
        }

        public void Dispose()
        {
            factory?.Dispose();
            client?.Dispose();
        }
    }
}