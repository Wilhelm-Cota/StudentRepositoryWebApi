namespace StudentRestApi.Model
{
    public interface IStudentRespository
    {
        Task<IEnumerable<Student>> Search(string name, Gender? gemder);

        Task<Student> GetStudent(int id);

        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudentByEmail(string email);

        Task<Student> AddStudent(Student student);

        Task<Student> UpdateStudent(Student student);

        Task DeleteStudent(int id);
    }
}
