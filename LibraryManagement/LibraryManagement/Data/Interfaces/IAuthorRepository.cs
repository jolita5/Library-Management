using LibraryManagement.Data.Model;
using System.Collections.Generic;

namespace LibraryManagement.Data.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        IEnumerable<Author> GetAllWithBooks();
        Author GetWithBooks(int id);
    }
}
