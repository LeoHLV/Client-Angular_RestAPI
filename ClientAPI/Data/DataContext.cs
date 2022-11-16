using ClientAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientAPI.Data
{
    public class DataContext:DbContext
    {
        public DataContext(){}

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ClientMD> ClientMDs => Set<ClientMD>();
    }
}
