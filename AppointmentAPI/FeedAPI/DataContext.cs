using FeedAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedAPI
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Console.WriteLine("Вызван DataContext конструктор");
        }

        public DbSet<Feed> FeedingHistory { get; set; }

    }
}
