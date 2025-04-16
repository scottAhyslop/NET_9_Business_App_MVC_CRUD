﻿using Microsoft.AspNetCore.Mvc;

namespace NET_9_Business_App_MVC_CRUD.Controllers
{
    public class DepartmentsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var departments = DepartmentsRepository.GetDepartments();
            var style = "<style>.center{margin:auto; width:50%; text-align:center; border: 3px solid #222;padding:1rem;}.header{text-align:left}.table{text-align:center;}  </style>";

            var output = $@"
               <div class='center'>
                    <div class='header'><h2 style='text-align:left'>Departments List</h2>
                    <a href='/Departments/Create'>Create</a></div>
                    <br/>
                    <br/>
                    <table class='table'>
                    <thead>
                      <tr>
                        <th>Department ID</th>
                        <th>Department Name</th>
                        <th>Department Location</th>
                        <th>Actions</th>
                       </tr>
                   </thead>
                    {
                        string.Join("", departments.Select(dep => $@"
                        <tr>
                            <td>{dep.DepartmentId}</td>
                            <td>{dep.DepartmentName}</td>
                            <td>{dep.DepartmentLocation}</td>
                            <td><a href='/Departments/Edit/{dep.DepartmentId}'>Edit</a></td>
                            <td><a href='/Departments/Delete/{dep.DepartmentId}'>Delete  </a></td>
                            <td><a href='/Departments/Details/{dep.DepartmentId}'>Details</a></td>
                        </tr>"))
                      }
                   <tbody>
                </div>";
            return Content(style + output, "text/html");
        }//end Index (i.e. GetDepartments)

        [HttpGet]
        public IActionResult Details(int departmentId)
        {
            var department = DepartmentsRepository.GetDepartmentById(departmentId);
            if (department is null)
            {
                return Content("<h3 style='color:orange'>Department not found</h3>", "text/html");
            }

            var style = "<style>.center{margin:auto; width:50%; text-align:center; border: 3px solid #222;padding:1rem;}.header{text-align:left}.table{text-align:center;} .details label{text-alight:left;}  </style>";

            var content = $@"
            <div class='center'>
                <h1>Department: {department.DepartmentName}'s Details</h1>
                <form class='details' method='post' action='/departments/edit'>
                    <input type='hidden', name='departmentId' value='{department.DepartmentId}'/>                    <label>Name: <input type='text' name='Name' 
                       value='{department.DepartmentName}'</label><br/><br/>
                      <label>Description: <input type='text' name='Description'
                        value='{department.DepartmentDescription}'/></label><br/><br/>
                    
                    <a href='/departments/'>Cancel</a>
                    <br/><br/>       
                    <button type='submit'>Update</button>
                </form>
            </div>";

            return Content(style+content, "text/html");
        }
    }
}
