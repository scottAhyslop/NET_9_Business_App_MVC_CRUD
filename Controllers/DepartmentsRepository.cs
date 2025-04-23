using NET_9_Business_App_MVC.Models;
using System.Xml.Linq;

namespace NET_9_Business_App_MVC_CRUD.Controllers
{
    public static class DepartmentsRepository
    {
        //Sample data for testing
        private static List<Department> Departments = new List<Department>
        {
        new (1,"Amplified Voice",  "Ottawa St.", "Selling amps, microphones, and mixing boards", 50000),
        new (2,"Guitars",  "Ottawa St.", "Selling amps, guitars, and effects pedals", 150000),
        new (3,"Basses", "Ottawa St.", "Selling amps, basses, and effects pedals", 75000),
        new (4,"Percussion", "Ottawa St.", "Selling drums, bongos, and cymbals", 850000),
        };

        //GET
        public static List<Department> GetDepartments() => Departments;

        //GET by Id
        public static Department? GetDepartmentById(int id)
        {
                return Departments.FirstOrDefault(dep => dep.DepartmentId == id);
        }//end GetDepartmentById

        //POST Add department
        public static void AddDepartment(Department? department)
        {
                int maxId = Departments.Max(dep => dep.DepartmentId);
                department.DepartmentId = maxId + 1;
                department.DepartmentName = department.DepartmentName;
                department.DepartmentLocation = department.DepartmentLocation;
                department.DepartmentDescription = department.DepartmentDescription;
                department.DepartmentAnnualSales = department.DepartmentAnnualSales;
                //Add the new department to the list
                Departments.Add(department);
        }
        //end AddDepartment

        //PUT Update department
        public static bool UpdateDepartment(Department? department)
        {
            if (department is not null)
            {
                var depSelect = Departments.FirstOrDefault(dep => dep.DepartmentId == department.DepartmentId);
                if (depSelect is not null)
                {
                    depSelect.DepartmentName = department.DepartmentName;
                    depSelect.DepartmentLocation = department.DepartmentLocation;
                    depSelect.DepartmentDescription = department.DepartmentDescription;
                    depSelect.DepartmentAnnualSales = department.DepartmentAnnualSales;
                }//end depSelect null check
                return true;
            }//end department null check
            return false;
        }
        //end pdateDepartment

        //DELETE removes selected item from list 
        public static bool DeleteDepartment(Department? department)
        {
           var departments = GetDepartments();
           //find the department to delete in departments list
           var delDep = departments.FirstOrDefault(dep => dep.DepartmentId == department.DepartmentId);
           //remove the selected department from the list
           departments.Remove(delDep);
            return true;
         }
        //end DeleteDepartment

    }//end DepartmentsRepository

}//end namespace NET_9_Business_App_MVC_CRUD.Controllers
