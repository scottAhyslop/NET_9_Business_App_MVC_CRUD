
using NET_9_Business_App_MVC.CRUD.Models;

namespace NET_9_Business_App_MVC_CRUD.Models
{
    public static class EmployeesRepository
    {
        //Sample data for testing

        #region Sample Data
        //Sample data for the Employee Model
        private static List<Employee> _employees = new List<Employee>
            {
            new(1,"Ozzy","Osbourne", "Singer",500000, 1 ),
            new(2,"Tony", "Iommi", "Guitar Player", 500000, 2),
            new(3,"Geezer", "Butler", "Bass Player", 500000, 3),
            new(4,"Bill", "Ward", "Bongos", 500000, 4),
            new(5,"Robert", "Plant", "Vocalist", 500000, 1),
            new(6,"Jimmy", "Page", "Guitar Player", 500000, 2),
            new(7,"John Paul", "Jones", "Bass Player", 500000, 3),
            new(8,"John", "Bonham", "Drummer", 500000, 4),
            new(9,"Bruce", "Dickinson", "Vocalist", 500000, 1),
            new(10,"Dave", "Murray", "Guitar Player", 500000, 2),
            new(11,"Steve", "Harris", "Bass Player", 500000, 3),
            new(12,"Nicko", "McBrain", "Drummer", 500000, 4),
            new(13,"Adrian", "Smith", "Guitarist", 500000, 2)
            };

        #endregion

        public static List<Employee> GetEmployees(string? filter = null, int? departmentId = null)
        {
            foreach (Employee emp in _employees)
            {
                emp.EmployeeDepartment = DepartmentsRepository.GetDepartmentById(emp.DepartmentId);
            }

            if (departmentId.HasValue)
            {
                //If employeeId is not null, return the employee with that id
                return _employees.Where(emp => emp.DepartmentId == departmentId.Value).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(filter))
            {
                return _employees.Where(emp => emp.EmployeeLastName is not null && emp.EmployeeLastName.ToLower().Contains(filter.ToLower())).ToList();
            }

             return _employees;

        }
        //end GetDepartments with string filter

        //GET by Id
        public static Employee? GetEmployeeById(int employeeId)
        {
            return _employees.FirstOrDefault(emp => emp.EmployeeId == employeeId);
        }//end GetDepartmentById

        //POST Add department w/ data from form in the employee object
        public static void AddEmployee(Employee? employee)
        {
            //Check if the department is null
            if (employee is not null)
            {
                int maxId = _employees.Max(emp => emp.EmployeeId);
                employee.EmployeeId = maxId + 1;
                //Add the new employee to the list
                _employees.Add(employee);
            }
        }
        //end AddDepartment

        //POST Update department w/ data from form in the employee object
        public static bool UpdateEmployee(Employee? employee)
        {
            //null check for employee object
            if (employee is not null)
            {
                //find the employee that matches the input params' Id
                var empSelect = _employees.FirstOrDefault(emp => emp.EmployeeId == employee.EmployeeId);
                
                //null check found employee
                if (empSelect is not null)
                {
                    //if passed null check update the props
                    empSelect.EmployeeFirstName = employee.EmployeeFirstName;   
                    empSelect.EmployeeLastName = employee.EmployeeLastName;
                    empSelect.EmployeePosition = employee.EmployeePosition; 
                    empSelect.EmployeeSalary = employee.EmployeeSalary;
                    empSelect.DepartmentId = employee.DepartmentId;

                    //return that the addition was successful
                    return true;
                }//end empSelect null check
            }//end employee input param null check 
            return false;
        }
        //end UpdateEmployee

        //DELETE By DepartmentId
        public static bool DeleteEmployee(Employee? employee)
        {
            //null check for employee object
            if (employee is not null)
            {
                    // Remove the department from the list
                    _employees.Remove(employee);
                    return true;
            
            } // end department null check
            // If the department is null, return false
            return false;
        }
        //end DeleteDepartment
    }//end DepartmentsRepository
}
