using Newtonsoft.Json;
using static DOTNET_Day3.FileService;

namespace DOTNET_Day3
{
    public class FileService : IFileService
    {
        public void SaveStudentsToFile(string filePath, List<Student> students)
        {
            string studentJson = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(filePath, studentJson);
        }
        public List<Student>?  RetriveStudentData()
        {
            string filePath = "studentData.txt";

            string studentJson = System.IO.File.ReadAllText(filePath);
            var students = JsonConvert.DeserializeObject<List<Student>>(studentJson);

            return students;
        }
        

    }

}
