using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NET_9_Business_App_MVC.Models;
using NET_9_Business_App_MVC_CRUD.Models;

namespace NET_9_Business_App_MVC_CRUD.Pages.Employees
{
    public class IndexModel : PageModel
    {
        public List<Employee>? Employees { get; set; }
        public void OnGet()
        {
            this.Employees = EmployeesRepository.GetEmployees().ToList();
        }
    }
}
