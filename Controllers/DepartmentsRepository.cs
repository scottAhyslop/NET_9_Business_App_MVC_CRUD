using NET_9_Business_App_MVC.Models;
using System.Xml.Linq;

namespace NET_9_Business_App_MVC_CRUD.Controllers
{
    public static class DepartmentsRepository
    {
        //Sample data for testing
        private static List<Department> Departments = new List<Department>
        {
        new Department(1,"Amplified Voice",  "Ottawa St.", "Selling amps, microphones, and mixing boards", 50000),
        new Department(2,"Guitars",  "Ottawa St.", "Selling amps, guitars, and effects pedals", 150000),
        new Department(3,"Basses", "Ottawa St.", "Selling amps, basses, and effects pedals", 75000),
        new Department(4,"Percussion", "Ottawa St.", "Selling drums, bongos, and cymbals", 850000),
        };

        //GET
        public static List<Department> GetDepartments() => Departments;

        //GET by Id
        public static Department? GetDepartmentById(int id)
        {
            return Departments.FirstOrDefault(dep => dep.DepartmentId == id);
        }
        //POST Add department
        public static void AddDepartment(Department? Department)
        {
            if (Department is not null)
            {
                int maxId = Departments.Max(dep => dep.DepartmentId);
                Department.DepartmentId = maxId + 1;
                Departments.Add(Department);
            }
        }

        public static bool UpdateDepartment(Department? Department)
        {
            if (Department is not null)
            {
                var emp = Departments.FirstOrDefault(dep => dep.DepartmentId == Department.DepartmentId);
                if (emp is not null)
                {
                    emp.DepartmentName = Department.DepartmentName;
                    emp.DepartmentLocation = Department.DepartmentLocation;
                    emp.DepartmentDescription = Department.DepartmentDescription;                   

                    return true;
                }
            }
            return false;
        }

        public static bool DeleteDepartment(Department? Department)
        {
            if (Department is not null)
            {
                Departments.Remove(Department);
                return true;
            }

            return false;
        }
    }
}
