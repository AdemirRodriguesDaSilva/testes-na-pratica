using LojaVirtual.Cadastro.Application.Categorias.Adicionar.Commands;
using LojaVirtual.Cadastro.Application.Categorias.Adicionar.Servicos;
using LojaVirtual.Cadastro.Application.Categorias.Obter.Servicos;
using LojaVirtual.Cadastro.Data;
using LojaVirtual.Cadastro.Data.Categorias;
using LojaVirtual.Cadastro.Domain.Categorias.Repositorios;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LojaVirtual.WebApp.MVC.Configuracao
{
    public static class InjecaoDeDependenciaCadastro
    {
        public static void RegistrarInjecaoDeDependenciaVenda(this IServiceCollection servicos)
        {
            servicos.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            servicos.AddScoped<ICategoriaAplicacaoServicoAdicionar, CategoriaAplicacaoServicoAdicionar>();
            servicos.AddScoped<ICategoriaAplicacaoServicoObter, CategoriaAplicacaoServicoObter>();
            servicos.AddScoped<CadastroContext>();

            servicos.AddScoped<IRequestHandler<AdicionarCategoriaCommand, bool>, AdicionarCategoriaCommandHandler>();

            //servicos.AddScoped<INotificationHandler<PedidoIniciadoEvent>, PedidoEventoHandler>();
            //servicos.AddScoped<INotificationHandler<PedidoAtualizadoEvento>, PedidoEventoHandler>();
            //servicos.AddScoped<INotificationHandler<ItemPedidoAdicinadoEvento>, PedidoEventoHandler>();
        }
    }
}