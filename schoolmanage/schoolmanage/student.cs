using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolmanage
{
    public class student
    {
        public int rollnumber;
        public string name;
        public int age;
        public string assignedclass;
        public string address;

        public student(int Rollnumber, string Name, int Age, string Assignedclass, string Address)
        {
            rollnumber = Rollnumber;
            name = Name;
            age = Age;
            assignedclass = Assignedclass;
            address = Address;
        }
    }
}
