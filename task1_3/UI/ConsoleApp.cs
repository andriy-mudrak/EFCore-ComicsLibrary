using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using task1_3;
using task1_3.BusinessLogicLayer;
using task1_3.Tables;

namespace task1_3.UI
{
    public class ConsoleApp
    {
        private readonly IBusinessOperations _operations;
        private readonly int primeCost = 10;
        public ConsoleApp( IBusinessOperations operations )
        {
            _operations = operations;
        }

        public void GetAllComicsWithAllAuthors()
        {
            using ( var unitOfWork = new UnitOfWork( new ComixContext() ) )
            {
                // printing all comics and their authors
                var comix_get = unitOfWork.Comics.GetAllComicsWithAuthor();
                foreach ( Comix cm in comix_get )
                {
                    Console.WriteLine( $"{cm.Author?.Id} {cm.Author?.Name} {cm.Name} " );
                }
            }
        }

        public void GetAuthorWithAllComix( string name )
        {
            using ( var unitOfWork = new UnitOfWork( new ComixContext() ) )
            {
                // printing name of comics of the particular author
                var authors = unitOfWork.Authors.GetAuthorWithAllComix( name );
                foreach ( Author a in authors )
                {
                    Console.WriteLine( $"Author: {a.Name} " );
                    foreach ( Comix cm in a.Comics )
                    {
                        Console.WriteLine( $"Comix: {cm.Name}" );
                    }
                }
            }
        }

        public void RemoveAuthorById( int id )
        {
            using ( var unitOfWork = new UnitOfWork( new ComixContext() ) )
            {
                var author = new Author { Id = id };
                unitOfWork.Authors.Remove( author );
                unitOfWork.SaveChanges();
            }
            Console.WriteLine( $"Автор з ID: {id} видалений" );

        }

        public void AddNewAuthorWithComics( string authorName, string comixName, int Price )
        {
            using ( var unitOfWork = new UnitOfWork( new ComixContext() ) )
            {

                var author = new Author
                {
                    Name = authorName
                };

                var comix = new Comix
                {
                    Name = comixName,
                    Price = Price,
                    Author = author
                };
                unitOfWork.Authors.Add( author );
                unitOfWork.Comics.Add( comix );
                unitOfWork.SaveChanges();
                Console.WriteLine( $"ID:{author.Id}. Name:{author.Name} Comics:{comix.Name} Price:{comix.Price}" );
            }
           
        }

        public void ShowAllProfitableComics()
        {
            using ( var unitOfWork = new UnitOfWork( new ComixContext() ) )
            {
                var comics = unitOfWork.Comics.GetAll();
                foreach ( Comix cm in comics )
                {
                    if ( _operations.isProfitable( cm, primeCost ) )
                    {
                        var author = unitOfWork.Authors.Get(cm.AuthorId);
                        Console.WriteLine( $"{author.Name}   {cm.Name} {cm.Price}" );
                    }
                }
                unitOfWork.SaveChanges();
            }
        }
        public void transferRights( string _newAuthor, string _comix )
        {
            using (var unitOfWork = new UnitOfWork(new ComixContext()))
            {
                var newAuthor = unitOfWork.Authors.GetAuthor(_newAuthor).ToList();
                var comix = unitOfWork.Comics.GetComix(_comix).ToList();

                var comixTransfer = TransferConfirmation(newAuthor[0], comix[0]);

                unitOfWork.Comics.Remove( comix[0] );
                unitOfWork.Comics.Add( comixTransfer );
                unitOfWork.SaveChanges();
            }

        }
        private Comix TransferConfirmation(Author author, Comix comix )
        {
            Comix updateComix = new Comix
            {
                Name = comix.Name,
                Price = comix.Price,

            };
            updateComix.Author = author;

            return updateComix;

        }

        public void ShowHelp()
        {
            Console.WriteLine( "Press 0 to clear the console" );
            Console.WriteLine( "Press 1 to see help" );
            Console.WriteLine( "Press 2 to add new author and his comics" ); 
            Console.WriteLine( "Press 3 to get all comics with their authors" );
            Console.WriteLine( "Press 4 to get author and his all comics" );
            Console.WriteLine( "Press 5 to delete a author by id" );
            Console.WriteLine( "Press 6 to show all profitable comics" );
            Console.WriteLine( "Press 7 to transfer rights from one author to another" );
            Console.WriteLine( "Press any other key to exit" );
            Console.WriteLine( "---------------------------------------------------------------" );
        }
    }
}
