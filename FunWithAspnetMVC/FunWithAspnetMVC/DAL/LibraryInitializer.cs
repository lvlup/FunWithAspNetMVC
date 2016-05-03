using System.Collections.Generic;
using FunWithAspnetMVC.Models;

namespace FunWithAspnetMVC.DAL
{
   public class LibraryInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<LibraryContext>
    {
       protected override void Seed(LibraryContext context)
       {
            var writers = new List<Writer>
            {
            //new Writer{FirstName= "Александр",LastName="Пушкин"},
            //new Writer{FirstName= "Carson",LastName="Толстой"},
            //new Writer{FirstName= "Carson",LastName="Горький"},
            //new Writer{FirstName= "Carson",LastName="Чехов"},
            //new Writer{FirstName= "Carson",LastName="Толстой"},
            //new Writer{FirstName= "Carson",LastName="Гоголь"},
            //new Writer{FirstName= "Carson",LastName="Тургенев"},
            //new Writer{FirstName= "Carson",LastName="Лермонтов"},
            //new Writer{FirstName= "Carson",LastName="Достоевский"},
            //new Writer{FirstName= "Carson",LastName="Куприн"},

            new Writer{FirstName= "Николай",LastName="Некрасов"},
            new Writer{FirstName= "Иван",LastName="Бунин"},
            new Writer{FirstName= "Владимир",LastName="Маяковский"},
            new Writer{FirstName= "Дмитрий",LastName="Мамин-Сибиряк"},
            new Writer{FirstName= "Владимир",LastName="Короленко"},
            new Writer{FirstName= "Александр",LastName="Блок"},
            new Writer{FirstName= "Николай",LastName="Лесков"},
            new Writer{FirstName= "Александр",LastName="Островский"},
            new Writer{FirstName= "Валерий",LastName="Брюсов"},
            new Writer{FirstName= "Брис",LastName="Пастернак"}
            };

            writers.ForEach(w => context.Writers.Add(w));
            context.SaveChanges();
            var books = new List<Book>
            {
            new Book{Name = "Близнец в тучах",Genre = "Лирика",WriterID = 10},
            new Book{Name = "Доктор Живаго",Genre = "Роман",WriterID = 10},

            new Book{Name = "Городу",Genre = "Сочинение", WriterID = 9},
            new Book{Name = "Опять в Венеции",Genre = "Сочинение",WriterID = 9},
        
            new Book{Name = "Бедность не порок",Genre = "Комедия", WriterID = 8},
            new Book{Name = "Гроза",Genre = "Пьеса",WriterID = 8},

            new Book{Name = "Некуда",Genre = "Роман", WriterID = 7},
            new Book{Name = "Житие одной бабы",Genre = "Повесть",WriterID = 7},

            new Book{Name = "Стихи о Прекрасной Даме",Genre = "Стихотворения", WriterID = 6},
            new Book{Name = "Седое Утро",Genre = "Стихотворения",WriterID = 6},

            new Book{Name = "Очерки и рассказы",Genre = "Новеллы", WriterID = 5},
            new Book{Name = "Павловские очерки",Genre = "Новеллы",WriterID = 5},


            new Book{Name = "Горное гнездо",Genre = "Роман", WriterID = 4},
            new Book{Name = "Хлеб",Genre = "Роман",WriterID = 4},

            new Book{Name = "Люблю",Genre = "Поэма", WriterID = 3},
            new Book{Name = "Вон самогон",Genre = "Стихотворения",WriterID = 3},

            new Book{Name = "Жизнь Арсеньева",Genre = "Роман", WriterID = 2},
            new Book{Name = "Деревня",Genre = "Повесть",WriterID = 2},

            new Book{Name = "Мертвое озеро",Genre = "Роман", WriterID = 1},
            new Book{Name = "Забракованные",Genre = "Пьеса",WriterID = 1},


            };
            books.ForEach(s => context.Books.Add(s));
            context.SaveChanges();
        }
    }
}
