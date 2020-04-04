using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentHelper.Models;
using StudentHelper.Models.Teachers;
using StudentHelper.Services;
using StudentsHelper.Domain;
using StudentsHelper.Domain.Interfaces;
using StudentsHelper.Domain.Services;
using StudentsHelper.Domain.Services.Models.Teacher;
using StudentsHelper.Infastructure;
using StudentsHelper.Infastructure.Interfaces;

namespace StudentHelper.Controllers
{
    public class TeachersController : Controller
    {
        private ITeacherDomainService _teacherDomainService;
        private IReviewDomainService _reviewDomainService;
        private readonly UserManager<User> _userManager;

        public TeachersController(
            ITeacherDomainService teacherDomainService,
            IReviewDomainService reviewDomainService,
            UserManager<User> userManager)
        {
            _userManager = userManager;
            _reviewDomainService = reviewDomainService;
            _teacherDomainService = teacherDomainService;
        }

        public IActionResult Index()
        {
            var teachers = _teacherDomainService.GetAll();
            return View(teachers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTeacherViewModel request)
        {
            if (ModelState.IsValid)
            {
                if (request.Avatar == null || request.Avatar.Length <= 0)
                {
                    ModelState.AddModelError("Avatar", "Please select your image");
                    return View(request);
                }
                CreateTeacherDTO teacher = new CreateTeacherDTO();
                teacher.FirstName = request.FirstName;
                teacher.LastName = request.LastName;
                teacher.OtherInformation = request.OtherInformation;
                teacher.Avatar = request.Avatar.OpenReadStream();
                
                await _teacherDomainService.Create(teacher);
                return RedirectToAction("Index");
            }
            return View(request);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var teacher = _teacherDomainService.GetTeacherById(id);
            UpdateTeacherViewModel temp = new UpdateTeacherViewModel();
            temp.FirstName = teacher.FirstName;
            temp.LastName = teacher.LastName;
            temp.Id = teacher.Id;
            temp.OtherInformation = teacher.OtherInformation;
            return View(temp);
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var teacher = _teacherDomainService.GetTeacherById(id);
            return View(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateTeacherViewModel request)
        {
            if (ModelState.IsValid)
            {
                UpdateTeacherDTO teacher = new UpdateTeacherDTO();
                if (request.Avatar != null)
                {
                    teacher.Avatar = request.Avatar.OpenReadStream();
                }
                teacher.Id = request.Id;
                teacher.FirstName = request.FirstName;
                teacher.LastName = request.LastName;
                teacher.OtherInformation = request.OtherInformation;
                await _teacherDomainService.Update(teacher);
                return RedirectToAction("Index");
            }
            return View();
        }   
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var teacher = _teacherDomainService.GetTeacherById(id);
            return View(teacher);
        }
        [HttpPost]
        public IActionResult Delete(Teacher request)
        {
            _teacherDomainService.Delete(_teacherDomainService.GetTeacherById(request.Id));
            return RedirectToAction("Index");
        }

        
    }
}