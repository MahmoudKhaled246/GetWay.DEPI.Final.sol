﻿namespace OnlineLearningPlatform.Models
{
    public class StudentCourses
    {
        public string StudentId { get; set; }
        public Student Student { get; set; }

        public string CourseId { get; set; }
        public Courses Course { get; set; }
    }
}