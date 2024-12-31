
using UniversityManagementSystem.Domain.Entities.OtherEntity;
using UniversityManagementSystem.Domain.Interfaces.AlumniInterface;

namespace UniversityManagementSystem.Domain.Services.AlumniServices
{
    public class AlumniService : IAlumniService
    {
        private readonly IAlumniRepository _alumniRepository;
        public AlumniService(IAlumniRepository alumniRepository)
        {
            _alumniRepository = alumniRepository??throw new ArgumentNullException();
        }
        /// <summary>
        /// Return an alumni instance by Id field, if the alumni is not found or id is invalid, the return value will be null.
        /// </summary>
        /// <param name="id">Alumni Id</param>
        /// <returns>Alumni Instance</returns>
        public async Task<Alumni> GetAlumniByIdAsync(int id)
        {
            if (id < 0)
                return null;
            Alumni alumni = await _alumniRepository.GetAlumniByIdAsync(id);
            return alumni;
        }
        /// <summary>
        /// Add an alumni into database
        /// </summary>
        /// <param name="alumni">An alumni instance</param>
        /// <returns>-1 indicates that the instance is null or alumni already exists, 0 indicates fail to add, 1 indicates successfully added</returns>
        public async Task<int> AddAlumniAsync(Alumni alumni)
        {
            if (alumni == null)
                return -1;
            int result = await _alumniRepository.AddAlumniAsync(alumni);
            if(result==0)
            {
                Alumni temp =await  _alumniRepository.GetAlumniByIdAsync(alumni.AlumniId);
                if (temp != null)
                    return -1;
                else
                    return 0;
            }
            return result;
        }
        public async Task<int> DeleteAlumniAsync(int id)
        {
            if (id < 0)
                return -1;
            int result = await _alumniRepository.DeleteAlumniAsync(id);
            if (result == 0)
            {
                Alumni alumni = await _alumniRepository.GetAlumniByIdAsync(id);
                if (alumni == null)
                    return -1;
                else
                    return 0;
            }
            return result;
        }
        public async Task<int> UpdateAlumniAsync(Alumni alumni)
        {
            if (alumni == null)
                return -1;
            int result = await _alumniRepository.UpdateAlumniAsync(alumni);
            if (result == 0)
            {
                Alumni local = await _alumniRepository.GetAlumniByIdAsync(alumni.AlumniId);
                if (local == null)
                    return -1;
                else
                    return 0;
            }
            return result;
        }
        public Task<int> AddCurrentYearAlumniAsync(IEnumerable<Alumni> alumniList)
        {
            throw new NotImplementedException();
        }
        public Task<int> BatchUpdateAlumniAsync(IEnumerable<Alumni> alumniList)
        {
            throw new NotImplementedException();
        }
        public Task<int> BatchDeleteAlumniAsync(IEnumerable<int> idList)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Alumni>> GetAllAlumniAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Alumni>> GetAllAlumniByDegreeAsync(Degree degree)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Alumni>> GetAllAlumniByMajorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Alumni>> GetAllAlumniByYearAsync(int year)
        {
            throw new NotImplementedException();
        }
    }
}
