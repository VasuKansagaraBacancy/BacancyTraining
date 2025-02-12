using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Day2
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
        public Attendance(int attendanceId, int employeeId, DateTime date, bool isPresent)
        {
            AttendanceId = attendanceId;
            EmployeeId = employeeId;
            Date = date;
            IsPresent = isPresent;
        }
        public static List<Attendance> GetAttendances()
        {
            return new List<Attendance>
        {
            new Attendance(1, 1, new DateTime(2024, 2, 1), true),
            new Attendance(2, 1, new DateTime(2024, 2, 2), true),
            new Attendance(3, 2, new DateTime(2024, 2, 1), true),
            new Attendance(4, 3, new DateTime(2024, 2, 1), false),
            new Attendance(5, 4, new DateTime(2024, 2, 1), true),
            new Attendance(6, 4, new DateTime(2024, 2, 2), true),
            new Attendance(7, 5, new DateTime(2024, 2, 1), true),
            new Attendance(8, 6, new DateTime(2024, 2, 2), true),
            new Attendance(9, 7, new DateTime(2024, 2, 1), false),
            new Attendance(10, 10, new DateTime(2024, 2, 1), true)
        };
        }
    }
}