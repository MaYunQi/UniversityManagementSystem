
using UniversityManagementSystem.Domain.Entities.OtherEntity;
using UniversityManagementSystem.Domain.Entities.StaffEntity;

namespace UniversityManagementSystem.Domain.Interfaces.StaffInterface
{
    public interface IStaffRepository
    {
        Task<IEnumerable<Staff>> GetAllStaffAsync();
        Task<IEnumerable<Staff>> GetAllStaffByFacultyIdAsync(int facultyId);
        Task<IEnumerable<Staff>> GetAllStaffByStaffTypeAsync(StaffType type);
        Task<Staff> GetStaffByIdAsync(int id);
        Task<int> AddStaffAsync(Staff staff);
        Task<int> DeleteStaffAsync(int id);
        Task<int> UpdateStaffAsync(Staff staff);
    }
}
