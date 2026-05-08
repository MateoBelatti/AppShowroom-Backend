using System.Collections.Generic;
using System.Threading.Tasks;
using biblioteca.clases;

namespace Repository.clases
{
    public interface IVelaRepository
    {
        Task<IEnumerable<Vela>> GetAllAsync();
        Task<Vela?> GetByIdAsync(int id);
        Task AddAsync(Vela entity);
        Task UpdateAsync(Vela entity);
        Task DeleteAsync(int id);
    }
}
