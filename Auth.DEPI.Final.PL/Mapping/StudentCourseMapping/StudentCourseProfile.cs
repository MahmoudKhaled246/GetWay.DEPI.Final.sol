using Auth.DEPI.Final.PL.ViewModels.HomeViewModels;
using AutoMapper;
using OnlineLearningPlatform.Models;

namespace Auth.DEPI.Final.PL.Mapping.StudentCourseMapping
{
    public class StudentCourseProfile : Profile
    {
        public StudentCourseProfile()
        {
            CreateMap<StudentCourses , StudentCoursesViewModel>().ReverseMap();
        }
    }
}
