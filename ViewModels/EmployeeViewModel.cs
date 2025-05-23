using NET_9_Business_App_MVC.CRUD.Models;

namespace NET_9_Business_App_MVC_CRUD.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee? Employee { get; set; }
        public List<Department>? Departments { get; set; }
    }
}
