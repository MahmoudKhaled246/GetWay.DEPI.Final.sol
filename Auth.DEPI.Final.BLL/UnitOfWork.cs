using Auth.DEPI.Final.BLL.Interfaces;
using Auth.DEPI.Final.BLL.Repository;
using Auth.DEPI.Final.DAL.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DEPI.Final.BLL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IInstructorRepository _instructorRepository;
        private ICourseRepository _courseRepository;
        private IStudentRepository _studentRepository;
        private IStudentCourseRepository _studentCourseRepository;
        private IVideoRepository _videoRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _instructorRepository = new InstructorRepository(context);
            _courseRepository = new CoursesRepository(context);
            _studentRepository = new StudentRepository(context);
            _studentCourseRepository = new StudentCourseRepository(context);
            _videoRepository = new VideoRepository(context);
        }
        public ICourseRepository CourseRepository => _courseRepository;
        public IInstructorRepository InstructorRepository => _instructorRepository;
        public IStudentRepository StudentRepository => _studentRepository;

        public IStudentCourseRepository StudentCourseRepository => _studentCourseRepository;

        public IVideoRepository VideoRepository => _videoRepository;
    }
}
