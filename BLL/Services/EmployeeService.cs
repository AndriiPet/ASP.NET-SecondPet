using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BLL.Services
{
    public class EmployeeService :IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(EmployeeDto model)
        {
            Employee mappedEmployee = _mapper.Map<EmployeeDto, Employee>(model);
            if (mappedEmployee == null)
            {
                throw new System.Exception("Employee wasn't found");
            }
            else
            {
                await _unitOfWork.EmployeeRepository.AddAsync(mappedEmployee);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            Employee mappedEmployee = await _unitOfWork.EmployeeRepository.GetByIdAsync(modelId);
            if (mappedEmployee == null)
            {
                throw new System.Exception("Employee wasn't found");
            }
            else
            {
                await _unitOfWork.EmployeeRepository.DeleteByIdAsync(modelId);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task UpdateAsync(EmployeeDto model)
        {
            Employee mappedEmployee = _mapper.Map<EmployeeDto, Employee>(model);
            if (mappedEmployee == null)
            {
                throw new System.Exception("Employee wasn't found");
            }
            else
            {
                _unitOfWork.EmployeeRepository.Update(mappedEmployee);
                await _unitOfWork.SaveAsync();
            }
        }
        public IEnumerable<EmployeeDto> GetAll()
        {
            return _unitOfWork.EmployeeRepository.GetAll().Select(x => _mapper.Map<Employee, EmployeeDto>(x));
        }
    }
}
