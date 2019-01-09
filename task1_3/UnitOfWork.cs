using task1_3.Repositories;

namespace task1_3
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly ComixContext _context;

        public UnitOfWork(ComixContext context)
        {
            _context = context;
            Comics = new ComixRepository(_context);
            Authors = new AuthorRepository(_context);
        }
        public IComixRepository Comics { get; private set; }
        public IAuthorRepository Authors { get; private set; }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
