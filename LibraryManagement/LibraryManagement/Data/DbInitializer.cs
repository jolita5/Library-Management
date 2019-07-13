using LibraryManagement.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace LibraryManagement.Data
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LibraryDbContext>();

                //Add Customers
                var karolis = new Customer { Name = "Karolis Tarolis" };
                var sandra = new Customer { Name = "Sandra Palanga" };
                var laima = new Customer { Name = "Laima Pamaiva" };
                var petras = new Customer { Name = "Petras Kletras" };

                context.Customers.Add(karolis);
                context.Customers.Add(sandra);
                context.Customers.Add(laima);
                context.Customers.Add(petras);

                //Add Authors
                var authorJordan = new Author
                {
                    Name = "Jordan B. Peterson",
                    Books = new List<Book>()
                    {
                        new Book {Title = "12 rules for life"},
                        new Book {Title = "Maps of Meaning"}
                    }
                };

                var authorSvetlana = new Author
                {
                    Name = "Svetlana Aleksijevič",
                    Books = new List<Book>()
                    {
                        new Book {Title = "Černobylio malda. Ateities kronika"}
                    }
                };

                var authorSally = new Author
                {
                    Name = "Sally Hepworth",
                    Books = new List<Book>()
                    {
                        new Book {Title = "The Mother-in-Law"},
                        new Book {Title = "The Family Next Door"},
                        new Book {Title = "The Things We Keep"},
                    }
                };

                context.Authors.Add(authorJordan);
                context.Authors.Add(authorSally);
                context.Authors.Add(authorSvetlana);

                context.SaveChanges();
            }
        }
    }
}
