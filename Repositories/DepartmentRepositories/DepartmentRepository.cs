
using Microsoft.EntityFrameworkCore;
using RESTAPI_Employee_Management_System.Models;
using System.Linq;
using System.Collections;

namespace RESTAPI_Employee_Management_System.Repositories.DepartmentRepositories
{
    public class DepartmentRepository : GenericCrud<Department>
    {
        private readonly EmsdbContext _DepartmentContext;
        public DepartmentRepository(EmsdbContext DepartmentContext) { 
            _DepartmentContext = DepartmentContext;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var Department = await _DepartmentContext.Departments.FindAsync(id);
            if (Department == null)
            {
                return false;
            }
            _DepartmentContext.Departments.Remove(Department);
            _DepartmentContext.SaveChanges();
            return true;

        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            var departments = await _DepartmentContext.Departments.Include(e=>e.Employees).ToListAsync();
            return departments;
        }

        public async Task<Department?> GetByIdAsync(int Id)
        {
            var DepartmentById = await _DepartmentContext.Departments.FindAsync(Id);
            return DepartmentById;
        }

        

        public  async Task<bool> SetAsync(Department TObject)
        {
            try
            {
                await _DepartmentContext.Departments.AddAsync(TObject);
                int rowsAffected = await _DepartmentContext.SaveChangesAsync();
                if (rowsAffected > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return false;


        }   

        public async Task<bool> UpdateAsync(int id,Department TObjectWithUpdateParams)
        {
            var updatable = await _DepartmentContext.Departments.FindAsync(id);
            if(updatable == null)
            {
                return false;
            }
            updatable.DepartmentName = TObjectWithUpdateParams.DepartmentName;
            _DepartmentContext.SaveChanges();

            return true;
        }

        
    }
}
