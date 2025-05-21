using Microsoft.AspNetCore.Mvc;
using NET_9_Business_App_MVC_CRUD.Models;
using static System.Net.Mime.MediaTypeNames;

var HomeTestingPolicy = "_AllowHomeConnections";//testing only REMOVE FOR PRODUCTION

var builder = WebApplication.CreateBuilder(args);

#region Error Handling

//Start Response Factory for ExceptionHandling at endpoints
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
            new BadRequestObjectResult(context.ModelState)
            {
                ContentTypes =
                {
                    // using static System.Net.Mime.MediaTypeNames;
                    Application.Json,
                    Application.Xml
                }
            };
    })
    .AddXmlSerializerFormatters();
//end response factory for ExceptionHandling 

//add ExceptionFilter for handling exceptions
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<HttpResponseExceptionFilter>();
})
    .AddXmlSerializerFormatters(); //add XML serializer formatter for XML output

//add custom error handling
builder.Services.AddExceptionHandler
    (options =>
    {
        options.ExceptionHandlingPath = "/Views/Shared/DisplayErrors";
    });//end AddExceptionHandler

#endregion

//add CORS policy for testing purposes, remove for production
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: HomeTestingPolicy,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5275",
                              "http://localhost:5275/departments/*/*")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});//end CORS policy

// Add Razor Page services to the container.
builder.Services.AddRazorPages();

builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = true;
});//end AddMvc

var app = builder.Build();

//to use local files
app.UseStaticFiles();
//for endpoint processing
app.UseRouting();

//ExceptionHandling service
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Views/Shared/DisplayError");
    app.UseHsts();
}

app.UseCors();//testing only REMOVE FOR PRODUCTION 

#pragma warning disable ASP0014 // For ease of development, change to accepted b.p. for production

//Endpoints for MVC and Razor Pages
app.UseEndpoints(endpoints =>
{
    //default Home route
    endpoints.MapControllerRoute(
        name:"default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
        );
    //default Departments route
    endpoints.MapControllerRoute(
        name: "departments",
        pattern: "{controller=Departments}/{action=Index}/{departmentId?}"
        );
    //add Razor Pages functionality
    endpoints.MapRazorPages();
});

#pragma warning restore ASP0014


#region CORS Testing Area
//endpoints for Home and _departments controllers, CORS added, only for testing REMOVE FOR PRODUCTION


#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers().RequireCors(HomeTestingPolicy);

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{departmentId?}"
        ).RequireCors(HomeTestingPolicy);

    endpoints.MapControllerRoute(
        name: "departments",
        pattern: "{controller=_departments}/{action=Index}/{departmentId?}"
        ).RequireCors(HomeTestingPolicy);

});
#pragma warning restore ASP0014 // Suggest using top level route registrations

#endregion

app.MapControllers();
app.MapDefaultControllerRoute();



app.Run();
