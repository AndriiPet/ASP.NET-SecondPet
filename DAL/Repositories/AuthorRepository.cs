using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ILibrareDBContext _librareDBContext;
        public AuthorRepository(ILibrareDBContext librareDBConxtex)
        {
            _librareDBContext = librareDBConxtex;
        }
        public async Task AddAsync(Author entity)
        {
            await _librareDBContext.Set<Author>().AddAsync(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            Author author = await _librareDBContext.Set<Author>().FirstOrDefaultAsync(x => x.Author_ID == id);
            _librareDBContext.Set<Author>().Remove(author);
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _librareDBContext.Set<Author>().FirstOrDefaultAsync(x => x.Author_ID == id);
        }

        public void Update(Author entity)
        {
            _librareDBContext.Set<Author>().Update(entity);
        }
        public IEnumerable<Author> GetAll()
        {
            return _librareDBContext.Set<Author>();
        }
    }
}
