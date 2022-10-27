using DeliveryNat.Context;
using DeliveryNat.Models;

namespace DeliveryNat.Areas.Admin.Services
{
    public class GraficoVendasService
    {
        private readonly AppDbContext context;

        public GraficoVendasService(AppDbContext context)
        {
            this.context = context;
        }

        public List<ProdutoGrafico> GetVendasProdutos(int dias = 360)
        {
            var data = DateTime.Now.AddDays(-dias);


            var produtos = (from pd in context.PedidoDetalhes
                            join l in context.Produtos on pd.ProdutoId equals l.ProdutoId
                            where pd.Pedido.PedidoEnviado >= data
                            group pd by new { pd.ProdutoId, l.Nome }
                           into g
                            select new
                            {
                                ProdutoNome = g.Key.Nome,
                                ProdutosQuantidade = g.Sum(q => q.Quantidade),
                                ProdutosValorTotal = g.Sum(a => a.Preco * a.Quantidade)
                            });

            var lista = new List<ProdutoGrafico>();

            foreach (var item in produtos)
            {
                var produto = new ProdutoGrafico();
                produto.ProdutoNome = item.ProdutoNome;
                produto.ProdutosQuantidade = item.ProdutosQuantidade;
                produto.ProdutosValorTotal = item.ProdutosValorTotal;
                lista.Add(produto);
            }
            return lista;
        }
    }
}
