using LojaVirtual.WebApp.MVC.Tests.Configuracao;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace LojaVirtual.WebApp.MVC.Tests
{
    public class CategoriaTests : IClassFixture<IntegrationTestsFixture<StartupMVCTests>>
    {
        private readonly IntegrationTestsFixture<StartupMVCTests> _integrationTestsFixture;

        public CategoriaTests(IntegrationTestsFixture<StartupMVCTests> integrationTestsFixture)
        {
            _integrationTestsFixture = integrationTestsFixture;
        }

        [Fact(DisplayName = "Realizar cadastro com sucesso")]
        [Trait("Categoria", "Integração Web - Categoria")]
        public async Task Categoria_RealizarCadastro_DeveExecutarComSucesso()
        {
            var teste = await _integrationTestsFixture.client.GetAsync("/adicionar-categoria");
            // Arrange
            var dadosFormulario = new Dictionary<string, object>
            {
                { "Nome", "Nova categoria"},
                { "Codigo", "020"}
            };

            // Act

            // Assert

        }
    }
}