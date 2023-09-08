//namespace StudentAdmissionManagement.Models.Students;
//using System.ComponentModel.DataAnnotations;

//public class CreateRequest
//{
//    [Required]
//    public string StudentName { get; set; }
//    [Required]
//    public string StudentClass { get; set; }
//    [Required]
//    public DateTime DateofJoining { get; set; }
//}

namespace StudentAdmissionManagement.Models.Students;

using System.ComponentModel.DataAnnotations;
using StudentAdmissionManagement.Entities;

public class CreateRequestStudent
{
    [Required]
    public string StudentName { get; set; }
    [Required]
    public string StudentClass { get; set; }
    [Required]
    public DateTime DateofJoining { get; set; }
}