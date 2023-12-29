using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diplom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> Add([FromBody] EmployeeDto employeeDto)
        {
            try
            {
                await _employeeService.AddAsync(employeeDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Add successful");
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> Put([FromBody] EmployeeDto employeeDto)
        {
            try
            {
                await _employeeService.UpdateAsync(employeeDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Update successful");
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<IActionResult> Delete(int employeeId)
        {
            try
            {
                await _employeeService.DeleteByIdAsync(employeeId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Delete successful");
        }
        [HttpGet]
         
        [Route("GetEmployee")]
        public IEnumerable<EmployeeDto> GetEmployee()
        {
            return _employeeService.GetAll();
        }
    }
}
