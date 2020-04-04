using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentHelper.Models.Teachers;
using StudentsHelper.Domain;
using StudentsHelper.Domain.Interfaces;
using StudentsHelper.Domain.Services.Models.Teacher;

namespace StudentHelper.Controllers
{
    public class ReviewsController : Controller
    {
        private ITeacherDomainService _teacherDomainService;
        private IReviewDomainService _reviewDomainService;
        private readonly UserManager<User> _userManager;

        public ReviewsController(
            ITeacherDomainService teacherDomainService,
            IReviewDomainService reviewDomainService,
            UserManager<User> userManager)
        {
            _userManager = userManager;
            _reviewDomainService = reviewDomainService;
            _teacherDomainService = teacherDomainService;
        }

        [Route("[controller]/{id}/[action]")]
        [HttpGet]
        public IActionResult AddReview(Guid id)
        {
            Review review = new Review();
            review.TeacherId = id;
            return View(review);
        }

        [Route("[controller]/{id}/[action]")]
        [HttpGet]
        public async Task<IActionResult> Reviews(Guid id)
        {
            var teacher = await _teacherDomainService.GetTeacherReview(id);
            ViewBag.TeacherId = id;
            return View(teacher);
        }
        
        [Authorize]
        [Route("[controller]/{id}/[action]")]
        [HttpPost]
        public IActionResult AddReview(Review review)
        {
            var current_User = _userManager.GetUserAsync(HttpContext.User).Result;
            review.SenderId = Guid.Parse(current_User.Id);
            review.Id = Guid.NewGuid();
            _reviewDomainService.Create(review);
            return RedirectToAction("Index", "Teachers");
        }        
    }
}