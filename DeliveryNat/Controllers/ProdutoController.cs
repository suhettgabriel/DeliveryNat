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

            if(string.IsNullOrEmpty(categoria))
            {
                produtos = _produtoRepository.Produtos.OrderBy(p => p.ProdutoId);
                categoriaAtual = "Todos os produtos";
            }
            else 
            {
                if(string.Equals("Lanches", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    produtos = _produtoRepository.Produtos
                        .Where(p => p.Categoria.CategoriaNome.Equals("Lanches"))
                        .OrderBy(p => p.Nome);
                }
                else
                {
                    produtos = _produtoRepository.Produtos
                        .Where(p => p.Categoria.CategoriaNome.Equals("Pizzas"))
                        .OrderBy(p => p.Nome);
                }
                categoriaAtual = categoria;
            
            }

            var produtosListViewModel = new ProdutoListViewModel
            {
                Produtos = produtos,
                CategoriaAtual = categoriaAtual
            };
            return View(produtosListViewModel);

        }
    }
}
