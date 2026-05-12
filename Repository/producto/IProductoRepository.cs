using System.Collections.Generic;
using System.Threading.Tasks;
using biblioteca.clases;

namespace Repository
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAll();
        Task<IEnumerable<Producto>> GetAllActivos();
        Task<Producto?> GetById(int id);
        Task<Producto> Create(Producto entity);
        Task<Producto> Update(Producto entity);
        Task<bool> UpdateActivos(int productoId, int cantidad);
        Task Delete(int id);
    }
}
