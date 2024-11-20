using Auth.DEPI.Final.PL.ViewModels.HomeViewModels;
using AutoMapper;
using OnlineLearningPlatform.Models;

namespace Auth.DEPI.Final.PL.Mapping.CoursesMapping
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Courses, CoursesViewModel>().ReverseMap();
        }
    }
}
