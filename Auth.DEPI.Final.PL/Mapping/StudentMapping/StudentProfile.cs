using Auth.DEPI.Final.DAL.Entities;
using Auth.DEPI.Final.PL.ViewModels.InstructorViewModels;
using AutoMapper;

namespace Auth.DEPI.Final.PL.Mapping.StudentMapping
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, GetStudentViewModel>()
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom((src, dest, _, context) =>
                {
                    // Try to get the InstructorId from the context
                    if (context.Items.TryGetValue("InstructorId", out var instructorIdObj) && instructorIdObj is string instructorId)
                    {
                        // Filter the student's courses based on the instructorId
                        var filteredCourses = src.StudentCourses
                            .Where(sc => sc.Course.InstructorId == instructorId)
                            .Select(sc => sc.Course.Name);

                        // Return concatenated course names
                        return string.Join(", ", filteredCourses);
                    }

                    // If instructorId is not found, return empty or default
                    return string.Empty;
                }));
        }
    }


}
