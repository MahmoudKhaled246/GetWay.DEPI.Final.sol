using Auth.DEPI.Final.BLL.Interfaces;
using Auth.DEPI.Final.DAL.Data.Context;
using Auth.DEPI.Final.DAL.Entities;
using Auth.DEPI.Final.PL.Models;
using Auth.DEPI.Final.PL.ViewModels.HomeViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.Models;
using System.Diagnostics;
using Auth.DEPI.Final.PL.ViewModels.InstructorViewModels;

namespace Auth.DEPI.Final.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public HomeController(
            ILogger<HomeController> logger,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<User> userManager,
            ApplicationDbContext context
            )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            if (User.IsInRole("Instructor"))
            {
                // Redirect to the Dashboard action if the user is an Instructor
                return RedirectToAction("index", "Instructor");
            }
           
            var courses = await _unitOfWork.CourseRepository.GetAllAsync();
            var instructors = await _unitOfWork.InstructorRepository.GetAllAsync();
            var students = await _unitOfWork.StudentRepository.GetAllAsync();
            ViewData["InstructorsCount"] = instructors.Count();
            ViewData["CoursesCount"] = courses.Count();
            ViewData["StudentsCount"] = students.Count();

            ViewBag.Instructors = instructors.OrderBy(I => I.Name).Take(3);
            ViewBag.Courses = courses.OrderBy(C=>C.Created).Take(3);
              

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> About()
        {
            var courses = await _unitOfWork.CourseRepository.GetAllAsync();
            var instructors = await _unitOfWork.InstructorRepository.GetAllAsync();
            var students = await _unitOfWork.StudentRepository.GetAllAsync();

            ViewData["InstructorsCount"] = instructors.Count();
            ViewData["CoursesCount"] = courses.Count();
            ViewData["StudentsCount"] = students.Count();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Courses()
        {
            var courses = await _unitOfWork.CourseRepository.GetAllAsync();

            var Result = _mapper.Map<IEnumerable<CoursesViewModel>>(courses);
            return View(Result);
        }
        [HttpGet]
        public async Task<IActionResult> CourseDetails(string Id)
        {
            if (ModelState.IsValid)
            {
                if (Id is null) return BadRequest();

                // Fetch the course from the repository
                var course = await _unitOfWork.CourseRepository.GetAsync(Id);
                if (course is null) return NotFound();

                // Fetch related videos for the course (ensure CourseRepository supports this)
                var videos = await _unitOfWork.VideoRepository.GetAllCourseVideoAsync(Id);  // Assuming this method exists

                // Map the course to the view model
                var result = _mapper.Map<CoursesViewModel>(course);

                // Map videos to VideoViewModel and add to the result view model
                result.Videos = videos.Select(v => new VideoViewModel
                {
                    Id = v.Id,
                    Title = v.Title,
                    Path = v.Path,
                    UploadDate = v.UploadDate,
                    CourseId = v.CourseId
                }).ToList();

                if (User.Identity.IsAuthenticated)
                {
                    var user = await _userManager.GetUserAsync(User);  // Get the logged-in user
                    var student = await _unitOfWork.StudentRepository.GetAsync(user.Id);  // Assuming user.Id is the StudentId

                    // Check if the student is enrolled in the course
                    var isEnrolled = _context.StudentCourses
                        .Any(sc => sc.StudentId == student.Id && sc.CourseId == course.Id);

                    ViewBag.isEnrolled = isEnrolled;
                }

                return View(result);
            }

            ModelState.AddModelError(string.Empty, "Something went Wrong");
            return View();
        }




        [HttpGet]
        public async Task<IActionResult> Instructors()
        {
            var instructors  = await _unitOfWork.InstructorRepository.GetAllAsync();

            var Result = _mapper.Map<IEnumerable<InstructorsViewModel>>(instructors);
            return View(Result);
        }

        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Enroll([FromRoute] string? id)
        {
            var user = await _userManager.GetUserAsync(User); // Get the logged-in user
            if (user == null)
            {
                return Unauthorized();
            }

            var student = await _unitOfWork.StudentRepository.GetAsync(user.Id); // Assuming user.Id is the StudentId
            var course = await _unitOfWork.CourseRepository.GetAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            // Link student to course
            var studentCourse = new StudentCourses
            {
                StudentId = student.Id,
                CourseId = course.Id,
                Student = student,
                Course = course
            };

            await _unitOfWork.StudentCourseRepository.AddAsync(studentCourse);    

            return RedirectToAction(nameof(EnrolledCourses));
        }

        [Authorize(Roles = "Student")]
        public async Task<IActionResult> EnrolledCourses()
        {
            var user = await _userManager.GetUserAsync(User); // Get the logged-in user
            if (user == null)
            {
                return Unauthorized();
            }

            var student = await _unitOfWork.StudentRepository.GetAsync(user.Id); // Assuming user.Id is the StudentId

            if (student == null)
            {
                return NotFound("Student not found.");
            }

            // Get the enrolled courses for the student
            var enrolledCourses = await _unitOfWork.StudentCourseRepository.GetStudentCoursesAsync(student.Id);

            var result = _mapper.Map<IEnumerable<CoursesViewModel>>(enrolledCourses.Select(sc => sc.Course));

            return View(result);
        }


    }
}
