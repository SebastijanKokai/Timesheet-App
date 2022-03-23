using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Timesheet_API.Models.Data;
using Timesheet_API.Models.Middleware;
using Timesheet_API.Models.Profiles;
using Timesheet_API.Repositories.CategoryRepo;
using Timesheet_API.Repositories.ClientRepo;
using Timesheet_API.Repositories.CountryRepo;
using Timesheet_API.Repositories.LeadProjectRepo;
using Timesheet_API.Repositories.ProjectRepo;
using Timesheet_API.Repositories.ProjectTaskRepo;
using Timesheet_API.Repositories.RoleRepo;
using Timesheet_API.Repositories.UserProjectRepo;
using Timesheet_API.Repositories.UserRepo;
using Timesheet_API.Services.CategoryServices;
using Timesheet_API.Services.ClientServices;
using Timesheet_API.Services.CountryServices;
using Timesheet_API.Services.LeadProjectServices;
using Timesheet_API.Services.ProjectServices;
using Timesheet_API.Services.RoleServices;
using Timesheet_API.Services.TaskServices;
using Timesheet_API.Services.UserProjectServices;
using Timesheet_API.Services.UserServices;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddDbContext<timesheet_dbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Timesheet_DB"));
});



builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserServices, UserServices>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleServices, RoleServices>();

builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryServices, CountryServices>();

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientServices, ClientServices>();

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectServices, ProjectServices>();

builder.Services.AddScoped<IUserProjectRepository, UserProjectRepository>();
builder.Services.AddScoped<IUserProjectServices, UserProjectServices>();

builder.Services.AddScoped<ILeadProjectRepository, LeadProjectRepository>();
builder.Services.AddScoped<ILeadProjectServices, LeadProjectServices>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();

builder.Services.AddScoped<IProjectTaskRepository, ProjectTaskRepository>();
builder.Services.AddScoped<IProjectTaskServices, ProjectTaskServices>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new ClientPostProfile());
    mc.AddProfile(new ClientUpdateProfile());
    mc.AddProfile(new ProjectPostProfile());
    mc.AddProfile(new ProjectUpdateProfile());
    mc.AddProfile(new ProjectTaskPostProfile());
    mc.AddProfile(new ProjectTaskUpdateProfile());
    mc.AddProfile(new UserPostProfile());
    mc.AddProfile(new UserUpdateProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configuring CORS
builder.Services.AddCors();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));

builder.Configuration
    .SetBasePath(app.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{app.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if(app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/error-development");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
