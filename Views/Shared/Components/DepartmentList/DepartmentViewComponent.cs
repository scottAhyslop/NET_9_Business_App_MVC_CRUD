using Microsoft.AspNetCore.Mvc;
using NET_9_Business_App_MVC_CRUD.Controllers;

namespace NET_9_Business_App_MVC_CRUD.Views.Shared.Components.DepartmentList
{
    public class DepartmentListViewComponent : ViewComponent
    {
        
        public IViewComponentResult Invoke(string? filter)
        {
            var departments = DepartmentsRepository.GetDepartments(filter);
            return View(departments);
        }

    }
}
