<<<<<<< Updated upstream
﻿using OnlineLearningPlatform.Models;
=======
﻿    using Auth.DEPI.Final.DAL.Entities;
using Auth.DEPI.Final.PL.ViewModels.InstructorViewModels;
>>>>>>> Stashed changes

namespace Auth.DEPI.Final.PL.ViewModels.HomeViewModels
{
    public class CoursesViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Duration { get; set; }
        public IFormFile? CourseImage { get; set; }
        public string? Thumbnail { get; set; }
        public Instructor Instructor { get; set; }

<<<<<<< Updated upstream
=======
        public List<VideoViewModel> Videos { get; set; } = new List<VideoViewModel>();
    
}
>>>>>>> Stashed changes
    }
}
