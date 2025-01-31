

using schoolmanage;
using System.Net;
using System.Xml.Linq;



studentmanagement s2 = new studentmanagement();
s2.addstudent(71, "vasu", 21, "12", "Junagadh");
s2.addstudent(109, "kajal", 21, "12", "Ahmedabad");

s2.ViewAllStudents();

s2.UpdateStudent(71);

s2.DeleteStudent(109);

s2.ViewAllStudents();
