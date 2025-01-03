
using UniversityManagementSystem.Domain.Entities.AcademicEntity;
using UniversityManagementSystem.Domain.Entities.OtherEntity;
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

        public async Task<int> DeleteStaffAsync(uint id)
        {
            if (id < 0)
                return -1;
            int result=await _staffRepository.DeleteStaffAsync(id);
            if(result==0)
            {
                Staff local = await _staffRepository.GetStaffByIdAsync(id);
                if (local != null)
                    return 0;
                else 
                    return -1;
            }
            return result;
        }
        public async Task<IEnumerable<Staff>> GetAllStaffAsync()
        {
            return await _staffRepository.GetAllStaffAsync();
        }
        public async Task<IEnumerable<Staff>> GetAllStaffByStaffTypeAsync(StaffType type)
        {
            IEnumerable<Staff> staffs = await _staffRepository.GetAllStaffByStaffTypeAsync(type);
            return staffs;
        }
        public async Task<IEnumerable<Staff>> GetAllAcademicStaffAsync()
        {
            return await GetAllStaffByStaffTypeAsync(StaffType.Academic);
        }

        public async Task<IEnumerable<Staff>> GetAllAdministrativeStaffAsync()
        {
            return await GetAllStaffByStaffTypeAsync(StaffType.Administrative);
        }

        public async Task<IEnumerable<Staff>> GetAllLogisticStaffAsync()
        {
            return await GetAllStaffByStaffTypeAsync(StaffType.Logistic);
        }

        public async Task<IEnumerable<Staff>> GetAllOtherStaffAsync()
        {
            return await GetAllStaffByStaffTypeAsync(StaffType.Other);
        }

        public async Task<IEnumerable<Staff>> GetAllStaffByFacultyIdAsync(sbyte facultyId)
        {
            if (facultyId < 0)
                return null;
            Faculty faculty= await _facultyRepository.GetFacultyByIdAsync(facultyId);
            if(faculty!=null)
            {
                return await _staffRepository.GetAllStaffByFacultyIdAsync(facultyId);
            }
            return null;
        }

        public async Task<Staff> GetStaffByIdAsync(uint id)
        {
            if (id < 0)
                return null;
            return await _staffRepository.GetStaffByIdAsync(id);
        }

        public async Task<int> UpdateStaffAsync(Staff staff)
        {
            if (staff == null)
                return -1;
            int result=await _staffRepository.UpdateStaffAsync(staff);
            if (result == 0)
            {
                Staff local = await _staffRepository.GetStaffByIdAsync(staff.StaffId);
                if (local != null)
                    return 0;
                else
                    return -1;
            }
            return result;
        }
    }
}
