namespace StudentAttendanceManagement.Helpers;

using AutoMapper;
using StudentAttendanceManagement.Entities;
using StudentAttendanceManagement.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        //// CreateRequest -> Students
        CreateMap< Models.Students.CreateRequestStudent, StudentAttendanceModel>();
        //// UpdateRequest -> Students
        CreateMap<Models.Students.UpdateRequestStudent, StudentAttendanceModel>();
    }
}