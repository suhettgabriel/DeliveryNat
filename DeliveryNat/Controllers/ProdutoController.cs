using DeliveryNat.Migrations.Repositories.Interfaces;
using DeliveryNat.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryNat.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IActionResult List()
        {
            var ProdutosListViewModel = new ProdutoListViewModel();
            ProdutosListViewModel.Produtos = _produtoRepository.Produtos;
            ProdutosListViewModel.CategoriaAtual = "Categoria Atual";

            return View(ProdutosListViewModel);

        }
    }
}
