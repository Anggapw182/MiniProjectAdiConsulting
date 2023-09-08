using System.ComponentModel.DataAnnotations;

namespace StudentAttendanceManagement.Models.Students
{
    public class UpdateRequestStudent
    {
        public string StudentName { get; set; }
        public double AttendencePercentage { get; set; }
    }
}
