using Microsoft.EntityFrameworkCore;
using SchoolApplication.Data;
using SchoolApplication.Models;
using SchoolApplication.Repositories.DbRepositories;
using SchoolApplication.Repositories.Interfaces;
using SchoolApplication.Repositories.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDb"))
);

builder.Services.AddDbContext<AuthContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthDb"))
);

//la configuration pour l'auth
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AuthContext>();


builder.Services.AddScoped<IGenericRepository<Student>, StudentDbRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddScoped<IGenericRepository<Course>, CourseDbRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddScoped<IGenericRepository<Grade>, GradeDbRepository>();
builder.Services.AddScoped<IGradeService, GradeService>();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
