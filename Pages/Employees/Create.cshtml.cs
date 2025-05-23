using Microsoft.AspNetCore.Mvc.RazorPages;
using NET_9_Business_App_MVC.CRUD.Models;
using NET_9_Business_App_MVC_CRUD.Models;
using NET_9_Business_App_MVC_CRUD.ViewModels;

namespace NET_9_Business_App_MVC_CRUD.Pages.Employees
{
    public class CreateModel : PageModel
    {
        public EmployeeViewModel? EmployeeViewModel { get; set; }         
        public void OnGet()
        {
            this.EmployeeViewModel = new EmployeeViewModel();
            this.EmployeeViewModel.Employee = new Employee();
            this.EmployeeViewModel.Departments = DepartmentsRepository.GetDepartments();
        }
    }
}
