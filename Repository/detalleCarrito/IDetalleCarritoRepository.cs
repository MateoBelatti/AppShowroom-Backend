using System.Collections.Generic;
using System.Threading.Tasks;
using biblioteca.clases;

namespace Repository
{
    public interface IDetalleCarritoRepository
    {
        Task<DetalleCarrito?> GetById(int id);
        Task<DetalleCarrito[]> FindByCarritoID(int carritoId);
        Task Create(DetalleCarrito entity);
        Task Update(DetalleCarrito entity);
        Task DeleteAllByCarritoId(int carritoId);
    }
}
