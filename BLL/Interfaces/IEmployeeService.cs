using BLL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEmployeeService : IService<EmployeeDto>
    {
        IEnumerable<EmployeeDto> GetAll();
    }
}
