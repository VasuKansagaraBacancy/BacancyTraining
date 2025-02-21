namespace DOTNET_Day4
{
    public class StudentService : IStudentService
    {
        private static readonly List<string> Students=new ();
        public string Register(string name, int age)
        {
            var student = $"Name: {name}, Age: {age}";
            Students.Add(student);
            LogActivity(name, "Student registered");
            return "Student registered successfully";
        }
        private void LogActivity(string name, string activity)
        {
            string logEntry = $"{DateTime.Now.ToShortDateString()}: {name} - {activity}\n";
            File.AppendAllText("studentlogs.txt", logEntry);
        }
    }
}
