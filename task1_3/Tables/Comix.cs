

namespace task1_3.Tables
{
    public class Comix
    {
       
        public int Id { get; set; }
        public string Name { get; set; }            
        public double Price { get; set; }


        public int AuthorId { get; set; }   
        public Author Author { get; set; }

       
    }
}

