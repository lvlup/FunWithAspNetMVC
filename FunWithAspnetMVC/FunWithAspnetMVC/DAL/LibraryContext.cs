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
       public DbSet<Writer> Writers { get; set; }
       public DbSet<Book> Books { get; set; }

       public LibraryContext() : base("LibraryContext")
       {
           
       }

    
    }
}
