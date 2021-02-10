using LojaVirtual.Cadastro.Application.Categorias.Adicionar.Commands;
using LojaVirtual.Cadastro.Application.Categorias.Atualizar.Commands;
using LojaVirtual.Cadastro.Application.Categorias.Obter.Servicos;
using LojaVirtual.Cadastro.Application.Categorias.ViewModel;
using LojaVirtual.Core.Comunicacao.Mediator;
using LojaVirtual.Core.DomainObject;
using LojaVirtual.Core.Messages.Notificacao;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LojaVirtual.WebApp.MVC.Controllers.Categorias
{
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaAplicacaoObterServico _categoriaAplicacaoServicoObter;
        private readonly IMediatorHandler _mediatorHandler;

        public CategoriasController(ICategoriaAplicacaoObterServico categoriaAplicacaoServicoObter,
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
            try
            {
                if (!ModelState.IsValid)
                    return View(await PopularCategorias(new CategoriaViewModel()));

                var command = new AdicionarCategoriaCommand(categoriaViewModel.Nome, categoriaViewModel.Codigo);

                var resultado = await _mediatorHandler.EnviarCommand(command);
                if (resultado)
                    return RedirectToAction("Index");

                TempData["Error"] = ObterMensagensDeErro();
                return View();
            }
            catch (System.Exception ex)
            {
                TempData["Error"] = "System.Exception ex - Teste";
                return View();
            }
        }

        [HttpGet]
        [Route("atualizar-categoria")]
        public async Task<IActionResult> AtualizarCategoria(Guid id)
        {
            return View(await PopularCategorias(await _categoriaAplicacaoServicoObter.ObterPorId(id)));
        }

        [HttpPost]
        [Route("atualizar-categoria")]
        public async Task<IActionResult> AtualizarCategoria(CategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid)
                return View(await PopularCategorias(categoriaViewModel));

            var command = new AtualizarCategoriaCommand(categoriaViewModel.Id, categoriaViewModel.Nome, categoriaViewModel.Codigo, categoriaViewModel.Ativo);

            var resultado = await _mediatorHandler.EnviarCommand(command);
            if (resultado)
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