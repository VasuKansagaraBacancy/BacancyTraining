using DOTNET_Day5;
public class StudentService : IStudentService
{
    private readonly List<Student> _students = new();
    public List<Student> GetStudents() => _students;
    public void AddStudent(Student student) => _students.Add(student);
    public void UpdateStudent(int id, Student updatedStudent)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student != null)
        {
            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
        }
    }
    public void DeleteStudent(int id)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student != null)
        {
            _students.Remove(student);
        }
    }
}