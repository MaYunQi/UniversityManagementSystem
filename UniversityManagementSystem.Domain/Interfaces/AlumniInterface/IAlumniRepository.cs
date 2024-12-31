
using UniversityManagementSystem.Domain.Entities.OtherEntity;

namespace UniversityManagementSystem.Domain.Interfaces.AlumniInterface
{
    public interface IAlumniRepository
    {
        Task<Alumni> GetAlumniByIdAsync(int id);
        Task<IEnumerable<Alumni>> GetAllAlumniAsync();
        Task<IEnumerable<Alumni>> GetAllAlumniByYearAsync(int year);
        Task<IEnumerable<Alumni>> GetAllAlumniByMajorIdAsync(int id);
        Task<IEnumerable<Alumni>> GetAllAlumniByDegreeAsync(Degree degree);
        Task AddAlumniAsync(Alumni alumni);
        Task AddBatchAlumniAsync(IEnumerable<Alumni> alumniList);
        Task UpdateAlumniAsync(Alumni alumni);
        Task UpdateBatchAlumniAsync(IEnumerable<Alumni> alumniList);
        Task DeleteAlumniAsync(int id);
        Task DeleteBatchAlumniAsync(IEnumerable<int> idList);
    }
}
