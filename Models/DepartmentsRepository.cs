using NET_9_Business_App_MVC.Models;
using System.Xml.Linq;

namespace NET_9_Business_App_MVC_CRUD.Models
{
    public static class DepartmentsRepository
    {
        //Sample data for testing
        private static List<Department> _departments = new List<Department>
        {
        new (1,"Amplified Voice",  "Ottawa St.", "Selling amps, microphones, and mixing boards", 50000),
        new (2,"Guitars",  "Ottawa St.", "Selling amps, guitars, and effects pedals", 150000),
        new (3,"Basses", "Ottawa St.", "Selling amps, basses, and effects pedals", 75000),
        new (4,"Percussion", "Ottawa St.", "Selling drums, bongos, and cymbals", 850000),
        };

        //GET
        public static List<Department> GetDepartments(string? filter = null) 
        {
            if(string.IsNullOrWhiteSpace(filter)) return _departments;
            else
            {
                //Filter the departments based on the filter string
                return _departments.Where(dep => dep.DepartmentName?.Contains(filter, StringComparison.OrdinalIgnoreCase) == true).ToList();
            }

        }//end GetDepartments with string filter

        //GET by Id
        public static Department? GetDepartmentById(int id)
        {
                return _departments.FirstOrDefault(dep => dep.DepartmentId == id);
        }//end GetDepartmentById

        //POST Add department
        public static void AddDepartment(Department? department)
        {
            //Check if the department is null
            if (department is null)
            {
                //If it is, return
                return;
            }
            else
            {
                int maxId = _departments.Max(dep => dep.DepartmentId);
                department.DepartmentId = maxId + 1;
                department.DepartmentName = department.DepartmentName;
                department.DepartmentLocation = department.DepartmentLocation;
                department.DepartmentDescription = department.DepartmentDescription;
                department.DepartmentAnnualSales = department.DepartmentAnnualSales;
                //Add the new department to the list
                _departments.Add(department);
            }
        }
        //end AddDepartment

        //POST Update department
        public static bool UpdateDepartment(Department? department)
        {
            if (department is not null)
            {
                var depSelect = _departments.FirstOrDefault(dep => dep.DepartmentId == department.DepartmentId);
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

        //DELETE By DepartmentId
        public static bool DeleteDepartment(Department? department)
        {
            if (department is not null)
            {
                // Find the department to delete in the _departments list
                var delDep = _departments.FirstOrDefault(dep => dep.DepartmentId == department.DepartmentId);
                if (delDep is not null)
                {
                    // Remove the department from the list
                    _departments.Remove(delDep);
                    return true;
                }
                else
                {
                    // If the department is not found, return false
                    return false;
                } // end delDep null check
            } // end department null check
            // If the department is null, return false
            return false;
        }
        //end DeleteDepartment

    }//end DepartmentsRepository
}//end namespace NET_9_Business_App_MVC_CRUD.Controllers
