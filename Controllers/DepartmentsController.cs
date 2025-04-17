using Microsoft.AspNetCore.Mvc;
using NET_9_Business_App_MVC.Models;
using System.Runtime.Intrinsics.Arm;

namespace NET_9_Business_App_MVC_CRUD.Controllers
{
    public class DepartmentsController : Controller
    {
        [HttpGet]
        public IActionResult Index(string? message)
        {
            var departments = DepartmentsRepository.GetDepartments();
            var style = "<style>.center{margin:auto; width:75%; text-align:center; border: 3px solid #222;padding:1rem;}.header{text-align:left}.table{text-align:center;}  </style>";

            var output = $@"
               <div class='center'>
                    <div class='header'><h2 style='text-align:left'>Departments List</h2>
                    <div class='header'>{message}</div>
                    <a href='/Departments/Create'>Create</a></div>
                    <br/>
                    <br/>
                    <table class='table'>
                    <thead>
                      <tr>
                        <th>Department ID</th>
                        <th>Department Name</th>
                        <th>Department Location</th>
                        <th>Decription</th>
                        <th>Actions</th>
                       </tr>
                   </thead>
                    {
                        string.Join("", departments.Select(dep => $@"
                        <tr>
                            <td>{dep.DepartmentId}</td>
                            <td>{dep.DepartmentName}</td>
                            <td>{dep.DepartmentLocation}</td>
                            <td>{dep.DepartmentDescription}</td>
                            <td><a href='/Departments/Edit/{dep.DepartmentId}'>Edit</a></td>
                            <td><a href='/Departments/Details/{dep.DepartmentId}'>Details</a></td>
                            <td><form  style='padding-top:0.65rem;'method='post' action='departments/delete/{dep.DepartmentId}'>
                               <button type='submit' style='background-color:orange;color:white; '>Delete</button></form></td>
                        </tr>"))
                      }
                   <tbody>
                </div>";
            return Content(style + output, "text/html");
        }
        //end Index (i.e. GetDepartments)

        [HttpGet]
        public IActionResult Details(int departmentId)
        {
            var department = DepartmentsRepository.GetDepartmentById(departmentId);
            if (department is null)
            {
                return Content("<h3 style='color:orange'>Department not found</h3>", "text/html");
            }

            var style = "<style>.center{margin:auto; width:50%; text-align:center; border: 3px solid #222;padding:1rem;} </style>";

            var content = $@"
            <div class='center'>
                <h1>Department: {department.DepartmentName}'s Details</h1>
                <form class='details' method='post' action='/departments/edit'>
                    <input type='hidden', name='departmentId' value='{department.DepartmentId}'/>
                    <label>Name: <input type='text' name='Name'                        value='{department.DepartmentName}'</label><br/><br/>
                  <label>Location: <input type='text' name='DepartmentLocation'                        value='{department.DepartmentLocation}'</label><br/><br/>
                      <label>Description: <input type='text' name='DepartmentDescription'
                        value='{department.DepartmentDescription}'/></label><br/><br/>
                    
                    <a href='/departments/'>Cancel</a>
                    <br/><br/>       
                    <button type='submit'>Update</button>
                    <br/><br/>
                    <form  style='padding-top:0.65rem;'method='post' action='departments/delete/{department.DepartmentId}'>
                    <button type='submit' style='background-color:orange;color:white; '>Delete</button></form>
                </form>
            </div>";

            return Content(style+content, "text/html");
        }
        //end Details GetDepartmentById

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            //check on model state and if invalid, write errors to console TODO: write to log file later
            if (!ModelState.IsValid) {
               //return itemized list of any errors
               return Content(FormatErrorsInHtml(), "text/html");

            }
            if (DepartmentsRepository.UpdateDepartment(department))
            {
                //if update is successful, redirect to Index (probably with a message TODO: add message)
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Content("<h3 style='color:orange'>Department not found</h3>", "text/html");
            }
        }//end Edit

        [HttpGet]
        public IActionResult Create() 
        {
            var content = @"
                <h2><b>Create a new Department</b></h2>
                <form method='post' action='departments/Create'>
                    <label>Name:  <input type='text' name='DepartmentName'/></label><br/><br/>
                    <label>Location:  <input type='text' name='DepartmentLocation'/></label><br/><br/>
                    <label>Description:  <input type='text' name='DepartmentDescription'/></label><br/><br/>
                    <label>Annual Sales:  <input type='text' name='DepartmentAnnualSales'/></label><br/><br/>
                    <button type='submit'>Create</button>
                    <br/><br/>
                    <a href='/departments/'>Cancel</a>
                </form>
            ";        
            return Content(content, "text/html");
        }//end form for Create
        
        [HttpPost]
        public IActionResult Create(Department department)
        {
            //check on model state and if invalid, write errors to console TODO: write to log file later
            if (!ModelState.IsValid)
            {
                //return itemized list of any errors
                return Content(FormatErrorsInHtml(), "text/html");
            }
            else
            {
                //if the model is valid, add the department
                DepartmentsRepository.AddDepartment(department);
                return RedirectToAction(nameof(Index));
            }


        }//end Create to add created department from form object

        [HttpPost]
        public IActionResult Delete(int departmentId) {

            var department = DepartmentsRepository.GetDepartmentById(departmentId);
            if (department is not null)
            {
                ModelState.AddModelError($"{departmentId}", "Department not found");
                return Content(FormatErrorsInHtml(),"text/html");
            }
            else
            {
                DepartmentsRepository.DeleteDepartment(department);
                return RedirectToAction(nameof(Index));
            }
        }


        //error handler to format error messages in Html
        private string FormatErrorsInHtml()
        {
            List<string> errorMessages = new List<string>();
            foreach (var value in ModelState.Values)
            {
                foreach (var error in value.Errors)
                {
                    errorMessages.Add(error.ErrorMessage);
                }
            }
            string output = string.Empty;
            if (errorMessages.Count>0)
            {
                //if there are any error messages, format them in an Html itemized list
                output = $@"
                    <ul>
                        {string.Join("", errorMessages.Select(
                          error => 
                          $"<li style='color:orange;'>{error}</li>"))}
                    </ul>    

                ";
            }

            return output;
        }
    }
}
