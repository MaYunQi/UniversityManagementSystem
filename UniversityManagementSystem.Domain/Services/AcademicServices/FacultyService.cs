
using UniversityManagementSystem.Domain.Entities.AcademicEntity;
using UniversityManagementSystem.Domain.Interfaces.AcademicInterface;

namespace UniversityManagementSystem.Domain.Services.AcademicServices
{
    public class FacultyService : IFacultyService
    {
        private readonly IFacultyRepository _facultyRepository;
        public FacultyService(IFacultyRepository facultyRepository)
        {
            _facultyRepository= facultyRepository;
        }
        public async Task<int> AddFacultyAsync(Faculty faculty)
        {
            if (faculty == null)
                return -1;
            int result = await _facultyRepository.AddFacultyAsync(faculty);
            if(result==0)
            {
                Faculty local = await _facultyRepository.GetFacultyByIdAsync(faculty.FacultyId);
                if (local != null)
                    return -1;
                else
                    return 0;
            }
            return result;
        }

        public Task<int> DeleteFacultyAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Faculty>> GetAllFacultiesAsync()
        {
            return _facultyRepository.GetAllFacultiesAsync();
        }

        public async Task<Faculty> GetFacultyByIdAsync(int id)
        {
            if (id < 0)
                return null;
            return await _facultyRepository.GetFacultyByIdAsync(id);
        }

        public Task<int> UpdateFacultyAsync(Faculty faculty)
        {
            throw new NotImplementedException();
        }
    }
}
