using RESTAPI_Employee_Management_System.Models;
using RESTAPI_Employee_Management_System.DTOModels.EmployeeDTOs;
public interface GenericCRUDServices<T>
{
    public Task<IEnumerable<T>> ReadAllAsync();
    public Task<T?> ReadByIdAsync(int id);
    public Task<T>CreateAsync(EmployeeRequestDTO entity) ;
    public Task<bool> UpdateAsync(EmployeeRequestDTO entity);
    public Task<bool> DeleteAsync(int id);




    
}
