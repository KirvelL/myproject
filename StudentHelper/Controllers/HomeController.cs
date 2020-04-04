using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentHelper.Models;
using StudentHelper.Services;
using StudentsHelper.Domain;
using StudentsHelper.Domain.Interfaces;
using StudentsHelper.Domain.Services;
using StudentsHelper.Infastructure;
using StudentsHelper.Infastructure.Interfaces;

namespace StudentHelper.Controllers
{
    public class HomeController : Controller
    {
        private ITeacherDomainService _teacherDomainService;
        private IReviewDomainService _reviewDomainService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public HomeController(ITeacherDomainService teacherDomainService,
            IReviewDomainService reviewDomainService,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _reviewDomainService = reviewDomainService;
            _userManager = userManager;
            _signInManager = signInManager;
            _teacherDomainService = teacherDomainService;
        }

        public IActionResult Index()
        {
            Teacher test = new Teacher();
            test.FirstName = "aa";
            test.Id = Guid.NewGuid();
            test.LastName = "aa";
            return View(test);
        }

        public IActionResult Materials()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        [HttpPost]
        public IActionResult CreateReview(Review review)
        {
            
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Account/Login");
            }
            var current_User = _userManager.GetUserAsync(HttpContext.User).Result;
            review.SenderId = Guid.Parse(current_User.Id);
            review.Id = Guid.NewGuid();
            review.TeacherId = Guid.Parse("0122226F-8779-4DDA-8BAC-A57C0BC37CF5");          
            _reviewDomainService.Create(review);
            _teacherDomainService.GetTeacherById(Guid.Parse("0122226F-8779-4DDA-8BAC-A57C0BC37CF5")).Reviews.Add(review);
            return Redirect("/Home/Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
