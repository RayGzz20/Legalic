
using LawyerApi.Models;

namespace LawyerApi.Repository
{
    public interface ISpecialtyRepository
    {
        Task<List<Specialty>> GetAll();
        Task<Specialty?> GetById(int id);
        Task<int> Create(Specialty specialty);
        Task<bool> Exist(int id);
        Task Update(Specialty specialty);
        Task Delete(int id);
    }
}