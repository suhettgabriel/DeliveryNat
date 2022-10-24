using DeliveryNat.Migrations.Repositories.Interfaces;
using DeliveryNat.Models;
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

        public IActionResult List(string categoria)
        {
            IEnumerable<Produto> produtos;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                produtos = _produtoRepository.Produtos.OrderBy(p => p.ProdutoId);
                categoriaAtual = "Todos os produtos";
            }
            else
            {
                produtos = _produtoRepository.Produtos
                  .Where(p => p.Categoria.CategoriaNome.Equals(categoria))
                  .OrderBy(c => c.Nome);
                categoriaAtual = categoria;
            }

            var produtosListViewModel = new ProdutoListViewModel
            {
                Produtos = produtos,
                CategoriaAtual = categoriaAtual
            };
            return View(produtosListViewModel);

        }
        public IActionResult Details(int produtoId)
        {
            var produto = _produtoRepository.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
            return View(produto);
        }
        public ViewResult Search(string searchString)
        {
            IEnumerable<Produto> produtos;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                produtos = _produtoRepository.Produtos.OrderBy(p => p.ProdutoId);
                categoriaAtual = "Todos os Produtos";
            }
            else
            {
                produtos = _produtoRepository.Produtos
                          .Where(p => p.Nome.ToLower().Contains(searchString.ToLower()));

                if (produtos.Any())
                    categoriaAtual = "Produtos";
                else
                    categoriaAtual = "Nenhum produto foi encontrado";
            }

            return View("~/Views/Produto/List.cshtml", new ProdutoListViewModel
            {
                Produtos = produtos,
                CategoriaAtual = categoriaAtual
            });
        }
    }
}
