using Microsoft.AspNetCore.Mvc;

namespace NET_9_Business_App_MVC_CRUD.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            var departments = DepartmentsRepository.GetDepartments();
            var output = $@"
               <div class='center'>
                    <h1>Departments</h1>
                    <a href='/Departments/Create'>Create New Department</a>
                    <h1>Departments</h1>
                    <table class='table'>
                    <thead>
                      <tr>
                        <th>Department ID</th>
                        <th>Department Name</th>
                        <th>Department Location</th>
                       </tr>
                   </thead>
                    {
                        string.Join("", departments.Select(dep => $@"<tr>
                            <td>{dep.DepartmentId}</td>
                            <td>{dep.DepartmentName}</td>
                            <td>{dep.DepartmentLocation}</td>
                            <td><a href='/Departments/Edit/{dep.DepartmentId}'>Edit</a></td>
                            <td><a href='/Departments/Delete/{dep.DepartmentId}'>Delete</a></td></tr>"))
                      }
                   <tbody>
                </div>";
            return Content(output, "text/html");
        }
    }
}
