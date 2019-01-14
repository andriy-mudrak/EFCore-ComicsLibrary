using System.Collections.Generic;
using task1_3.Tables;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace task1_3.Repositories
{
    class ComixRepository : Repository<Comix, ComixContext>, IComixRepository
    {
        public ComixRepository(ComixContext context)
               : base(context)
        {
        }
        
        public IEnumerable<Comix> GetTopCostComics(int count)
        {
            return Context.Comics.OrderByDescending(c => c.Price).Take(count).ToList();
        }

        public IEnumerable<Comix> GetAllComicsWithAuthor()
        {
            return Context.Comics.Include(c => c.Author).ToList();
            
        }
        public IEnumerable<Comix> GetComix(string ComixName)
        {
            return Context.Comics
                .Where(a => a.Name == ComixName)
                .ToList();

        }

    }
}
