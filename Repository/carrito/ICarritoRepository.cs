using System.Collections.Generic;
using System.Threading.Tasks;
using biblioteca.clases;

namespace Repository.clases
{
    public interface ICarritoRepository
    {
        Task<IEnumerable<Carrito>> GetAllA();
        Task<Carrito?> GetById(int id);
        Task Create(Carrito entity);
        Task DeleteAsync(int id);
    }
}
