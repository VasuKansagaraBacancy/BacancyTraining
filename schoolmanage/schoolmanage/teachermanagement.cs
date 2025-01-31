using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolmanage
{
    public class teachermanagement
    {
        public List<teacher> teachers = new List<teacher>();

        public void AddTeacher(int id1, string name, string subject, string experience)
        {
            teachers.Add(new teacher(id1, name, subject, experience));
        }

        public void ViewAllTeachers()
        {
            Console.WriteLine("All Teachers:");
            Console.WriteLine("............................................................");
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"Name:{teacher.name}\nID:{teacher.tid}\nSubject:{teacher.subject}\nExperience:{teacher.experience}");
                Console.WriteLine("............................................................");
            }
        }

        public void SearchTeacher(int id1)
        {
            var teacher1 = teachers.FirstOrDefault(t => t.tid == id1);
            Console.WriteLine(teacher1 != null ? $"Name:{teacher1.name}\n ID:{teacher1.tid}\nSubject:{teacher1.subject}\nExperience:{teacher1.experience}" : "Teacher not found.");
            Console.WriteLine("............................................................");
        }

        public void UpdateTeacher(int id)
        {
            var teacher1 = teachers.FirstOrDefault(t => t.tid == id);
            if (teacher1 != null)
            {
                Console.WriteLine("Select the detail to update:");
                Console.WriteLine("1. Name");
                Console.WriteLine("2. Subject");
                Console.WriteLine("3. Experience");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter new Name: ");
                        teacher1.name = Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Enter new Subject: ");
                        teacher1.subject = Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Enter new Class: ");
                        teacher1.experience = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        return;
                }

                Console.WriteLine("Teacher details updated successfully.");
            }
            else
            {
                Console.WriteLine("Teacher not found");
            }
        }

        public void DeleteTeacher(int Id)
        {
            var teacher = teachers.FirstOrDefault(t => t.tid == Id);
            if (teacher != null)
            {
                teachers.Remove(teacher);
                Console.WriteLine("Teacher deleted successfully.");
            }
            else
            {
                Console.WriteLine("Teacher not found.");
            }
        }
    }
}
