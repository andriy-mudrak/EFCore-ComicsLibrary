using System.Collections.Generic;
using task1_3.Tables;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace task1_3.Repositories
{
    class ComixRepository : Repository<Comix>, IComixRepository
    {
        public ComixRepository(ComixContext context)
               : base(context)
        {
        }
        
        public IEnumerable<Comix> GetTopCostComics(int count)
        {
            return ComixContext.Comics.OrderByDescending(c => c.Price).Take(count).ToList();
        }

        public IEnumerable<Comix> GetAllComicsWithAuthor()
        {
            return ComixContext.Comics.Include(c => c.Author).ToList();
            
        }
        
        public ComixContext ComixContext
        {
            get { return Context as ComixContext; }
        }
    }
}
