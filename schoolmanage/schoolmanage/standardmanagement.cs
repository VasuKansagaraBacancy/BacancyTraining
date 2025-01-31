using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace schoolmanage
{
    public class standardmanagement
    {
        studentmanagement s1=new studentmanagement();
        teachermanagement t1 = new teachermanagement();
        public List<standard> classes = new List<standard>();

        public void AddClass(string className, string section,int assignedteacherid)
        {
            classes.Add(new standard(className, section,assignedteacherid));
        }

        public void ViewAllClasses()
        {
            Console.WriteLine("All Classes:");
            Console.WriteLine("............................................................");
            foreach (var schoolClass in classes)
                Console.WriteLine($"Name:{schoolClass.standardname}\nSection:{schoolClass.section}\nAssigned teacher:{schoolClass.assignedteacherid}");
        }

        public void AssignStudentToClass(studentmanagement sm,int RollNumber,string className)
        {
            var student = sm.students.FirstOrDefault(s => s.rollnumber == RollNumber);
            var schoolClass = classes.FirstOrDefault(c => c.standardname == className);

            if (student != null && schoolClass != null)
            {
                student.assignedclass= className;

                Console.WriteLine($"Student {student.name} assigned to {className}.");
            }
            else
            {
                Console.WriteLine("Invalid student or class.");
            }

        }

        public void AssignTeacherToClass(teachermanagement tm,int id1,string className)
        {
            var teacher = tm.teachers.FirstOrDefault(t => t.tid == id1);
            var schoolClass = classes.FirstOrDefault(c => c.standardname == className);

            if (teacher != null && schoolClass != null)
            {
                schoolClass.assignedteacherid = id1;
                Console.WriteLine($"Teacher {teacher.name} assigned to {className}.");
            }
            else
            {
                Console.WriteLine("Invalid teacher or class.");
            }
        }
    }
}
