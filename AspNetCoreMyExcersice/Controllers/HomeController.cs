using AspNetCoreMyExcersice.Abstract.Interfaces;
using AspNetCoreMyExersice.DTO.Models;
using AspNetCoreMyExersice.DTO.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNetCoreMyExcersice.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ILogger<HomeController> logger;
        public HomeController(IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment,
            ILogger<HomeController> logger)
        {
            _employeeRepository = employeeRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.logger = logger;
        }

        [Route("Details/{id?}")]
        public IActionResult Details(int? id)
        {
            //throw new Exception("Excption thrown");

            logger.LogTrace("Trace");
            logger.LogError("Error Log");
            logger.LogWarning("Warning");
            logger.LogDebug("Debug");
            var employee = _employeeRepository.GetEmployee(id ?? 1);

            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("../Error/EmployeeNotFound", id.Value);
            }
            return View(employee);
        }

        [Route("")]
        [Route("~/")]
        [Route("Dashboard")]
        public IActionResult Index()
        {
            var employee = _employeeRepository.GetEmployees();
            return View(employee);
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {


            return View();
        }


        [HttpPost]
        [Route("Create")]
        public IActionResult Create(EmployeeViewModel emp)
        {
            Employee employee = null;
            if (ModelState.IsValid)
            {
                employee = _employeeRepository.Add(emp, hostingEnvironment.WebRootPath);
            }
            return RedirectToAction("details", new { id = employee.Id });
        }

        [HttpGet]
        [Route("Edit")]
        public IActionResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            EmployeeEditViewModel viewModel = new EmployeeEditViewModel()
            {
                Id = employee.Id,
                ExistingPhotoPath = employee.PhotoPath,
                Name = employee.Name,
                Email = employee.Email
            };

            return View(viewModel);
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(EmployeeEditViewModel empViewModel)
        {
            if (ModelState.IsValid)
            {
                var employee = _employeeRepository.Update(empViewModel, hostingEnvironment.WebRootPath);
            }
            return RedirectToAction("details", new { id = empViewModel.Id });
        }

    }
}
