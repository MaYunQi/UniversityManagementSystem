
using UniversityManagementSystem.Domain.Entities.AcademicEntity;
using UniversityManagementSystem.Domain.Interfaces.AcademicInterface;
using UniversityManagementSystem.Infrastructure.DbContexts;

namespace UniversityManagementSystem.Infrastructure.Repositories
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly WebApplicationDBContext _dbContext;
        public FacultyRepository(WebApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public Task<int> AddFacultyAsync(Faculty faculty)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteFacultyAsync(sbyte id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Faculty>> GetAllFacultiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Faculty> GetFacultyByIdAsync(sbyte id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateFacultyAsync(Faculty faculty)
        {
            throw new NotImplementedException();
        }
    }
}
