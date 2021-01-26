using LojaVirtual.Core.DomainObject;
using System;
using Xunit;

namespace LajaVirtual.Core.Tests
{
    public class ValidacoesTests
    {
        [Fact(DisplayName = "Valores são iguais")]
        [Trait("Categoria", "Validar se igual")]
        public void ValidarSeIgual_Valor1EhIgualAoValor2_DeveRetornarExcecao()
        {
            // Arrange
            var guid1 = Guid.NewGuid();
            var guid2 = guid1;

            // Act & Assert
            Assert.NotNull(Record.Exception(() => Validacoes.ValidarSeIgual(guid1, guid2, "Mensagem de teste")));
        }

        [Fact(DisplayName = "Valores são diferentes")]
        [Trait("Categoria", "Validar se igual")]
        public void ValidarSeIgual_ValorNaoEhIgualAoValor2_NaoDeveRetornarExcecao()
        {
            // Arrange
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();

            // Act & Assert
            Assert.Null(Record.Exception(() => Validacoes.ValidarSeIgual(guid1, guid2, "Mensagem de teste")));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        [Trait("Categoria", "Validar se vazio")]
        public void ValidarSeVazio_ValorVazio_DeveRetornarExcecao(string valor)
        {
            // Arrange & Act & Assert
            Assert.NotNull(Record.Exception(() => Validacoes.ValidarSeVazio(valor, "Mensagem de teste")));
        }

        [Theory]
        [InlineData("valor")]
        [InlineData("v")]
        [InlineData("  valor")]
        [Trait("Categoria", "Validar se vazio")]
        public void ValidarSeVazio_ValorPreenchido_NaoDeveRetornarExcecao(string valor)
        {
            // Arrange & Act & Assert
            Assert.Null(Record.Exception(() => Validacoes.ValidarSeVazio(valor, "Mensagem de teste")));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]

        [Trait("Categoria", "Validar se nulo")]
        public void ValidarSeEhTrueOuFalse_ValorPreenchido_NaoDeveRetornarExcecao(bool valor)
        {
            // Arrange & Act & Assert
            Assert.Null(Record.Exception(() => Validacoes.ValidarSeEhTrueOuFalse(valor, "Mensagem de teste")));
        }

        [Theory]
        [InlineData(1.1)]
        [InlineData(9.9)]
        [InlineData(5)]
        [InlineData(8)]
        [Trait("Categoria", "Validar valor minino e maximo")]
        public void ValidarMinimoMaximo_ValorDecimalEstaEntreOMininoEOMaxino_NaoDeveRetornarExcecao(decimal valor)
        {
            // Arrange
            decimal valorMinino = 1;
            decimal valorMaximo = 10;

            // Act & Assert
            Assert.Null(Record.Exception(() => Validacoes.ValidarMinimoMaximo(valor, valorMinino, valorMaximo, "Mensagem de teste")));
        }

        [Theory]
        [InlineData(0.1)]
        [InlineData(0.9)]
        [InlineData(0)]
        [InlineData(10.1)]
        [InlineData(20)]
        [InlineData(-20)]
        [Trait("Categoria", "Validar valor minino e maximo")]
        public void ValidarMinimoMaximo_ValorDecimalNaoEstaEntreOMininoEOMaxino_DeveRetornarExcecao(decimal valor)
        {
            // Arrange
            decimal valorMinino = 1;
            decimal valorMaximo = 10;

            // Act & Assert
            Assert.NotNull(Record.Exception(() => Validacoes.ValidarMinimoMaximo(valor, valorMinino, valorMaximo, "Mensagem de teste")));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(9)]
        [InlineData(5)]
        [InlineData(8)]
        [Trait("Categoria", "Validar valor minino e maximo")]
        public void ValidarMinimoMaximo_ValorInteiroEstaEntreOMininoEOMaxino_NaoDeveRetornarExcecao(int valor)
        {
            // Arrange
            int valorMinino = 1;
            int valorMaximo = 10;

            // Act & Assert
            Assert.Null(Record.Exception(() => Validacoes.ValidarMinimoMaximo(valor, valorMinino, valorMaximo, "Mensagem de teste")));
        }

        [Theory]
        [InlineData(11)]
        [InlineData(0)]
        [InlineData(20)]
        [InlineData(-20)]
        [Trait("Categoria", "Validar valor minino e maximo")]
        public void ValidarMinimoMaximo_ValorInteiroNaoEstaEntreOMininoEOMaxino_DeveRetornarExcecao(int valor)
        {
            // Arrange
            int valorMinino = 1;
            int valorMaximo = 10;

            // Act & Assert
            Assert.NotNull(Record.Exception(() => Validacoes.ValidarMinimoMaximo(valor, valorMinino, valorMaximo, "Mensagem de teste")));
        }
    }
}
