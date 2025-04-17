using Microsoft.AspNetCore.Mvc;
using NET_9_Business_App_MVC.Models;

namespace NET_9_Business_App_MVC_CRUD.Controllers
{
    public class DepartmentsController : Controller
    {
        [HttpGet]
        public IActionResult Index(string? message)
        {
            //get a list of sample test Departments from the repository
            var departments = DepartmentsRepository.GetDepartments();
            
            return View(departments);
        }//end Index (i.e. GetDepartments) //working perfectly

        [HttpGet]
        public IActionResult Details(int departmentId)
        {
            //check if departmentId is valid
            if (departmentId <= 0)
            {
                return Content("<h3 style='color:orange'>Department not found</h3>", "text/html");
            }
            var department = DepartmentsRepository.GetDepartmentById(departmentId);
            if (department is not null)
            {
                return View(department);
            }

            return Content("<h3 style='color:orange'>Department not found</h3>", "text/html");

        }
        //end Details GetDepartmentById

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (department is not null)
            {
                //check on model state and if invalid, write errors to console TODO: write to log file later
                if (!ModelState.IsValid)
                {
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
                }//end update department check
            }//end department null check

            //if null checks fail, return error message
            return Content("<h3 style='color:orange'>Department not found</h3>", "text/html");

        }//end Edit

        [HttpGet]
        public IActionResult Create() 
        {
            var content = @"
                <h2><b>Create a new Department</b></h2>
                <form method='post' action='/Departments/Create'>
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
            if (department is not null) 
            {
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
            }//end department null check

            //if null checks fail, return error message
            return Content("<h3 style='color:orange'>Department cannot be added</h3>", "text/html");


        }//end Create to add created department from form object

        [HttpPost]
        public IActionResult Delete(int departmentId) {

            var department = DepartmentsRepository.GetDepartmentById(departmentId);
            if (department is null)
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
