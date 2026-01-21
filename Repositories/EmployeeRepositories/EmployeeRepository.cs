using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RESTAPI_Employee_Management_System.Models;

namespace RESTAPI_Employee_Management_System.Repositories
{
    public class EmployeeRepository : IEmployeeRepository

    {
        private readonly EmployeeDbContext _context;
        public EmployeeRepository(EmployeeDbContext context )
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()//Hadi Ghoptey method Read/Fetch all employeess
        {
            return await _context.Employees.Include(e => e.Department).ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int Id)//Read/fetch an specific employee

        {
            
            var Employee =  await _context.Employees.Include(e=>e.Department).FirstOrDefaultAsync(emp=>emp.Id==Id);
            return Employee;

            
        }

        public async Task SetEmployeeAsync(Employee employeeObject)//Create/Register the employee 
        {
            
              await _context.Employees.AddAsync(employeeObject);
              await    _context.SaveChangesAsync();
            
            
        }

        public async Task<bool> UpdateEmployeeAsync(Employee employeeObjectWithUpdateParams)//Update employee
        {
            var employee = await _context.Employees.FindAsync(employeeObjectWithUpdateParams.Id);
            if (employee == null)
            {
                return false;// maaf garnu hola tapaile samparka khojnu vayeko vayeko employee vetiyena :(
            }
            employee.FirstName = employeeObjectWithUpdateParams.FirstName;
            employee.LastName = employeeObjectWithUpdateParams.LastName;
            employee.ContactAddress = employeeObjectWithUpdateParams.ContactAddress;
            employee.EmailAddress = employeeObjectWithUpdateParams.ContactAddress;
            employee.Gender = employeeObjectWithUpdateParams.Gender;
            employee.Department = employeeObjectWithUpdateParams.Department;
            employee.DepartmentId = employeeObjectWithUpdateParams.DepartmentId;

            await _context.SaveChangesAsync();
            return true;

        }
        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employeeObject=await _context.Employees.FindAsync(id);
            if (employeeObject==null)
            {
                return false;//maaf garnu hola tapai le delete garna khojnu vayeko employee upalabdha huna sakena
            }

            _context.Employees.Remove(employeeObject);
            await _context.SaveChangesAsync();
            return true;
        }
    }

    
}
