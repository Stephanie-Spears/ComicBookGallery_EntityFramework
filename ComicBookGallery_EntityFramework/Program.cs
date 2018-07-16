using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicBookGallery_EntityFramework.Models;

namespace ComicBookGallery_EntityFramework
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var context = new Context())
            {
                context.ComicBooks.Add(new ComicBook()
                {
                    SeriesTitle = "The Amazing Spider-Man",
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today
                });
                context.SaveChanges();
                var comicBooks = context.ComicBooks.ToList();
                foreach (var comicBook in comicBooks)
                {
                    Console.WriteLine(comicBook.SeriesTitle);
                }

                Console.ReadLine();
            }
        }
    }
}

/* When we use our contacts to persist or retrieve data from the database, EF will open a connection to the database, which is an unmanaged resource (meaning it doesn't automatically have destructors activated when it goes out of scope).
 *Context class inherits from DbContext, which inherits from IDisposable class--the resource management class
 * By calling our Context's dispose method (via DbContext -> IDisposable) we're letting EF know that the DB connection can be closed. We can ensure that the context's Dispose() method will be called by placing the instantiation of the context within a using statement.
 */

/*The Entity Framework DbContext class implements the IDisposable interface which provides a mechanism for releasing unmanaged resources, through its single method, Dispose.*/
/*All communication from our application to the database flows through the Context class.*/
/*The context class contains a collection of DbSet properties—one property for each entity that you need to write queries for.*/
/*When using the Code First workflow, your entity class names will by default become the database table names—either the singular or plural versions depending on how EF is configured.*/
/*The Database First workflow was created to be used with existing databases and the Code First workflow provides an option to generate your entity and context classes from an existing database as a one-time operation.*/
/*The context can be used to retrieve entities from the database, persist new and changed entities to the database, and even to remove entities from the database.*/
/*Describing the shape of your data by defining entities, properties on those entities, and the relationships between entities, is known as Data Modeling*/
/*If you want to use the visual EF Designer to define your model and you don't have an existing database, you'd use the Model First workflow*/
/*Entity class "key" properties (properties that are mapped to primary key columns in the database) can be named using the following conventions:
     Id, ID, {ClassName}Id, or {ClassName}ID
 */