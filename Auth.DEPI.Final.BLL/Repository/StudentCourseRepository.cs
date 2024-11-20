using Auth.DEPI.Final.BLL.Interfaces;
using Auth.DEPI.Final.DAL.Data.Context;
using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DEPI.Final.BLL.Repository
{
    public class StudentCourseRepository : GenericRepository<StudentCourses> , IStudentCourseRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentCourseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentCourses>> GetStudentCoursesAsync(string id)
        {
              return  await _context.StudentCourses.Where(sc => sc.StudentId == id)
                                                   .Include(sc => sc.Course)
                                                   .Include(sc => sc.Course.Instructor)// Include related Course entity
                                                   .ToListAsync();
        }
    }
}
