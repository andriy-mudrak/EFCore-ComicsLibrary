using System.Collections.Generic;
using task1_3.Tables;

namespace task1_3.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        IEnumerable<Author> GetAuthorWithAllComix(string AuthorName);
        IEnumerable<Author> GetAuthor(string AuthorName);

    }
}
