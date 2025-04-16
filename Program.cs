var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

//add CORS policy for testing purposes, remove for production
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5275",
                              "http://localhost:5275/departments")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});//end CORS policy

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();

app.UseCors();

//endpoints for Home and Departments controllers, CORS added
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"   
    ).RequireCors(MyAllowSpecificOrigins);

app.MapControllerRoute(
    name: "departments",
    pattern: "{controller=Departments}/{action=Index}/{id?}"
    ).RequireCors(MyAllowSpecificOrigins);

app.Run();
