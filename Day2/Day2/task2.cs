using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class task2
    {
        public bool isvalid(string pw)
        {
            if(pw.Length<8)
            {
                Console.WriteLine("invalid password");
                return false;
            }
            bool upper = false;
            bool lower = false;
            bool digit = false;
            bool special = false;

            foreach (char ch in pw) {
                if (char.IsUpper(ch)) {
                    upper = true;
                }
                if (char.IsLower(ch))
                {
                    lower = true;
                }
                if (char.IsDigit(ch))
                {
                    digit = true;
                }
                if (isspecial(ch))
                {
                    special = true;
                }
            }

            if (upper && lower &&  digit && special) {
                Console.WriteLine("valid password");
                return true;
            }
            Console.WriteLine("invalid password");
            return false;
        }

        public bool isspecial(char ch) {
            string special = "!@#$%^&*(),.?\":{}|<>";
            return special.Contains(ch);
        }
    }
}
