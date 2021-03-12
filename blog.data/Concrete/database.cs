using Microsoft.EntityFrameworkCore;
using shopapp.entity;

namespace shopapp.data.Concrete
{
    public class database : DbContext
    {
        public DbSet<Sertfika> Sertfikalar { get; set; }
        public DbSet<Kisisel> Kisisel { get; set; }
        public DbSet<Proje> Projeler { get; set; }
        public DbSet<Yetenekler> Yetenekler { get; set; }
        public DbSet<Blog> Bloglar{get;set;}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-E3OIB2J;Initial Catalog=kisisel;Integrated Security=SSPI;");
        }

    }
}