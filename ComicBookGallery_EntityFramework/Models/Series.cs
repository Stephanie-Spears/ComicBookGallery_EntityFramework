using System.Collections.Generic;

namespace ComicBookGallery_EntityFramework.Models
{
    public class Series
    {
        public Series()
        {
            ComicBooks = new List<ComicBook>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<ComicBook> ComicBooks { get; set; }
    }
}