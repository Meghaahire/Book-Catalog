using Microsoft.EntityFrameworkCore;
using MVC3.Models.Domain;

namespace MVC3.Data


{
    public class MVC3DbContext :DbContext
    {
        public MVC3DbContext(DbContextOptions options) : base(options) 
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
