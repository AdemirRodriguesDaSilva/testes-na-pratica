using Microsoft.Extensions.DependencyInjection;

namespace LojaVirtual.WebApp.MVC.Configuracao
{
    public static class InjecaoDeDependenciaNotificacao
    {
        public static void RegistrarInjecaoDeDependenciaNotificacao(this IServiceCollection servicos)
        {
            //servicos.AddScoped<INotificationHandler<DominioNotificacao>, DominioNotificacaoHandler>();
        }
    }
}