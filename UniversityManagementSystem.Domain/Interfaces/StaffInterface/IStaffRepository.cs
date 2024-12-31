
using UniversityManagementSystem.Domain.Entities.StaffEntity;

namespace UniversityManagementSystem.Domain.Interfaces.StaffInterface
{
    public interface IStaffRepository
    {
        Task<IEnumerable<Staff>> GetAllStaffAsync();
        Task<IEnumerable<Staff>> GetAllStaffByFacultyIdAsync(int facultyId);
        Task<Staff> GetStaffByIdAsync(int id);
        Task<int> AddStaffAsync(Staff staff);
        Task<int> DeleteStaffAsync(int id);
        Task<int> UpdateStaffAsync(Staff staff);
    }
}
