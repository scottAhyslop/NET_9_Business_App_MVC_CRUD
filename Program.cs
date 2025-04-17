var HomeTestingPolicy = "_AllowHomeConnections";//testing only REMOVE FOR PRODUCTION

var builder = WebApplication.CreateBuilder(args);

//add CORS policy for testing purposes, remove for production
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: HomeTestingPolicy,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5275",
                              "http://localhost:5275/Departments/{Controller}/{Id}")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});//end CORS policy

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseRouting();

#region CORS Testing Area
//endpoints for Home and Departments controllers, CORS added, only for testing REMOVE FOR PRODUCTION
app.UseCors();//testing only REMOVE FOR PRODUCTION 

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{departmentId?}"
        ).RequireCors(HomeTestingPolicy);

    endpoints.MapControllers().RequireCors(HomeTestingPolicy);

    endpoints.MapControllerRoute(
        name: "departments",
        pattern: "{controller=Departments}/{action=Index}/{departmentId?}"
        ).RequireCors(HomeTestingPolicy);

});
#pragma warning restore ASP0014 // Suggest using top level route registrations

#endregion



app.Run();
