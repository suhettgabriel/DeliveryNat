using DeliveryNat.Models;

namespace DeliveryNat.Migrations.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria>Categorias { get; }
    }
}
