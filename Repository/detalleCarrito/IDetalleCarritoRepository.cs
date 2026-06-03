using System.Collections.Generic;
using System.Threading.Tasks;
using biblioteca.clases;

namespace Repository
{
    public interface IDetalleCarritoRepository
    {
        Task<DetalleCarrito?> GetById(int id);
        Task<DetalleCarrito[]> GetByCarritoId(int carritoId);
        Task<DetalleCarrito> Create(DetalleCarrito entity);
        Task<DetalleCarrito> Update(DetalleCarrito entity);
        Task DeleteAllByCarritoId(int carritoId);
        Task Delete(int carritoId);
    }
}
