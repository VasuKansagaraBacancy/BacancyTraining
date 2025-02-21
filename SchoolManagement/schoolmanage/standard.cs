using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolmanage
{
    public class standard
    {
        public string standardname;
        public string section;
        public int  assignedteacherid;

        public standard(string Standardname,string Section,int Assignedteacherid)
        {
            standardname=Standardname;
            section=Section;
            assignedteacherid = Assignedteacherid;
        }
    }
}
