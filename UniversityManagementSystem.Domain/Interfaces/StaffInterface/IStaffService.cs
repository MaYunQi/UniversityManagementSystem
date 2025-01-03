﻿
using UniversityManagementSystem.Domain.Entities.OtherEntity;
using UniversityManagementSystem.Domain.Entities.StaffEntity;

namespace UniversityManagementSystem.Domain.Interfaces.StaffInterface
{
    public interface IStaffService
    {
        Task<IEnumerable<Staff>> GetAllStaffAsync();
        Task<IEnumerable<Staff>> GetAllAcademicStaffAsync();
        Task<IEnumerable<Staff>> GetAllAdministrativeStaffAsync();
        Task<IEnumerable<Staff>> GetAllLogisticStaffAsync();
        Task<IEnumerable<Staff>> GetAllOtherStaffAsync();
        Task<IEnumerable<Staff>> GetAllStaffByFacultyIdAsync(sbyte facultyId);
        Task<IEnumerable<Staff>> GetAllStaffByStaffTypeAsync(StaffType type);
        Task<Staff> GetStaffByIdAsync(uint id);
        Task<int> AddStaffAsync(Staff staff);
        Task<int> DeleteStaffAsync(uint id);
        Task<int> UpdateStaffAsync(Staff staff);
    }
}
