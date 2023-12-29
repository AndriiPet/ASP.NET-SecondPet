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
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(BookDto model)
        {
            Book mappedBook = _mapper.Map<BookDto, Book>(model);

            if (mappedBook == null)
            {
                throw new System.Exception("Book wasn't found");
            }
            {
                await _unitOfWork.BookRepository.AddAsync(mappedBook);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            Book mappedBook = await _unitOfWork.BookRepository.GetByIdAsync(modelId);
            if (mappedBook == null)
            {
                throw new System.Exception("Book wasn't found");
            }
            else
            {
                await _unitOfWork.BookRepository.DeleteByIdAsync(modelId);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<BookDto> GetByIdAsync(int modelId)
        {
            Book mappedBook = await _unitOfWork.BookRepository.GetByIdAsync(modelId);
            if (mappedBook == null)
            {
                throw new System.Exception("Book wasn't found");
            }
            else
            {
                return _mapper.Map<Book, BookDto>(mappedBook);
            }
        }

        public IEnumerable<BookDto> GetAll()
        {
            return _unitOfWork.BookRepository.GetAll().Select(x => _mapper.Map<Book, BookDto>(x));
        }
        public async Task UpdateAsync(BookDto model)
        {
            Book mappedBook = _mapper.Map<BookDto, Book>(model);
            if (mappedBook == null)
            {
                throw new System.Exception("Book wasn't found");
            }
            else {
                _unitOfWork.BookRepository.Update(mappedBook);
                await _unitOfWork.SaveAsync();
                 }
        }

        public async Task<AuthorDto> GetAuthorByID(int modelId)
        {
            Book mappedBook = await _unitOfWork.BookRepository.GetByIdAsync(modelId);
            if (mappedBook == null)
            {
                throw new System.Exception("Book wasn't found");
            }
            else
            {
                Author mappedAuthor = await _unitOfWork.AuthorRepository.GetByIdAsync(mappedBook.Author_ID);
                return _mapper.Map<Author, AuthorDto>(mappedAuthor);
            }
        }
    }
}
