using EmployeeManagment.Models;
using EmployeeManagment.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Controllers
{

   
    [Authorize]
    public class HomeController : Controller{


        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment hostingEnvironment;
         
       
       public  HomeController(IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            this.hostingEnvironment = hostingEnvironment;


        }


        [AllowAnonymous]

        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployees();

            return View(model);  



        }

        [AllowAnonymous]

        public ViewResult Details(int? id)
        {
           


            Employee employee = _employeeRepository.GetEmpolyee(id.Value);
            if(employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound",id.Value);


            }
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = employee,
                PageTitle = "Detajet e puntorit"
            };


            /* Employee model = _employeeRepository.GetEmpolyee(1);
            ViewBag.PageTitle = "PAGE TITLE";*/ 
           
            return View(homeDetailsViewModel);



        }

        [HttpGet]
        [Authorize]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmpolyee(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Departament = employee.Departament,
                ExistingPhotoPath=employee.PhotoPath
            };


            return View(employeeEditViewModel);

        }


        [HttpPost]
        [Authorize]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmpolyee(model.Id);
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Departament = model.Departament;
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                       "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    employee.PhotoPath = ProcessUploadedFile(model);

                }
               

               
                _employeeRepository.Update(employee);


                return RedirectToAction("index");

            }
            return View();

        }

        private string ProcessUploadedFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {

                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                // To make sure the file name is unique we are appending a new
                // GUID value and and an underscore to the file name
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));

            }

            return uniqueFileName;
        }

        [HttpGet]
     
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
     


        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Departament = model.Departament,
                    PhotoPath = uniqueFileName
                };

                _employeeRepository.Add(newEmployee);


                return RedirectToAction("details", new { id = newEmployee.Id });

            }
            return View();

        }
    }
}
