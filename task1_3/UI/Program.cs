using System;
using task1_3.Tables;
using System.Linq;
using task1_3.BusinessLogicLayer;
using task1_3.UI;
namespace task1_3
{

    class ApplicationStart
    {
        static void Main(string[] args)
        {
            ConsoleApp actionSelection = new ConsoleApp( new BusinessOperations());
            actionSelection.ShowHelp();

            bool flagOfTheEnd = true;
            while ( flagOfTheEnd )
            {

                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        Console.Clear();
                        actionSelection.ShowHelp();
                        break;
                    case "1":
                        actionSelection.ShowHelp();
                        break;
                    case "2":
                        addNewAuthor( actionSelection );
                        break;
                    case "3":
                        actionSelection.GetAllComicsWithAllAuthors();
                        break;
                    case "4":
                        Console.Write("Name Surname: ");
                        string author = Console.ReadLine();
                        actionSelection.GetAuthorWithAllComix(author);
                        break;
                    case "5":
                        int delete = Int32.Parse(Console.ReadLine());
                        actionSelection.RemoveAuthorById(delete);
                        break;
                    case "6":
                        actionSelection.ShowAllProfitableComics();
                        break;
                    case "7":
                        Console.Write("New author: ");
                        string newAuthor = Console.ReadLine();
                        Console.Write( "What comics? " );
                        string comixName = Console.ReadLine();
                        actionSelection.transferRights(newAuthor,comixName);
                        break;
                    default:
                        flagOfTheEnd = false;
                        break;
                }

            }
            Console.WriteLine( "Press any key to close the console" );
            Console.ReadLine();
        }

        static private void addNewAuthor(ConsoleApp actionSelection )
        {

            Console.Write( "Name Surname: " );
            string nameSurname = Console.ReadLine();
            Console.Write( "Comics name: " );
            string comixName = Console.ReadLine();
            Console.Write( "Price: " );
            int comixPrice = Int32.Parse( Console.ReadLine() );
            actionSelection.AddNewAuthorWithComics( nameSurname, comixName, comixPrice );
        }
    }
}

        

