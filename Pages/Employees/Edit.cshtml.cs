using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NET_9_Business_App_MVC.CRUD.Models;
using NET_9_Business_App_MVC_CRUD.Helpers;
using NET_9_Business_App_MVC_CRUD.Models;
using NET_9_Business_App_MVC_CRUD.ViewModels;

namespace NET_9_Business_App_MVC_CRUD.Pages.Employees
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EmployeeViewModel? EmployeeViewModel { get; set; }

        //when page is loaded, returns a Employee Page, based on input param
        public void OnGet(int employeeId)
        {
            //instantiate the EmployeeViewModel
            this.EmployeeViewModel = new EmployeeViewModel();
            //load the VM with the selected Employee from ER
            this.EmployeeViewModel.Employee = EmployeesRepository.GetEmployeeById(employeeId);
            //load the VM with all Departments to be selected in Page
            this.EmployeeViewModel.Departments = DepartmentsRepository.GetDepartments();

        }//end OnGet <!--working-->

        //when form is submitted, it returns an employee object here
        public IActionResult OnPost(Employee employee)
        {
            //check if ModelState is valid, otherwise direct to Errors
            if (!ModelState.IsValid)
            {
                var errors = ModelStateHelper.GetErrors(ModelState);
                return RedirectToPage("/Errors", new { errors });
            }//end invalid check for errors

            //another null check on both EmployeeView Model and the Employee within
            if (EmployeeViewModel is not null &&
                EmployeeViewModel.Employee is not null)
            {
                //Update the Employee
                EmployeesRepository.UpdateEmployee(EmployeeViewModel.Employee);
            }

            //if successful, return to the Index page, showing the new employee
            return RedirectToPage("Index");
        }//end OnPost(Employee employee)

    }//end Edit PageModel

}//end namespace
