using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ILibrareDBContext _librareDBContext;
        public BookRepository(ILibrareDBContext librareDBConxtex)
        {
            _librareDBContext = librareDBConxtex;
        }


        public async Task AddAsync(Book entity)
        {
            await _librareDBContext.Set<Book>().AddAsync(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            Book book = await _librareDBContext.Set<Book>().FirstOrDefaultAsync(x => x.Book_ID == id);
            _librareDBContext.Set<Book>().Remove(book);
            
        }

        public IEnumerable<Book> GetAll()
        {
            return _librareDBContext.Set<Book>().Include(x => x.author);
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _librareDBContext.Set<Book>().FirstOrDefaultAsync(x => x.Book_ID == id);
        }

        public void Update(Book entity)
        {
            _librareDBContext.Set<Book>().Update(entity);
        }
    }
}
