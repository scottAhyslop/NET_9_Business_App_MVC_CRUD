using System.ComponentModel.DataAnnotations;

namespace NET_9_Business_App_MVC.CRUD.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        public string? EmployeeFirstName { get; set; }
        [Required]
        public string? EmployeeLastName { get; set; }
        [Required]
        public string? EmployeePosition { get; set; }
        public double? EmployeeSalary { get; set; }
        public int DepartmentId { get; set; }
        public Department? EmployeeDepartment { get; set; }        

        public Employee()
        {
            
        }

        public Employee(int employeeId, string employeeFirstName, string employeeLastName, string employeePosition, double employeeSalary, int departmentId)
        {
            this.EmployeeId = employeeId;
            this.EmployeeFirstName = employeeFirstName;
            this.EmployeeLastName = employeeLastName;
            this.EmployeePosition = employeePosition;
            this.EmployeeSalary = employeeSalary;
            this.DepartmentId = departmentId;
            
        }
    }//end Employee class
}//end namespace
