using System.Data.Entity;
using ComicBookGallery_EntityFramework.Models;

namespace ComicBookGallery_EntityFramework
{
    public class Context : DbContext
    {
        public Context()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
            //            Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
            //            Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
        }

        public DbSet<ComicBook> ComicBooks { get; set; }
    }
}

/*When using the Code First workflow, adding a database connection string—whose name matches the name of our context class—to our app's configuration file allows us to customize the name of the generated database.
 Using this option makes it possible to change the location or name of the database without having to rewrite our code, which is especially helpful when deploying applications into other environments.
 */
/*When EF detects an existing database, it queries the EDMX from the "__MigrationHistory" table and compares the current, in-memory model to the model stored in the database and throws an exception if they aren't compatible when using the default CreateDatabaseIfNotExists database initializer.
 The DropCreateDatabaseAlways and DropCreateDatabaseIfModelChanges database initializers allow you to customize this behavior.*/

/*EF only adds table columns for entity properties that have a setter—public, protected, or private.*/

/* The DbContext class is a higher-level abstraction of Entity Framework's ObjectContext class. Before this class was added to EF, ObjectContext was used to load and persist entities.
 Our DbContext class needs one property for each Entity that we need to write queries for.
 For DbSet property names, it is common practice to use the plural of the class name for variables.
 Often you'll add a DbSet property for each entity class that you have in your model.
 DbSet type is a generic type, which allows you to specify the entity type.
     */