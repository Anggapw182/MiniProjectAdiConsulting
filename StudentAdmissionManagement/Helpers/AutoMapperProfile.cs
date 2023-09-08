namespace StudentAdmissionManagement.Helpers;

using AutoMapper;
using StudentAdmissionManagement.Entities;
//using StudentAdmissionManagement.Model;
using StudentAdmissionManagement.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        //// CreateRequest -> User
        CreateMap<Models.Users.CreateRequest, User>();

        //// UpdateRequest -> User
        CreateMap<Models.Users.UpdateRequest, User>();

        //// CreateRequest -> Students
        CreateMap< Models.Students.CreateRequestStudent, StudentAdmissionDetailsModel>();
        //// UpdateRequest -> Students
        CreateMap<Models.Students.UpdateRequestStudent, StudentAdmissionDetailsModel>();



        //    .ForAllMembers(x => x.Condition(
        //        (src, dest, prop) =>
        //        {
        //            // ignore both null & empty string properties
        //            if (prop == null) return false;
        //            if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

        //            // ignore null role
        //            if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

        //            return true;
        //        }
        //    ));
    }
}