using Microsoft.AspNetCore.Mvc;
using NET_9_Business_App_MVC_CRUD.Models;

namespace NET_9_Business_App_MVC_CRUD.Pages.Shared.Components.EmployeeList
{
    public class EmployeeListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string? filter, int? departmentId)
            {
                //get a list of sample test _employees from the repository based on filter and return them to the View
            
                return View(EmployeesRepository.GetEmployees(filter, departmentId));

            } //end Invoke (i.e. GetEmployees)
    }//end EmployeeListViewComponent
}//end namespace NET_9_Business_App_MVC_CRUD.Pages.Shared.Components.EmployeeList
