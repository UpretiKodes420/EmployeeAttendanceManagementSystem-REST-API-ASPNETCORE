using Microsoft.AspNetCore.JsonPatch;
using RESTAPI_Employee_Management_System.DTOModels.EmployeeDTOs;
using RESTAPI_Employee_Management_System.Models;
public interface GenericCRUDServices<T>
{
    public Task<IEnumerable<T>> ReadAllAsync();
    public Task<T?> ReadByIdAsync(int id);
    public Task<T>CreateAsync(EmployeeRequestDTO entity) ;
    public Task<bool> UpdateAsync(int id, JsonPatchDocument<EmployeeRequestDTO> PatchDoc);
    public Task<bool> DeleteAsync(int id);




    
}
