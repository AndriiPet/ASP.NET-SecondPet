using BLL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAuthorService : IService<AuthorDto>
    {
        Task<AuthorDto> GetByIdAsync(int modelId);
        IEnumerable<AuthorDto> GetAll();
    }
}
