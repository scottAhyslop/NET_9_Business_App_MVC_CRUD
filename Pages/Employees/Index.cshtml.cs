using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NET_9_Business_App_MVC.CRUD.Models;
using NET_9_Business_App_MVC_CRUD.Models;

namespace NET_9_Business_App_MVC_CRUD.Pages.Employees
{
    public class IndexModel : PageModel
    {
       public List<Employee>? Employees { get; set; }
        public void OnGet()
        {
            //old method of populating list, now done by js filter
            //this.Employees = EmployeesRepository.GetEmployees().ToList();
        }

        public IActionResult OnGetEmployeesByFilter(string? filter)
        {
            return ViewComponent("EmployeeList", new { filter });
        }
    }
}
