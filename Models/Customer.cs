namespace NET_9_Business_App_MVC.Models
{
    public class Customer
    {
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerAddress { get; set; }
        public string? CustomerCity { get; set; }
        public string? CustomerProvince { get; set; }
        public string? CustomerPostalCode { get; set; }
        public string? CustomerCountry { get; set; }
        public string? CustomerNotes { get; set; }
        public string? CustomerSince { get; set; }
        public List<InventoryInvoice>? CustomerInvoices { get; set; }
        public List<Department>? CustomerDepartments { get; set; }
    }
    public class CustomerList
    {
        public List<Customer> Customers { get; set; }
        public CustomerList()
        {
            Customers = new List<Customer>();
        }
    }

}