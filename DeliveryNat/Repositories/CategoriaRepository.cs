using DeliveryNat.Context;
using DeliveryNat.Migrations.Repositories.Interfaces;
using DeliveryNat.Models;

namespace DeliveryNat.Migrations.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
