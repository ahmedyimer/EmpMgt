using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        //Singlton instances....
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        //inject to the constroctor. 
        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            return View(employee);
        }
    }
}

