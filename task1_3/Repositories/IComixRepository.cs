using System.Collections.Generic;
using task1_3.Tables;

namespace task1_3.Repositories
{
    public interface IComixRepository : IRepository<Comix>
    {
        IEnumerable<Comix> GetTopCostComics(int count);
        IEnumerable<Comix> GetAllComicsWithAuthor();
        IEnumerable<Comix> GetComix(string ComixName);
    }
}
