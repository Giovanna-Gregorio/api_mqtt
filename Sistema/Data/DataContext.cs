using Microsoft.EntityFrameworkCore;

namespace Sistema.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {

        }

        public DbSet<Mensagem> Mensagem { get; set; }
    }
}
