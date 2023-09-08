namespace StudentAttendanceManagement.Models.Students;

using System.ComponentModel.DataAnnotations;
using StudentAttendanceManagement.Entities;

public class CreateRequestStudent
{
    [Required]
    public string StudentName { get; set; }
    [Required]
    public double AttendencePercentage { get; set; }
}