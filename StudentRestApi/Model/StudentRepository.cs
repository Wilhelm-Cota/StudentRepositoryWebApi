using Microsoft.EntityFrameworkCore;
using StudentRestApi.Model;

namespace StudentRestApi.Model
{
    public class StudentRepository : IStudentRespository
    {

        private readonly AppDBContext _dbContext;

        public StudentRepository(AppDBContext appDBContext)
        {
            this._dbContext = appDBContext;
        }
         async Task<Student> IStudentRespository.AddStudent(Student student)
        {
           var result = await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

         async Task IStudentRespository.DeleteStudent(int id)
        {
           var result = await _dbContext.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            if(result != null)
            {
                _dbContext.Students.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }

         async Task<Student> IStudentRespository.GetStudent(int id)
        {   
            return await _dbContext.Students.FirstOrDefaultAsync(x => x.StudentId == id);
        }

        async Task<Student> IStudentRespository.GetStudentByEmail(string email)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(x => x.Email == email);
        }

        async Task<IEnumerable<Student>> IStudentRespository.GetStudents()
        {
           return await _dbContext.Students.ToListAsync();
        }

        async Task<IEnumerable<Student>> IStudentRespository.Search(string name, Gender? gender)
        {
            IQueryable<Student> query = _dbContext.Students;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.FirstName.Contains(name) || x.LastName.Contains(name));

            }
            if(gender != null)
            {
                query = query.Where(x => x.Gender == gender);
            }
            return await query.ToListAsync();
        }

        async Task<Student> IStudentRespository.UpdateStudent(Student student)
        {
            var result = await _dbContext.Students.FirstOrDefaultAsync(x => x.StudentId == student.StudentId);

            if(result != null)
            {
                result.FirstName = student.FirstName;
                result.LastName = student.LastName;
                result.Gender = student.Gender;
                result.Email = student.Email;

                await _dbContext.SaveChangesAsync();

            }
            return null;
        }
    }
}
