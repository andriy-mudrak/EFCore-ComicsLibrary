using System.Collections.Generic;

namespace task1_3.Tables
{
    public class Author
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public List<Comix> Comics { get; set; }
    }
}
