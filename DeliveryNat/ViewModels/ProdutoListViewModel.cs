using DeliveryNat.Models;

namespace DeliveryNat.ViewModels
{
    public class ProdutoListViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
