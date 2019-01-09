using System;
using task1_3.Repositories;


namespace task1_3
{
    interface IUnitOfWork: IDisposable
    {
        IComixRepository Comics { get; }
        IAuthorRepository Authors { get; }
        int SaveChanges();
    }
}
