using Domain.Models;
using Domain.Repositories;
using Domain.Repositories.AttendanceRepository;
using Domain.Repositories.DepartmentRepositories;
using Domain.Repositories.EmployeeRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Services.AttendanceServices;
using Services.DepartmentServices;
using Services.DTOModels.EmployeeDTOs;
using Services.EmployeeServices;
using Services.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<EmsdbContext>((options) =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
       sql=>sql.MigrationsAssembly("Domain") );
    options.LogTo(Console.WriteLine, LogLevel.Information);

});
builder.Services.AddSwaggerGenNewtonsoftSupport();


builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
builder.Services.AddScoped<GenericCrud<Department>, DepartmentRepository>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();

builder.Services.AddScoped<EmployeeMapper>();
builder.Services.AddScoped<DepartmentMapper>();
builder.Services.AddScoped<AttendanceMapper>();
builder.Services.AddScoped<GenericCRUDServices<EmployeeResponseDTO>,EmployeeServices>();
builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
builder.Services.AddScoped<IAttendanceServices, AttendanceServices>();
builder.Services.AddScoped<IAttendanceServices, AttendanceServices>();

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
