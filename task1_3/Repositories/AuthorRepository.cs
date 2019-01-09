using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using task1_3.Tables;
using System.Linq;

namespace task1_3.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Author>  GetAuthorWithAllComix(string AuthorName)
        {
            return ComixContext.Authors
                .Include(a => a.Comics)
                .Where(a => a.Name == AuthorName)
                .ToList();

        }
        
        public ComixContext ComixContext
        {
            get { return Context as ComixContext; }
        }
    }
}
