using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryNat.Models
{
    [Table("CarrinhoCompraItens")]
    public class CarrinhoCompraItem
    {
        public int CarrinhoCompraItemId { get; set; }
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }

        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }
    }

}
