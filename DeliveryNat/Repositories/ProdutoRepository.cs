using DeliveryNat.Context;
using DeliveryNat.Migrations.Repositories.Interfaces;
using DeliveryNat.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryNat.Migrations.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;
        public ProdutoRepository(AppDbContext contexto)
        {
            _context = contexto;
        }

        public IEnumerable<Produto> Produtos => _context.Produtos.Include(c => c.Categoria);

        public IEnumerable<Produto> ProdutosPreferidos => _context.Produtos.
                                   Where(l => l.IsProdutoPreferido)
                                  .Include(c => c.Categoria);

        public Produto GetProdutoById(int ProdutoId)
        {
            return _context.Produtos.FirstOrDefault(l => l.ProdutoId == ProdutoId);
        }
    }

}
