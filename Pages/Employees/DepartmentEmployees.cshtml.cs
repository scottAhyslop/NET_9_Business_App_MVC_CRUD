using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NET_9_Business_App_MVC_CRUD.Controllers;

namespace NET_9_Business_App_MVC_CRUD.Pages.Employees
{
    public class DepartmentEmployeesModel : PageModel
    {
        public string? DepartmentName { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? DepartmentId{ get; set; }
        public void OnGet()
        {
            if (DepartmentId.HasValue)
            {
                var department = DepartmentsRepository.GetDepartmentById(DepartmentId.Value);
                DepartmentName = department?.DepartmentName;
                DepartmentId = department?.DepartmentId;
            }
            else
            {
                RedirectToPage("/DisplayErrors");
            }
        }
    }
}
