using System.Collections.Generic;

namespace ComicBookGallery_EntityFramework.Models
{
    public class Artist
    {
        public Artist()
        {
            ComicBooks = new List<ComicBookArtist>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ComicBookArtist> ComicBooks { get; set; }
    }
}