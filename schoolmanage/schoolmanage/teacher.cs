using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolmanage
{
    public class teacher
    {
        public int tid;
        public string name;
        public string subject;
        public string experience;


        public teacher(int Id, string Name, string Subject,string Experience)
        {
            tid = Id;
            name = Name;
            subject = Subject;
            experience = Experience;
        }
    }
}
