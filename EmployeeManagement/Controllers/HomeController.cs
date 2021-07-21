using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Viewmodels;

namespace EmployeeManagement.Controllers
{    
    public class HomeController : Controller
    {        
        private IEmployeeRepository _employeeRepository;
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //[Route("")]
        //[Route("Home")]
        //[Route("Home/Index")]
        public IActionResult Index()
        {
            var model = _employeeRepository.GetEmployees();
            return View(model);
        }

        public IActionResult Create()
        {
            //var model = _employeeRepository.GetEmployees();
            return View();
        }
        //[Route("Home")]
        //public string Index1()
        //{
        //    //Employee employee = _employeeRepository.GetEmployee(1);
        //    //ViewData["Test"] = "Welcome to MVC";
        //    return "Welcome to MVC";
        //}
    }
}
