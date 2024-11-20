using Auth.DEPI.Final.BLL.Interfaces;
using Auth.DEPI.Final.DAL.Entities;
using Auth.DEPI.Final.PL.Helpers;
using Auth.DEPI.Final.PL.ViewModels.HomeViewModels;
using Auth.DEPI.Final.PL.ViewModels.InstructorViewModels;

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.Models;

namespace Auth.DEPI.Final.PL.Controllers
{
	[Authorize(Roles = "Instructor, Admin")]
	public class InstructorController : Controller
	{
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public InstructorController(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            UserManager<User> userManager

            ) {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
		public async Task<IActionResult> Index()
		{

            var user = await _userManager.GetUserAsync(User);
            ViewBag.User = user;

<<<<<<< Updated upstream
            var instructor = await _unitOfWork.InstructorRepository.GetAsync(user.Id);
=======


            var courses = await _unitOfWork.CourseRepository.GetInstructorCoursesAsync(user.Id);

            var students = await _unitOfWork.StudentRepository.GetStudentsByInstructorCoursesAsync(user.Id,courses.Select(c => c.Id));
            var mappedStudents = _mapper.Map<IEnumerable<GetStudentViewModel>>(students, opts => opts.Items["InstructorId"] = user.Id);
            ViewBag.Students = mappedStudents;

            //Auto Mapping

            var result = _mapper.Map<IEnumerable<CoursesViewModel>>(courses);

           

            return View(result);
        
		}

        [HttpGet]
		public async Task<IActionResult> Courses()
		{

            var user = await _userManager.GetUserAsync(User);
            ViewBag.User = user;



            var courses = await _unitOfWork.CourseRepository.GetInstructorCoursesAsync(user.Id);
        
           
>>>>>>> Stashed changes


			return View(instructor);
		}
<<<<<<< Updated upstream
        [HttpPost]
        public async Task<IActionResult> Create(CoursesViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Thumbnail = DocumentSettings.UploadFile(model.CourseImage, "images");
               

=======
        

        [HttpGet]
		public async Task<IActionResult> Students()
		{

            var user = await _userManager.GetUserAsync(User);
            ViewBag.User = user;



            var courses = await _unitOfWork.CourseRepository.GetInstructorCoursesAsync(user.Id);

            // Get all students related to the courses taught by the instructor
            var students = await _unitOfWork.StudentRepository.GetStudentsByInstructorCoursesAsync(user.Id,courses.Select(c => c.Id));



            //Auto Mapping
            var result = _mapper.Map<IEnumerable<GetStudentViewModel>>(students, opts => opts.Items["InstructorId"] = user.Id);
                
           

            return View(result);
        
		}


        [HttpGet]
        public async Task<IActionResult> CreateCourse()
        {
            var user = await _userManager.GetUserAsync(User);
            ViewBag.User = user;
            return View();

        }

        [HttpPost]
		public async Task<IActionResult> CreateCourse(CoursesViewModel model)
		{
			var user = await _userManager.GetUserAsync(User);
			model.InstructorId = user.Id;


			// Upload the course image
			model.Thumbnail = DocumentSettings.UploadFile(model.CourseImage, "images");

			// Map the ViewModel to the entity
			var course = _mapper.Map<Courses>(model);

			// Add the course to the database
			await _unitOfWork.CourseRepository.AddAsync(course);

			// Redirect to video creation page
			return RedirectToAction("CreateVideo", new { courseId = model.Id });
		}



		[HttpGet]
        public async Task<IActionResult> Details(string? id)
        {
            if (id is null) return BadRequest(); //400

            var videos = await _unitOfWork.VideoRepository.GetAllCourseVideoAsync(id);

            if (videos is null) return NotFound(); //404

            var result = _mapper.Map<IEnumerable<VideoViewModel>>(videos);

            var user = await _userManager.GetUserAsync(User);
            ViewBag.User = user;

            ViewBag.CourseId = id;


            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            if (id is null) return BadRequest(); //400

            var course = await _unitOfWork.CourseRepository.GetAsync(id);

            if (course is null) return NotFound(); //404
            var user = await _userManager.GetUserAsync(User);
            ViewBag.User = user;
            var result = _mapper.Map<CoursesViewModel>(course);

            return View(result);
        }

        [HttpPost]
        public async Task< IActionResult> Edit([FromRoute]string id,CoursesViewModel model)
        {
            try
            {
                if (id != model.Id) return BadRequest();
                if (ModelState.IsValid)
                {
                    if (model.CourseImage is not null)
                    {

                        if (model.Thumbnail is not null)
                        {
                            DocumentSettings.DeleteFile(model.Thumbnail, "images");
                        }
                        model.Thumbnail = DocumentSettings.UploadFile(model.CourseImage, "images");
                    }
                    else
                    {
                        model.Thumbnail = model.Thumbnail;
                    }
                    var user = await _userManager.GetUserAsync(User);
                    model.InstructorId = user.Id;
                    var course = _mapper.Map<Courses>(model);
                    var count = await _unitOfWork.CourseRepository.UpdateAsync(course);
                    if (count > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch (Exception Ex)
            {

                ModelState.AddModelError(string.Empty, Ex.Message);
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string? id)
        {

            var user = await _userManager.GetUserAsync(User);
            ViewBag.User = user;

            if (id is null) return BadRequest(); //400

            var course = await _unitOfWork.CourseRepository.GetAsync(id);

            if (course is null) return NotFound(); //404

            var result = _mapper.Map<DeleteCourseViewModel>(course);

            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] string id,DeleteCourseViewModel model)
        {
            try
            {
              
>>>>>>> Stashed changes
                var course = _mapper.Map<Courses>(model);

               
                await _unitOfWork.CourseRepository.AddAsync(course);

                return RedirectToAction("CreateVideo", new { courseId = model.Id });
            }
            return View();
            
        }

        [HttpGet]
        public async Task<IActionResult> CreateVideo(string courseId)
        {
<<<<<<< Updated upstream
            var video = new Video
=======
            var user = await _userManager.GetUserAsync(User);
            ViewBag.User = user;

            var video = new VideoViewModel
>>>>>>> Stashed changes
            {
                CourseId = courseId
            };

            return View(video);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVideo(VideoViewModel model)
        {

            if (ModelState.IsValid)
            {
                model.Path = DocumentSettings.UploadFile(model.CourseVideo, "videos");


                var video = _mapper.Map<Video>(model);
                    

                await _unitOfWork.VideoRepository.AddAsync(video);

                return View("Index");
            }

            return View();


        }
<<<<<<< Updated upstream
=======

       


>>>>>>> Stashed changes
    }

}
