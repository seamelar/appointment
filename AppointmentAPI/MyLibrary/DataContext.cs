using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Console.WriteLine("Вызван DataContext конструктор");
        }

        public DbSet<Feed> FeedingHistory { get; set; }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalOwner> Owners { get; set; }
        public DbSet<Veterinarian> Veterinarians { get; set; }

    }
}
