using LojaVirtual.Core.Comunicacao;
using LojaVirtual.Core.Messages.Notificacao;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.WebApp.MVC.Controllers
{
    public class ControllerBase : Controller
    {
        private readonly DominioNotificacaoHandler _notificacao;
        private readonly IMediatorHandler _mediatorHandler;

        protected Guid ClienteId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");

        protected ControllerBase(INotificationHandler<DominioNotificacao> notificacao,
                              IMediatorHandler mediatorHandler)
        {
            _notificacao = (DominioNotificacaoHandler)notificacao;
            _mediatorHandler = mediatorHandler;
        }

        protected bool OperacaoValida()
        {
            return !_notificacao.TemNotificacao();
        }

        protected IEnumerable<string> ObterMensagensDeErro()
        {
            return _notificacao.ObterNotificacoes().Select(m => m.Valor).ToList();
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediatorHandler.PublicarNotificacao(new DominioNotificacao(codigo, mensagem));
        }
    }
}