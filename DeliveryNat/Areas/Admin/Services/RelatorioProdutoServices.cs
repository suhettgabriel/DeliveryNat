using DeliveryNat.Context;
using DeliveryNat.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryNat.Areas.Admin.Services
{
    public class RelatorioProdutoServices
    {
        private readonly AppDbContext _context;

        public RelatorioProdutoServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Produto>> GetProdutosReport()
        {
            var produtos = await _context.Produtos.ToListAsync();

            if (produtos is null)
                return default(IEnumerable<Produto>);

            return produtos;

        }
        public async Task<IEnumerable<Categoria>> GetCategoriasReport()
        {
            var categorias = await _context.Categorias.ToListAsync();

            if (categorias is null)
                return default(IEnumerable<Categoria>);

            return categorias;

        }

    }
}
