using System;
using task1_3.Tables;


namespace task1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork(new ComixContext()))
            {

                var author = new Author
                {
                    Name = "Andrii Mudrak"
                };

                var comix = new Comix
                {
                    Name = "Long story",
                    Price = 4,
                    Author = author
                };
                unitOfWork.Authors.Add(author);
                unitOfWork.Comics.Add(comix);
                unitOfWork.SaveChanges();
            }

            using (var unitOfWork = new UnitOfWork(new ComixContext()))
            {
                // printing all comics and their prices
                var comics = unitOfWork.Comics.GetAll();
                foreach (Comix u in comics)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Price}");
                }
            }
            
            using (var unitOfWork = new UnitOfWork(new ComixContext()))
            {
                // printing all comics and their authors
                var comix_get = unitOfWork.Comics.GetAllComicsWithAuthor();
                foreach (Comix cm in comix_get)
                {
                    Console.WriteLine($"{cm.Name} - {cm.Author?.Name}");
                }
            }
            
            using (var unitOfWork = new UnitOfWork(new ComixContext()))
            {
                // printing name of comics of the particular author
                var authors = unitOfWork.Authors.GetAuthorWithAllComix("Andrii Mudrak");
                foreach (Author a in authors)
                {
                    Console.WriteLine($"Author: {a.Name} "); 
                    foreach (Comix cm in a.Comics)
                    {
                        Console.WriteLine($"Comix: {cm.Name}");
                    }
                }
            }
            
            using (var unitOfWork = new UnitOfWork(new ComixContext()))
            {
                var author = new Author { Id = 4 };
                unitOfWork.Authors.Remove(author);
                unitOfWork.SaveChanges();
            }

            Console.ReadLine();

        }
    }
}
