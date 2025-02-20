namespace DOTNET_Day3
{ 
        public interface IFileService
        {
        void SaveStudentsToFile(string filePath, List<Student> students);
        List<Student> RetriveStudentData();

    }

}