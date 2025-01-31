

using schoolmanage;
using System.Net;
using System.Xml.Linq;



studentmanagement s2 = new studentmanagement();
s2.addstudent(71, "vasu", 21, "12", "Junagadh");
s2.addstudent(109, "kajal", 21, "12", "Ahmedabad");

//s2.ViewAllStudents();

//s2.UpdateStudent(71);

//s2.DeleteStudent(109);

//s2.ViewAllStudents();


teachermanagement t1 = new teachermanagement();

t1.AddTeacher(1, "Umesh saholiya", ".Net", "8 Years");
t1.AddTeacher(2, "Nishita Rupareliya", ".Net", "8 Years");

t1.ViewAllTeachers();

//t1.UpdateTeacher(1);

//t1.DeleteTeacher(10);

//t1.ViewAllTeachers();

standardmanagement s3 = new standardmanagement();

s3.AddClass("Dotnet", "IT", 1);
s3.ViewAllClasses();
s3.AssignStudentToClass(s2,71, "Dotnet");



s2.ViewAllStudents();

s3.AssignTeacherToClass(t1,2, "Dotnet");

t1.ViewAllTeachers();

