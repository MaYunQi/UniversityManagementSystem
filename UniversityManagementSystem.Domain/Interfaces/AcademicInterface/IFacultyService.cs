
using UniversityManagementSystem.Domain.Entities.AcademicEntity;

namespace UniversityManagementSystem.Domain.Interfaces.AcademicInterface
{
    public interface IFacultyService
    {
        Task<Faculty> GetFacultyByIdAsync(sbyte id);
        Task<IEnumerable<Faculty>> GetAllFacultiesAsync();
        Task<int> AddFacultyAsync(Faculty faculty);
        Task<int> DeleteFacultyAsync(sbyte id);
        Task<int> UpdateFacultyAsync(Faculty faculty);
    }
}
