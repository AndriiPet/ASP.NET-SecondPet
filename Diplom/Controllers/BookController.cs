using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diplom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        

        [HttpPost]
        [Route("AddBook")]
        public async Task<BookDto> AddBook([FromBody] BookDto bookDto)
        {
            await _bookService.AddAsync(bookDto);
            return bookDto;
        }

        [HttpPut]
        [Route("UpdateBook")]
        public async Task<BookDto> Update( BookDto bookDto)
        {
            await _bookService.UpdateAsync(bookDto);
            return bookDto;
        }
        [HttpDelete]
        [Route("DeleteBook")]
        public async Task<bool> Delete(int id)
        {
            bool a = true;
            try
            {
                await _bookService.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                a = false;
            }
            return a;
        }

        [HttpGet]
        [Route("GetAuthorByBookID")]
        public async Task<AuthorDto> GetAuthor(int id)
        {
            return await _bookService.GetAuthorByID(id);
        }

        [HttpGet]
        [Route("GetBook")]
        public IEnumerable<BookDto> GetBooks()
        {
            return  _bookService.GetAll();
        }
    }
}
