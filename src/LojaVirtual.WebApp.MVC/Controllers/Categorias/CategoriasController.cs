using LojaVirtual.Cadastro.Application.Categorias.Obter.Servicos;
using LojaVirtual.Cadastro.Application.Categorias.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LojaVirtual.WebApp.MVC.Controllers.Categorias
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaAplicacaoServicoObter _categoriaAplicacaoServicoObter;

        public CategoriasController(ICategoriaAplicacaoServicoObter categoriaAplicacaoServicoObter)
        {
            _categoriaAplicacaoServicoObter = categoriaAplicacaoServicoObter;
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

        //[HttpPost]
        //[Route("adicionar-categoria")]
        //public async Task<IActionResult> AdicionarCategoria(CategoriaViewModel categoriaViewModel)
        //{
        //    if (!ModelState.IsValid)
        //        return View(await PopularCategorias(new CategoriaViewModel()));

        //    await _categoriaAplicacaoServicoAdicionar.Adicionar(categoriaViewModel);
        //    return RedirectToAction("Index");
        //}

        private async Task<CategoriaViewModel> PopularCategorias(CategoriaViewModel categoria)
        {
            return categoria;
        }
    }
}