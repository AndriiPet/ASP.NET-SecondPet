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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController (IAuthorService authorService)
        {
            _authorService = authorService;       
        }

       

        [HttpPost]
        [Route("AddAuthor")]
        public async Task<IActionResult> Add([FromBody] AuthorDto authorDto)
        {
            try
            {
                await _authorService.AddAsync(authorDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Add successful");
        }

        [HttpPut]
        [Route("UpdateAuthor")]
        public async Task<IActionResult> Put([FromBody] AuthorDto authorDto)
        {
            try
            {
                await _authorService.UpdateAsync(authorDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Update successful");
        }

        [HttpDelete]
        [Route("DeleteAuthor/{id}")]
        public async Task<IActionResult> Delete(int authorId)
        {
            try
            {
                await _authorService.DeleteByIdAsync(authorId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Delete successful");
        }

        [HttpGet]
        [Route("GetAuthor")]
        public IEnumerable<AuthorDto> GetBooks()
        {
            return _authorService.GetAll();
        }

        [HttpGet]
        [Route("GetAuthor/{id}")]
        public async Task<IActionResult> Get(int authorId)
        {
            try
            {
                await _authorService.GetByIdAsync(authorId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Get successful");
        }
    }
}
