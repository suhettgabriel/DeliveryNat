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
            ViewData["Titulo"] = "Todos os produtos";
            ViewData["Data"] = DateTime.Now;

            var produtos = _produtoRepository.Produtos;
            var totalProdutos = produtos.Count();

            ViewBag.Total = "Total de produtos : ";
            ViewBag.TotalProdutos = totalProdutos;

            return View(produtos);

        }
    }
}
