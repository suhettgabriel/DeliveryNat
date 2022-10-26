using DeliveryNat.Models;

namespace DeliveryNat.ViewModels
{
    public class PedidoProdutoViewModel
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<PedidoDetalhe> PedidoDetalhes { get; set; }

    }
}
