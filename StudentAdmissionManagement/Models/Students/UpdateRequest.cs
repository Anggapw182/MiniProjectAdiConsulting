using System.ComponentModel.DataAnnotations;

namespace StudentAdmissionManagement.Models.Students
{
    public class UpdateRequestStudent
    {
        public string StudentName { get; set; }
        public string StudentClass { get; set; }
        public DateTime DateofJoining { get; set; }
    }
}
