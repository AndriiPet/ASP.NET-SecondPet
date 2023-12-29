using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EmployeeRepository :IEmployeeRepository
    {
        private readonly ILibrareDBContext _librareDBContext;
        public EmployeeRepository(ILibrareDBContext librareDBConxtex)
        {
            _librareDBContext = librareDBConxtex;
        }

        public async Task AddAsync(Employee entity)
        {
            await _librareDBContext.Set<Employee>().AddAsync(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            Employee employee = await _librareDBContext.Set<Employee>().FirstOrDefaultAsync(x => x.Employee_ID == id);
            _librareDBContext.Set<Employee>().Remove(employee);
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _librareDBContext.Set<Employee>().FirstOrDefaultAsync(x => x.Employee_ID == id);
        }

        public void Update(Employee entity)
        {
            _librareDBContext.Set<Employee>().Update(entity);
        }
        public IEnumerable<Employee> GetAll()
        {
            return _librareDBContext.Set<Employee>();
        }
    }
}
