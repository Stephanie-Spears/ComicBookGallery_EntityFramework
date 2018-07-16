using System.Data.Entity;
using ComicBookGallery_EntityFramework.Models;

namespace ComicBookGallery_EntityFramework
{
    public class Context : DbContext
    {
        public DbSet<ComicBook> ComicBooks { get; set; }
    }
}

/* The DbContext class is a higher-level abstraction of Entity Framework's ObjectContext class. Before this class was added to EF, ObjectContext was used to load and persist entities.
 Our DbContext class needs one property for each Entity that we need to write queries for.
 For DbSet property names, it is common practice to use the plural of the class name for variables.
 Often you'll add a DbSet property for each entity class that you have in your model.
 DbSet type is a generic type, which allows you to specify the entity type.
     */