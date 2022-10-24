using DeliveryNat.Migrations.Repositories.Interfaces;
using DeliveryNat.Models;
using DeliveryNat.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryNat.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(IProdutoRepository ProdutoRepository,
            CarrinhoCompra carrinhoCompra)
        {
            _produtoRepository = ProdutoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);
        }
        [Authorize]
        public IActionResult AdicionarItemNoCarrinhoCompra(int produtoId)
        {
            var produtoSelecionado = _produtoRepository.Produtos
                                    .FirstOrDefault(p => p.ProdutoId == produtoId);

            if (produtoSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(produtoSelecionado);
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult RemoverItemDoCarrinhoCompra(int produtoId)
        {
            var produtoSelecionado = _produtoRepository.Produtos
                                    .FirstOrDefault(p => p.ProdutoId == produtoId);

            if (produtoSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(produtoSelecionado);
            }
            return RedirectToAction("Index");
        }
    }

}

