using Auth.DEPI.Final.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineLearningPlatform.Models
{
    public class Instructor : User
    {
        public string Bio {  get; set; }
        //public string? Roadmap { get; set; }

        public ICollection<Courses> Courses { get; set; }
    }
}
