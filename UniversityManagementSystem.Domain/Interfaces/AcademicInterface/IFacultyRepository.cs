
using UniversityManagementSystem.Domain.Entities.AcademicEntity;

namespace UniversityManagementSystem.Domain.Interfaces.AcademicInterface
{
    public interface IFacultyRepository
    {
        Task<Faculty> GetFacultyByIdAsync(int id);
        Task<IEnumerable<Faculty>> GetAllFacultiesAsync();
        Task<int> AddFacultyAsync(Faculty faculty);
        Task<int> DeleteFacultyAsync(int id);
        Task<int> UpdateFacultyAsync(Faculty faculty);
    }
}
