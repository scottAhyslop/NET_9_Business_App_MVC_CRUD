using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NET_9_Business_App_MVC.CRUD.Models;
using NET_9_Business_App_MVC_CRUD.Models;
using NET_9_Business_App_MVC_CRUD.ViewModels;

namespace NET_9_Business_App_MVC_CRUD.Pages.Employees
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public EmployeeViewModel? EmployeeViewModel { get; set; }
        public void OnGet()
        {
            this.EmployeeViewModel = new EmployeeViewModel
            {
                Employee = new Employee(),
                Departments = DepartmentsRepository.GetDepartments()
            };
        }

        public IActionResult OnPost()
        {
           /* if (!ModelState.IsValid)
            {
                return RedirectToPage("DisplayErrors");
            }*/
            if (this.EmployeeViewModel is not null && EmployeeViewModel.Employee is not null)
            {
                EmployeesRepository.AddEmployee(this.EmployeeViewModel.Employee);
            }
            return RedirectToPage("Index");
        }
    }//end Create PageModel
}//end namespace
