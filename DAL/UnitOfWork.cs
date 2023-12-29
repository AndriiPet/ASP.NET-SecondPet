using DAL.Interfaces;
using DAL.Repositories;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ILibrareDBContext _librareDBConxtex;
        private IBookRepository _bookRepository;
        private IAuthorRepository _authorrRepository;
        private IEmployeeRepository _employeeRepository;

        public UnitOfWork(ILibrareDBContext librareDBConxtex)
        {
            _librareDBConxtex = librareDBConxtex;
        }

        public IBookRepository BookRepository
        {
            get
            {
                if (_bookRepository == null)
                {
                    _bookRepository = new BookRepository(_librareDBConxtex);
                }
                return _bookRepository;
            }
        }
        public IAuthorRepository AuthorRepository
        {
            get
            {
                if (_authorrRepository == null)
                {
                    _authorrRepository = new AuthorRepository(_librareDBConxtex);
                }
                return _authorrRepository;
            }
        }
        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(_librareDBConxtex);
                }
                return _employeeRepository;
            }
        }
        public async Task<int> SaveAsync()
        {
            return await _librareDBConxtex.SaveChangesAsync();
        }
    }
}
