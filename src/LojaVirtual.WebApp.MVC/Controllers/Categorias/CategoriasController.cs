using LojaVirtual.Cadastro.Application.Categorias.Adicionar.Commands;
using LojaVirtual.Cadastro.Application.Categorias.Obter.Servicos;
using LojaVirtual.Cadastro.Application.Categorias.ViewModel;
using LojaVirtual.Core.Comunicacao;
using LojaVirtual.Core.Messages.Notificacao;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LojaVirtual.WebApp.MVC.Controllers.Categorias
{
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaAplicacaoServicoObter _categoriaAplicacaoServicoObter;
        private readonly IMediatorHandler _mediatorHandler;

        public CategoriasController(ICategoriaAplicacaoServicoObter categoriaAplicacaoServicoObter,
                                    IMediatorHandler mediatorHandler,
                                    INotificationHandler<DominioNotificacao> notificacao) : base(notificacao, mediatorHandler)
        {
            _categoriaAplicacaoServicoObter = categoriaAplicacaoServicoObter;
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet]
        [Route("obter-categorias")]
        public async Task<IActionResult> Index()
        {
            return View(await _categoriaAplicacaoServicoObter.ObterTodos());
        }

        [Route("adicionar-categoria")]
        public async Task<IActionResult> AdicionarCategoria()
        {
            return View(await PopularCategorias(new CategoriaViewModel()));
        }

        [HttpPost]
        [Route("adicionar-categoria")]
        public async Task<IActionResult> AdicionarCategoria(CategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid)
                return View(await PopularCategorias(new CategoriaViewModel()));

            var command = new AdicionarCategoriaCommand(categoriaViewModel.Nome, categoriaViewModel.Codigo);

            var teste = await _mediatorHandler.EnviarCommand(command);
            if (teste)
                return RedirectToAction("Index");
             
            TempData["Error"] = ObterMensagensDeErro();
            return View();
        }

        private async Task<CategoriaViewModel> PopularCategorias(CategoriaViewModel categoria)
        {
            return categoria;
        }
    }
}