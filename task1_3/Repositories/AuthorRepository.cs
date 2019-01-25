using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using task1_3.Tables;
using System.Linq;

namespace task1_3.Repositories
{
    public class AuthorRepository : Repository<Author, ComixContext>, IAuthorRepository
    {
        public AuthorRepository(ComixContext context) : base(context)
        {
        }

        public IEnumerable<Author>  GetAuthorWithAllComix(string AuthorName)
        {
            return Context.Authors
                .Where( a => a.Name == AuthorName )
                .Include(a => a.Comics)
                .ToList();

        }

        public IEnumerable<Author> GetAuthor(string AuthorName)
        {
            return Context.Authors                
                .Where(a => a.Name == AuthorName)
                .ToList();

        }

    }
}
