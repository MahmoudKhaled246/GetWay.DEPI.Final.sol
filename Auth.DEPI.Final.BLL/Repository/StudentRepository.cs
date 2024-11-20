using Auth.DEPI.Final.BLL.Interfaces;
using Auth.DEPI.Final.DAL.Data.Context;
<<<<<<< Updated upstream
using OnlineLearningPlatform.Models;
=======
using Auth.DEPI.Final.DAL.Entities;
using Microsoft.EntityFrameworkCore;
>>>>>>> Stashed changes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DEPI.Final.BLL.Repository
{
    public class StudentRepository : GenericRepository<Student> , IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetStudentsByInstructorCoursesAsync(string instructorId, IEnumerable<string> courseIds)
        {
            var courseIdList = courseIds.ToList();  // Convert to List

            return await _context.Students
                .Where(student => student.StudentCourses
                    .Any(sc => courseIdList.Contains(sc.CourseId) && sc.Course.InstructorId == instructorId))  // Filter by instructorId
                .Include(student => student.StudentCourses)
                .ThenInclude(sc => sc.Course)  // Include course details
                .ToListAsync();
        }
    }
}
