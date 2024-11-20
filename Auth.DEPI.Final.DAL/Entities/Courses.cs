using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLearningPlatform.Models
{
    public class Courses
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Duration { get; set; }
    
        public string? Thumbnail { get; set; }

        public DateTime Created { get; set; }=DateTime.Now;

        public string InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        public ICollection<StudentCourses> StudentCourses { get; set; }
		public ICollection<Video> Videos { get; set; }
	}
}
