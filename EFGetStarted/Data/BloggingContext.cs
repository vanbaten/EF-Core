using EFGetStarted.Models;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted.Data
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public string DbPath { get; set; }

        public BloggingContext()
        {
            // Connection strings **SHOULD NOT** be stored in the code for production applications.
            // in this cas: C:\Users\<user>\AppData\Local\blogging.db
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "blogging.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

    }
}
