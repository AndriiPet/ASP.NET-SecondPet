using BLL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBookService :IService<BookDto>
    {
        Task<BookDto> GetByIdAsync(int modelId);
        IEnumerable<BookDto> GetAll();
        Task<AuthorDto> GetAuthorByID(int modelId);
    }
}
