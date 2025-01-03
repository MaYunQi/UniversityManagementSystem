
using UniversityManagementSystem.Domain.Entities.OtherEntity;

namespace UniversityManagementSystem.Domain.Interfaces.AlumniInterface
{
    public interface IAlumniService
    {
        Task<Alumni> GetAlumniByIdAsync(uint id);
        Task<IEnumerable<Alumni>> GetAllAlumniAsync();
        Task<IEnumerable<Alumni>> GetAllAlumniByYearAsync(ushort year);
        Task<IEnumerable<Alumni>> GetAllAlumniByMajorIdAsync(ushort id);
        Task<IEnumerable<Alumni>> GetAllAlumniByFacultyIdAsync(sbyte id);
        Task<IEnumerable<Alumni>> GetAllUndergraduateAlumniAsync();
        Task<IEnumerable<Alumni>> GetAllGraduateAlumniAsync();
        Task<IEnumerable<Alumni>> GetAllDoctoralAlumniAsync();
        Task<int> AddAlumniAsync(Alumni alumni);
        Task<int> AddCurrentYearAlumniAsync(IEnumerable<Alumni> alumniList);
        Task<int> UpdateAlumniAsync(Alumni alumni);
        Task<int> BatchUpdateAlumniAsync(IEnumerable<Alumni> alumniList);
        Task<int> DeleteAlumniAsync(uint id);
        Task<int> BatchDeleteAlumniAsync(IEnumerable<uint> idList);
    }
}
