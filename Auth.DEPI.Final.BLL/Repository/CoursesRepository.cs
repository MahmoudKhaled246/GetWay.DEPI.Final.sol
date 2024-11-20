using Auth.DEPI.Final.BLL.Interfaces;
using Auth.DEPI.Final.DAL.Data.Context;
using OnlineLearningPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DEPI.Final.BLL.Repository
{
    public class CoursesRepository : GenericRepository<Courses>, ICourseRepository
    {
        public CoursesRepository(ApplicationDbContext context) : base(context) 
        {

<<<<<<< Updated upstream
=======
        //public Task<IEnumerable<Student>> GetCourseStudentsAsync(string Id)
        //{
        //    _context.Students.Where(S=>S.StudentCourses).
        //}

        public async Task<IEnumerable<Courses>> GetInstructorCoursesAsync(string Id)
        {

          
            return await _context.Courses.Where(c=>c.InstructorId == Id).ToListAsync();
>>>>>>> Stashed changes
        }
        
    }
}
