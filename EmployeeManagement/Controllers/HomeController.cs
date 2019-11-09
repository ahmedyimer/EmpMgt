using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        public HomeController(ILogger<HomeController> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            return View(_employeeRepository.GetEmployee(1));
        }

        //public IActionResult Details()
        //{
        //    Employee model = _employeeRepository.GetEmployee(1);
        //    return View(model);
        //}

        //public JsonResult Details()
        //{
        //    Employee model = _employeeRepository.GetEmployee(1);
        //    return Json(model);
        //}

        //public ObjectResult Details()
        //{
        //    Employee model = _employeeRepository.GetEmployee(1);
        //    return new ObjectResult(model);
        //}

        public ViewResult Details()
        {
            //Employee model = _employeeRepository.GetEmployee(1);

            //// Pass PageTitle and Employee model to the View using ViewData
            //ViewData["PageTitle"] = "Employee Details";
            //ViewData["Employee"] = model;

            //// To store the page title and empoyee model object in the 
            //// ViewBag we are using dynamic properties PageTitle and Employee
            //ViewBag.PageTitle = "Employee Details";
            //ViewBag.Employee = model;

            //return View();

            //return View(model);


            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(1),
                PageTitle = "Employee Details"
            };

            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepository.Add(employee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }

            return View();
        }


        public IActionResult Employees()
        {
            var model = _employeeRepository.GetAllEmployees();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

//[Route("Home")]
//public class HomeController : Controller
//{
//    private IEmployeeRepository _employeeRepository;

//    public HomeController(IEmployeeRepository employeeRepository)
//    {
//        _employeeRepository = employeeRepository;
//    }

//    [Route("")]
//    [Route("Index")]
//    public ViewResult Index()
//    {
//        var model = _employeeRepository.GetAllEmployees();
//        return View(model);
//    }

//    [Route("Details/{id?}")]
//    public ViewResult Details(int? id)
//    {
//        HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
//        {
//            Employee = _employeeRepository.GetEmployee(id ?? 1),
//            PageTitle = "Employee Details"
//        };

//        return View(homeDetailsViewModel);
//    }
//}

//[Route("[controller]/[action]")]
//public class DepartmentsController : Controller
//{
//    public string List()
//    {
//        return "List() of DepartmentsController";
//    }

//    public string Details()
//    {
//        return "Details() of DepartmentsController";
//    }
//}
