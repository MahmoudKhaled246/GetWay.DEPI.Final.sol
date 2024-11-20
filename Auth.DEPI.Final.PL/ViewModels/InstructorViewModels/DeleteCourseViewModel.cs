using Auth.DEPI.Final.DAL.Entities;

namespace Auth.DEPI.Final.PL.ViewModels.InstructorViewModels
{
    public class DeleteCourseViewModel
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public int Duration { get; set; }
        public IFormFile? CourseImage { get; set; }
        public string? Thumbnail { get; set; }

    }
}
