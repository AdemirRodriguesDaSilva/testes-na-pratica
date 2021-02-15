using LojaVirtual.Core.Comunicacao.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace LojaVirtual.WebApp.MVC.Configuracao
{
    public static class InjecaoDeDependenciaMediator
    {
        public static void RegistrarInjecaoDeDependenciaMediator(this IServiceCollection servicos)
        {
            servicos.AddScoped<IMediatorHandler, MediatorHandler>();
        }
    }
}