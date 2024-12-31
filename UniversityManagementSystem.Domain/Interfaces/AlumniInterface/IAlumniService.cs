
using UniversityManagementSystem.Domain.Entities.OtherEntity;

namespace UniversityManagementSystem.Domain.Interfaces.AlumniInterface
{
    public interface IAlumniService
    {
        Task<Alumni> GetAlumniByIdAsync(int id);
        Task<IEnumerable<Alumni>> GetAllAlumniAsync();
        Task<IEnumerable<Alumni>> GetAllAlumniByYearAsync(int year);
        Task<IEnumerable<Alumni>> GetAllAlumniByMajorIdAsync(int id);
        Task<IEnumerable<Alumni>> GetAllAlumniByDegreeAsync(Degree degree);
        Task<int> AddAlumniAsync(Alumni alumni);
        Task<int> AddCurrentYearAlumniAsync(IEnumerable<Alumni> alumniList);
        Task<int> UpdateAlumniAsync(Alumni alumni);
        Task<int> BatchUpdateAlumniAsync(IEnumerable<Alumni> alumniList);
        Task<int> DeleteAlumniAsync(int id);
        Task<int> BatchDeleteAlumniAsync(IEnumerable<int> idList);
    }
}
