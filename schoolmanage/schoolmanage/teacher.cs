using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolmanage
{
    public class teacher
    {
        public int id;
        public string name;
        public string subject;


        public teacher(int Id, string Name, string Subject)
        {
            id = Id;
            name = Name;
            subject = Subject;

        }
    }
}
