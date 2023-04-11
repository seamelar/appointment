
using System;

namespace MyLibrary
{
    public class Feed
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int AnimalId { get; set; }

        public Animal? Animal { get; set; }
    }
}
