using System;
using System.Linq;
using System.Data.Entity;
using System.Diagnostics;

namespace ComicBookGallery_EntityFramework
{
    internal class Program
    {
        private static void Main()
        {
            using (var context = new Context())
            {
                context.Database.Log = (message) => Debug.WriteLine(message);

                var comicBooks = context.ComicBooks
                    //                    .Include(cb => cb.Series)
                    //                    .Include(cb => cb.Artists.Select(a => a.Artist))
                    //                    .Include(cb => cb.Artists.Select(a => a.Role))
                    .ToList();

                foreach (var comicBook in comicBooks)
                {
                    var artistRoleNames = comicBook.Artists
                        .Select(a => $"{a.Artist.Name} - {a.Role.Name}")
                        .ToList();
                    var artistRolesDisplayText = string.Join(", ", artistRoleNames);
                    Console.WriteLine(comicBook.DisplayText);
                    Console.WriteLine(artistRolesDisplayText);
                }

                Console.ReadLine();
            }
        }
    }
}

/* Eager Loading - A single query to retrieve data for main entity, and also for the related entities. The include mehthod is used to tell EF which entities to load.
   Lazy Loading - The related entities aren't loaded until their navigation properties are accessed, which is automatically handled by EF.
   Explicit Loading - Using a load method, you can explicitly load entities.

*/
/*
 navigation properties allow you to define relationships between entities.
 The Include method can be used in a LINQ query to load related data.
 When defining a many-to-many relationship without defining an explicit bridge entity class, Entity Framework will automatically add an "implicit" bridge table to the database in order to store the relationship data.
 "Read only" or "getter only" entity properties do not need to be decorated with the "NotMapped" data annotation attribute in order for Entity Framework to ignore them when generating the in-memory representation of the model.
 Defining an explicit Many-to-Many bridge entity class allows you to include additional properties beyond the properties that are needed to define the relationship.
     */

/* The first time that we access the context's ComicBooks db set property, EF will check if the db exists, and if not, create it using our Model to generate the tables and columns. */
/*An .edmx file is an XML file that defines a conceptual model , a storage model , and the mapping between these models. An .edmx file also contains information that is used by the ADO.NET Entity Data Model Designer (Entity Designer) to render a model graphically*/

/* EF generates an in-memory version of the EDMX file using Type Discovery -- which the the process by which EF discovers all of the entities that are part of our model.
 Ef Starts with compiling a list of entities that have DbSet properties defined in our context. From there, it will walk the available entity relationships to discover any entities that aren't represented by DbSet Properties.
 For each Entity, EF also compiles a list of the properties, and for each property, various characteristics like data type and nullability. All of this makes a "Conceptual Model". There's also the "Storage Model" which is a representation of the Conceptual Model, to which it gets mapped.
 The default convention is for the entity to be represented by a table in the database. The name of the table is either the singular or plural version of the Entity class name (depending upon which EF has been configured to).
 If EF finds a property on the entity whose name matches the convention of ClassNameID or ClassNameId, then EF will add a primary key column to the table with the same name and data type. If the property's data type is Numeric or a GUID (globally unique identifier), then EF will also make the column an identity column.
 Identity columns are automatically assigned values by the DB when new records are added to the table. EF also adds an entity property that has a setter (public protected or private) as a table column, mapping the property's name to the Column Name and the properties .Net data type to the appropriate SQL Sever Column Data Type. The columns nullability is determined by evaluating if the .Net data type is nullable or not. (Ie. a column mapped with a data type of int wouldn't allow nulls, whereas a column mapped from a property with a data type of string would).
 */

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

/*sqllocaldb info -> in terminal to get localDBs.
 MSSQLLocalDB is the default LocalDB instance name created, and it is what EF will look for and connect to. The environment is properly configured to support EF development if you see this listed in the db instances
 ProjectsV13 is created specifically for SQL Server Data Tools and shouldn't be used for application development. SSDT is a set of development tools for Visual Studio.
     */