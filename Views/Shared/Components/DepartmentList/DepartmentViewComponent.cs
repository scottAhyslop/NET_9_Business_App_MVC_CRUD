using Microsoft.AspNetCore.Mvc;
using NET_9_Business_App_MVC_CRUD.Controllers;

namespace NET_9_Business_App_MVC_CRUD.Views.Shared.Components.DepartmentList
{
    public class DepartmentListViewComponent : ViewComponent
    {
        
        public IViewComponentResult Invoke()
        {
            var departments = DepartmentsRepository.GetDepartments();
            return View(departments);
        }

    }
}
