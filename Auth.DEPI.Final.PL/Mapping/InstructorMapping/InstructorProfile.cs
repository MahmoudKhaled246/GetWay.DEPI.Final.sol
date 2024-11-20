using Auth.DEPI.Final.PL.ViewModels.HomeViewModels;
using AutoMapper;
using OnlineLearningPlatform.Models;

namespace Auth.DEPI.Final.PL.Mapping.InstructorMapping
{
    public class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            CreateMap<Instructor,InstructorsViewModel>().ReverseMap();
        }
    }
}
