using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolmanage
{
    public class studentmanagement
    {
        public List<student> students = new List<student>();

        public void addstudent(int Rollnumber, string Name, int Age, string Assignedclass, string Address)
        {
            students.Add(new student(Rollnumber, Name, Age, Assignedclass, Address));
        }

        public void ViewAllStudents()
        {
            Console.WriteLine("All Students:");
            foreach (var student in students)
                { 
                Console.WriteLine($"\nName:{student.name}\nAge:{student.age}\nRollNumber:{student.rollnumber}\nClass:{student.assignedclass}\nAddress:{student.address}");
                Console.WriteLine("............................................................");

            }
        }

        public void SearchStudent(int RollNumber)
        {
            var student = students.FirstOrDefault(s => s.rollnumber == RollNumber);
            Console.WriteLine(student != null ? $"\nName:{student.name}\nAge:{student.age}\nRollNumber:{student.rollnumber}\nClass:{student.assignedclass}\nAddress:{student.address}" : "Student not found.");
            Console.WriteLine("............................................................");
        }

        public void UpdateStudent(int rollNumber)
        {
            student student1 = null;
            foreach (var s in students)
            {
                if (s.rollnumber == rollNumber)
                {
                    student1 = s;
                    break;
                }
            }

            if (student1 == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.WriteLine("Select the detail to update:");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Age");
            Console.WriteLine("3. Class");
            Console.WriteLine("4. Address");
            Console.Write("Enter your choice: ");

            int choice= Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter new Name: ");
                    student1.name = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Enter new Age: ");
                    student1.age = Convert.ToInt32(Console.ReadLine());
                    break;
                case 3:
                    Console.Write("Enter new Class: ");
                    student1.assignedclass = Console.ReadLine();
                    break;
                case 4:
                    Console.Write("Enter new Address: ");
                    student1.address = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            Console.WriteLine("Student details updated successfully.");
        }

        public void DeleteStudent(int rollNumber)
        {
            var student = students.FirstOrDefault(s => s.rollnumber == rollNumber);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine("Student deleted successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

    }
}
