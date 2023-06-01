using Microsoft.EntityFrameworkCore;
using SACBibliotecaGeneration.Models;

namespace SACBibliotecaGeneration.DataBase
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Libri { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=BookDb;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
