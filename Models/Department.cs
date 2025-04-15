using System.ComponentModel.DataAnnotations;

namespace NET_9_Business_App_MVC.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string? DepartmentLocation { get; set; }
        public string? DepartmentDescription { get; set; }
        public double? DepartmentAnnualSales { get; set; }
        public List<Employee>? DepartmentEmployees { get; set; }
        public List<InventoryInvoice>? DepartmentInvoices { get; set; }
        public List<Inventory>? DepartmentItems { get; set; }
        public List<Customer>? DepartmentCustomers { get; set; }

        public Department()
        {

        }

        public Department(int departmentId, string? departmentName, string? departmentLocation, string? departmentDescription, double departmentAnnualSales)
        {
            DepartmentId = departmentId;
            DepartmentName = departmentName;
            DepartmentLocation = departmentLocation;
            DepartmentDescription = departmentDescription;
            DepartmentAnnualSales = departmentAnnualSales;
        }
    }
}
/*
 public Department()
        {
            
        }

        public Department(int id, string name, string? description = "")
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }
 
 
 */