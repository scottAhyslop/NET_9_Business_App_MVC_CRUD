﻿using Microsoft.AspNetCore.Mvc;
using NET_9_Business_App_MVC.CRUD.Models;
using NET_9_Business_App_MVC_CRUD.Helpers;
using NET_9_Business_App_MVC_CRUD.Models;


namespace NET_9_Business_App_MVC_CRUD.Controllers
{
    public class DepartmentsController : Controller
    {
        [HttpGet]
        public IActionResult Index(string? message)
        {
            //get a list of sample test _departments from the repository
            var departments = DepartmentsRepository.GetDepartments();
            
            return View(departments);
        }
        //end Index (i.e. GetDepartments) //working perfectly

        [Route("/department-list/{filter?}")]
        public IActionResult SearchDepartments(string? filter)
        {
            //get a list of sample test _departments from the repository based on filter
            return ViewComponent("DepartmentList", new { filter });
             
        }//end SearchDepartments //working

        [HttpGet]
        public IActionResult Details(int departmentId)
        {
            //check if departmentId is valid
           var department = DepartmentsRepository.GetDepartmentById(departmentId);

            if (department == null)
            {
                return View("DisplayErrors", new List<string>() { "Department not found" });
            }

            return View(department);
        }
        //end Details GetDepartmentById

        [HttpPost]
        public IActionResult Edit(Department department)
        {
          
          if (!ModelState.IsValid)
          {
            //return itemized list of any errors
            return View("Errors", ModelStateHelper.GetErrors(ModelState));
          }

          DepartmentsRepository.UpdateDepartment(department);
          //if update is successful, redirect to Index (probably with a message TODO: add message)
          return RedirectToAction(nameof(Index));
        }//end Edit

        [HttpGet]
        public IActionResult Create() 
        {
            return View(new Department());
        }//end form for Create
        
        [HttpPost]
        public IActionResult Create(Department department)
        {
            //check on model state and if invalid, write errors to console TODO: write to log file upon creation
            if (department is not null) 
            {
                if (!ModelState.IsValid)
                {
                    //return itemized list of any errors
                    return View("Errors", ModelStateHelper.GetErrors(ModelState));
                }
                else
                {
                    //if the model is valid, add the department
                    DepartmentsRepository.AddDepartment(department);
                    return RedirectToAction(nameof(Index));
                }
            }//end department null check

            //return itemized list of any errors
            return View("Errors", ModelStateHelper.GetErrors(ModelState));


        }//end Create to add created department from form object

        [HttpPost]
        public IActionResult Delete(int departmentId) {

                var department = DepartmentsRepository.GetDepartmentById(departmentId);
                if (department is null)
                {
                    ModelState.AddModelError($"{departmentId}", "Department not found");
                    return View("Errors", ModelStateHelper.GetErrors(ModelState));
                }
                else if (department is not null)
                {
                    DepartmentsRepository.DeleteDepartment(department);
                    return RedirectToAction(nameof(Index));
                }
            //fall through if validation and null checks fail
            ModelState.AddModelError($"{departmentId}", "_departments not valid, no _departments Id found");//add an error, send it to the screen
            return View("Errors", ModelStateHelper.GetErrors(ModelState));
        }
        //end Delete

        //DisplayErrors method to return as per ExceptionHandler RFC 7807 comp.
        [Route("/Views/Shared/DisplayError")]
        public IActionResult DisplayErrors()
        {
            //return a view with the errors
            return View("Errors", ModelStateHelper.GetErrors(ModelState));
        }//end DisplayErrors

        //GetErrors method to return a list of errors for display to DisplayErrors View
     /*   private List<string> GetErrors()
        {
            List<string> errorMessages = new List<string>();
            foreach (var value in ModelState.Values)
            {
                foreach (var error in value.Errors)
                {
                    errorMessages.Add(error.ErrorMessage);
                }
            }
            return errorMessages;
        }//end GetError*/

    }//end DepartmentsController
}//end namespace
