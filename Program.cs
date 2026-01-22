using Microsoft.EntityFrameworkCore;
using RESTAPI_Employee_Management_System.DTOModels.EmployeeDTOs;
using RESTAPI_Employee_Management_System.Models;
using RESTAPI_Employee_Management_System.Repositories;
using RESTAPI_Employee_Management_System.Repositories.DepartmentRepositories;
using RESTAPI_Employee_Management_System.Services;
using RESTAPI_Employee_Management_System.Services.DepartmentServices;
using RESTAPI_Employee_Management_System.Services.EmployeeServices;
using RESTAPI_Employee_Management_System.Services.Mappers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<EmsdbContext>((options) =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddSwaggerGenNewtonsoftSupport();


builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
builder.Services.AddScoped<GenericCrud<Department>, DepartmentRepository>();
builder.Services.AddScoped<EmployeeMapper>();
builder.Services.AddScoped<DepartmentMapper>();
builder.Services.AddScoped<GenericCRUDServices<EmployeeResponseDTO>,EmployeeServices>();
builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
builder.Services.AddControllers()
    .AddNewtonsoftJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
