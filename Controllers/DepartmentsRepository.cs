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
                Department.DepartmentName = Department.DepartmentName;
                Department.DepartmentLocation = Department.DepartmentLocation;
                Department.DepartmentDescription = Department.DepartmentDescription;
                Department.DepartmentAnnualSales = Department.DepartmentAnnualSales;
                //Add the new department to the list
                Departments.Add(Department);
            }//end Department null check
        }//end AddDepartment

        //PUT Update department
        public static bool UpdateDepartment(Department? Department)
        {
            //null check for passed in Department
            if (Department is not null)
            {
                //if Department is not null get a current list of departments
                var departments = GetDepartments();
                //null check for departments list
                if (departments is not null) 
                {
                    //find the department to update in departments list
                    var updateDep = departments.FirstOrDefault(dep => dep.DepartmentId == Department.DepartmentId);
                    if (updateDep is not null)
                    {
                        //Update entered properties from passed in form data
                        updateDep.DepartmentName = Department.DepartmentName;
                        updateDep.DepartmentLocation = Department.DepartmentLocation;
                        updateDep.DepartmentDescription = Department.DepartmentDescription;
                        return true;
                    }//end updateDep null check
                }//end departments null check
            }//end Department null check
            //if any of the above checks fail return false
            return false;
        }//end UpdateDepartment

        //DELETE removes selected item from list 
        public static bool DeleteDepartment(Department? Department)
        {
            //null check for passed in Department
            if (Department is not null)
            {
                //get a current list of departments
                var departments = GetDepartments();

                //null check for departments list
                if (departments is not null)
                {
                    //find the department to delete in departments list
                    var delDep = departments.FirstOrDefault(dep => dep.DepartmentId == Department.DepartmentId);
                    //make sure selected department is not null
                    if (delDep is not null)
                    {
                        //remove the selected department from the list
                        departments.Remove(delDep);
                        return true;
                    }//end delDep null check
                }//end departments null check
            }//end Department null check
            return false;//anything falls through is returned as null
        }//end DeleteDepartment

    }//end DepartmentsRepository
}//end namespace
