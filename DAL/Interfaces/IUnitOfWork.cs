using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        Task<int> SaveAsync();

    }
}
