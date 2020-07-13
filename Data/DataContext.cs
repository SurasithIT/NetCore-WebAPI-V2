using Microsoft.EntityFrameworkCore;
using valueApi.Models;

namespace valueApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Value> Values { get; set; }
    }
}