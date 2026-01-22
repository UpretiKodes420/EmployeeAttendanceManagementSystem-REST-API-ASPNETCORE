using Microsoft.AspNetCore.JsonPatch;
using RESTAPI_Employee_Management_System.DTOModels;
using RESTAPI_Employee_Management_System.Models;

namespace RESTAPI_Employee_Management_System.Repositories
{
    public interface GenericCrud<T> 
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int Id);
        Task<bool> SetAsync(T TObject);
        Task<bool> UpdateAsync(int id, Department DepartmentObject);
        Task<bool> DeleteAsync(int id);
    }
}
