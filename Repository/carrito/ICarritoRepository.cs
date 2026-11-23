using System.Collections.Generic;
using System.Threading.Tasks;
using biblioteca.clases;

namespace Repository
{
    public interface ICarritoRepository
    {
        Task<IEnumerable<Carrito>> GetAll();
        Task<Carrito?> GetByUsuarioId(int usuarioId);
        Task<Carrito?> GetById(int id);
        Task<Carrito> Create(Carrito entity);
        Task<Carrito> Update(Carrito entity);
        Task Delete(int id);
    }
}
