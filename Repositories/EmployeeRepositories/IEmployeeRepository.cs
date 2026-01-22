using RESTAPI_Employee_Management_System.Models;

namespace RESTAPI_Employee_Management_System.Repositories
{
    public interface IEmployeeRepository
    {
      Task<IEnumerable<Employee>> GetAllAsync();
      Task<Employee?> GetByIdAsync(int Id);
        Task SetEmployeeAsync(Employee employeeObject);
        Task<bool> UpdateEmployeeAsync(int id,Employee employeeObjectWithUpdateParams);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}
