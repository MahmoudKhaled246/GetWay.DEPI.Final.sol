namespace OnlineLearningPlatform.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public DateTime UploadDate { get; set; } = DateTime.Now;
        public string CourseId { get; set; }
        public Courses Courses { get; set; }
    }
}
