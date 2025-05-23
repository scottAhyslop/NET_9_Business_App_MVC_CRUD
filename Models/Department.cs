using System.ComponentModel.DataAnnotations;

namespace NET_9_Business_App_MVC.CRUD.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        //[Required(ErrorMessage = "_departments Name is required")]
        public string? DepartmentName { get; set; }
        public string? DepartmentLocation { get; set; }
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
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
