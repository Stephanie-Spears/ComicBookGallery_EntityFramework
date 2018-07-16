﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGallery_EntityFramework.Models
{
    public class ComicBook
    {
        // Id, ID, ComicBookId, ComicBookID -> All ok naming conventions
        public int Id { get; set; }

        public string SeriesTitle { get; set; }
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
    }
}

/*To Retrieve data from our database, we need to create a context model. All communication from our app to our DB flows through the context.
 The Context defines the available Entity sets and manages the relationships between those entities. It's used to retrieve entities from the DB, persist changed entities to the database, and remove entities from the DB.
 When retrieving the entities from the DB, the context is responsible for materializing the data from the DB into Entity Object Instances.
 The context also caches those Entity Object Instances for it's lifetime, so it can track changes to them.
     */