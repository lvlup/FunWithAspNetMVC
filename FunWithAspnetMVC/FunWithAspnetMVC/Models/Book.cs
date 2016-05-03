using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithAspnetMVC.Models
{
   public class Book
    {
        public int ID { get; set; }

        public string Genre { get; set; }
        public  string Name { get; set; }

        public int WriterID { get; set; }
        public virtual  Writer Writer { get; set; }
    }
}
