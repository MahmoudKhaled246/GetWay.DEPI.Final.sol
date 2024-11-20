using Auth.DEPI.Final.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineLearningPlatform.Models
{
    public class Student : User
    {

        public ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
