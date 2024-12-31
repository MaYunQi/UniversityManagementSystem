
using UniversityManagementSystem.Domain.Entities.StaffEntity;
using UniversityManagementSystem.Domain.Interfaces.AcademicInterface;
using UniversityManagementSystem.Domain.Interfaces.StaffInterface;

namespace UniversityManagementSystem.Domain.Services.StaffServices
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IFacultyRepository _facultyRepository;
        public StaffService(IStaffRepository staffRepository, IFacultyRepository facultyRepository)
        {
            _staffRepository=staffRepository;
            _facultyRepository=facultyRepository;
        }
        public async Task<int> AddStaffAsync(Staff staff)
        {
            if (staff == null)
                return -1;
            int  result=await _staffRepository.AddStaffAsync(staff);
            if(result==0)
            {
                Staff local = await _staffRepository.GetStaffByIdAsync(staff.StaffId);
                if (local == null)
                    return 0;
                else
                    return -1;
            }
            return result;
        }

        public Task<int> DeleteStaffAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Staff>> GetAllAcademicStaffAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Staff>> GetAllAdministrativeStaffAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Staff>> GetAllLogisticStaffAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Staff>> GetAllOtherStaffAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Staff>> GetAllStaffAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Staff>> GetAllStaffByFacultyIdAsync(int facultyId)
        {
            throw new NotImplementedException();
        }

        public Task<Staff> GetStaffByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateStaffAsync(Staff staff)
        {
            throw new NotImplementedException();
        }
    }
}
