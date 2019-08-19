using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Configs.Models;
using Microsoft.AspNetCore.Mvc;

using Configs.ViewModels;

namespace Configs.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRespository _employeeRespository;

        public HomeController( IEmployeeRespository employeeRespository)
        {
            _employeeRespository = employeeRespository;
        }

        public IActionResult Index()
        {
           
            return View(_employeeRespository.GetAllEmployees());
        }

        //public JsonResult Details()
        //{
        //    Employees employees = _employeeRespository.GetEmployees(2);

        //    return Json(employees);
        //}
        //====ENABLE CONTENT NEGOTIATION====

        //public ObjectResult Details()
        //{
        //    Employees employees = _employeeRespository.GetEmployees(2);

        //    return new ObjectResult(employees);
        //}


        // //== VIEWDATA==
        //public IActionResult Details()
        //{
        //    Employees employees = _employeeRespository.GetEmployees(2);
        //    ViewData["PageTitle"] = "View Data Details Title";
        //    ViewData["Employee"] = employees;
        //    return View("DetailsViewData");
        //}


        ////== VIEWBAG==
        //public IActionResult Details()
        //{
        //    Employees employees = _employeeRespository.GetEmployees(2);
        //    ViewBag.PageTitle = "View Bag Details Title";
        //    ViewBag.Employee = employees;
        //    return View("DetailsViewBag");
        //}

        ////== STRONGLY TYPED VIEW==
        //public IActionResult Details()
        //{
        //    Employees employees = _employeeRespository.GetEmployees(2);
        //    ViewBag.PageTitle = "Using Strong Typed Model Details Title";

        //    return View(employees);
        //}


        //== STRONGLY TYPED VIEWMODEL==when the model does not have all the data we need to pass to view
        public IActionResult Details(int id)
        {
            Employees employees = _employeeRespository.GetEmployees(id);
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel {
                employee=employees,
                PageTitle = "Using Strong Typed View Model To pass extra Data Title"
            };
           

            return View("DetailsViewModel", homeDetailsViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employees employee)//RedirectToActionResult
        {
            if (ModelState.IsValid)
            {
                employee = _employeeRespository.Create(employee);

                return RedirectToAction("details", new { id = employee.Id });
            }
            return View();
           
        }
        public IActionResult Delete(int id)
        {
            _employeeRespository.Delete(id);

            return RedirectToAction("index");
        }
    }
}