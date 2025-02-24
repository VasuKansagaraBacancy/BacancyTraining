namespace DOTNET_Day5
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        void AddStudent(Student student);
        void UpdateStudent(int id, Student updatedStudent);
        void DeleteStudent(int id);
    }
}