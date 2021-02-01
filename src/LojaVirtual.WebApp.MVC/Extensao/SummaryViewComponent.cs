using LojaVirtual.Core.Messages.Notificacao;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LojaVirtual.WebApp.MVC.Extensao
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly DominioNotificacaoHandler _notificacao;

        public SummaryViewComponent(INotificationHandler<DominioNotificacao> notificacao)
        {
            _notificacao = (DominioNotificacaoHandler)notificacao;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_notificacao.ObterNotificacoes());
            notificacoes.ForEach(n => ViewData.ModelState.AddModelError(string.Empty, n.Valor));

            return View();
        }

    }
}