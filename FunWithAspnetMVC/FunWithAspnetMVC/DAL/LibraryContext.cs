using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunWithAspnetMVC.Models;

namespace FunWithAspnetMVC.DAL
{

    public class LibraryContext : DbContext
    {
       public virtual IDbSet<Writer> Writers { get; set; }
       public virtual IDbSet<Book> Books { get; set; }

       public LibraryContext() : base("LibraryContext")
       {
           
       }

    
    }
}
