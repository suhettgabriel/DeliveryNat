using DeliveryNat.Models;

namespace DeliveryNat.Migrations.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> Produtos { get; }
        IEnumerable<Produto> ProdutosPreferidos { get; }
        Produto GetProdutoById(int ProdutoId);

    }
}
