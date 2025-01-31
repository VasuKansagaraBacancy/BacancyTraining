using School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{

    public class student {
        public int rollnumber;
        public string name;
        public int age;
        public string assignedclass;
        public string address;

        public student(int Rollnumber,string Name,int Age,string Assignedclass, string Address)
        {
            rollnumber = Rollnumber;
            name = Name;
            age = Age;
            assignedclass = Assignedclass;
            address = Address;
        }


        
        }
    public class teacher
    {
        public int id;
        public string name;
        public string subject;
        

        public teacher(int Id, string Name,string Subject)
        {
            id = Id;
            name = Name;    
            subject = Subject;
          
        }



    }

    public class schoolclass
    {
        public int standard;
        public List<student> students;
        public teacher assignedteacher;
        public string subject;

        public SchoolClass(string standard)
        {
            Standard = standard;
        }




    }

     public string Standard;
        public List<Student> Students  = new List<Student>();
        public Teacher AssignedTeacher;

        public SchoolClass(string standard)
        {
            Standard = standard;
        }



    }
    public void AddTeacher(int id, string name, string subject)
{
    teachers.Add(new Teacher(id, name, subject));
}

public void ViewAllTeachers()
{
    Console.WriteLine("\nAll Teachers:");
    foreach (var teacher in teachers)
        Console.WriteLine(teacher);
}

public void UpdateTeacher(int id, string newName, string newSubject)
{
    var teacher ;
    if (teacher != null)
    {
        teacher.Name = newName;
        teacher.Subject = newSubject;
        Console.WriteLine("Teacher details updated successfully.");
    }
    else
    {
        Console.WriteLine("Teacher not found.");
    }
}

public void DeleteTeacher(int id)
{
    var teacher;
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




public class Class1
    {
    }

