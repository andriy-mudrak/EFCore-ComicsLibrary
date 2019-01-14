using System;
using task1_3.Tables;
using System.Linq;
using task1_3.BusinessLogicLayer;

namespace task1_3
{
    class Program
    {
        public static string Stan_Lee { get { return "Stan Lee"; } }
        public static string Jack_Kirby { get { return "Jack Kirby"; } }
        public static string Iron_Man { get { return "Iron Man"; } }

        static void Main(string[] args)
        {
            

        BusinessOperations operations = new BusinessOperations(
                new UnitOfWork(new ComixContext()));
            
            using (var unitOfWork = new UnitOfWork(new ComixContext()))
            {
                Author author = unitOfWork.Authors.GetAuthorWithAllComix("Stan_Lee").ToList()[0];
                operations.changePricePercent(author, 15);
            }

            using (var unitOfWork = new UnitOfWork(new ComixContext()))
            {
                operations.transferRights(Stan_Lee,Jack_Kirby, Iron_Man);
                
            }
            
            Console.ReadLine();
        }

    }
}
