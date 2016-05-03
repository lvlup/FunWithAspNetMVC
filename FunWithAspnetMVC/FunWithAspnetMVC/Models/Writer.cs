using System.Collections.Generic;

namespace FunWithAspnetMVC.Models
{
   public class Writer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; } 
    }
}
