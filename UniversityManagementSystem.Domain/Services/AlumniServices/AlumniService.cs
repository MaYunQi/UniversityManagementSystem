
using UniversityManagementSystem.Domain.Entities.AcademicEntity;
using UniversityManagementSystem.Domain.Entities.OtherEntity;
using UniversityManagementSystem.Domain.Interfaces.AcademicInterface;
using UniversityManagementSystem.Domain.Interfaces.AlumniInterface;

namespace UniversityManagementSystem.Domain.Services.AlumniServices
{
    public class AlumniService : IAlumniService
    {
        private readonly IAlumniRepository _alumniRepository;
        private readonly IFacultyRepository _facultyRepository;
        public AlumniService(IAlumniRepository alumniRepository,IFacultyRepository facultyRepository)
        {
            _alumniRepository = alumniRepository??throw new ArgumentNullException();
            _facultyRepository=facultyRepository??throw new ArgumentNullException();
        }
        /// <summary>
        /// Return an alumni instance by Id field, if the alumni is not found or id is invalid, the return value will be null.
        /// </summary>
        /// <param name="id">Alumni Id</param>
        /// <returns>Alumni Instance</returns>
        public async Task<Alumni> GetAlumniByIdAsync(uint id)
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
        public async Task<int> DeleteAlumniAsync(uint id)
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
        public async Task<IEnumerable<Alumni>> GetAllAlumniAsync()
        {
            return await _alumniRepository.GetAllAlumniAsync();
        }
        public async Task<IEnumerable<Alumni>> GetAllUndergraduateAlumniAsync()
        {
            return await _alumniRepository.GetAllAlumniByDegreeAsync(Degree.Bachelor);
        }
        public async Task<IEnumerable<Alumni>> GetAllGraduateAlumniAsync()
        {
            return await _alumniRepository.GetAllAlumniByDegreeAsync(Degree.Master);
        }
        public async Task<IEnumerable<Alumni>> GetAllDoctoralAlumniAsync()
        {
            return await _alumniRepository.GetAllAlumniByDegreeAsync(Degree.PhD);
        }
        public async Task<IEnumerable<Alumni>> GetAllAlumniByYearAsync(ushort year)
        {
            if (year < 0 || year > DateTime.Now.Year)
                return null;
            return await _alumniRepository.GetAllAlumniByYearAsync(year);
        }
        public async Task<IEnumerable<Alumni>> GetAllAlumniByMajorIdAsync(ushort id)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Alumni>> GetAllAlumniByFacultyIdAsync(sbyte id)
        {
            if (id < 0)
                return null;
            Faculty faculty=await _facultyRepository.GetFacultyByIdAsync(id);
            if (faculty == null)
                return null;
            return await _alumniRepository.GetAllAlumniByFacultyIdAsync(id);
        }
        public async Task<int> AddCurrentYearAlumniAsync(IEnumerable<Alumni> alumniList)
        {
            throw new NotImplementedException();
        }
        public async Task<int> BatchUpdateAlumniAsync(IEnumerable<Alumni> alumniList)
        {
            throw new NotImplementedException();
        }
        public async Task<int> BatchDeleteAlumniAsync(IEnumerable<uint> idList)
        {
            throw new NotImplementedException();
        }
    }
}
