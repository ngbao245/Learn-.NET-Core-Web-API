using CRUD.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data
{
    public class DBContext : DbContext
    {
        public DBContext()
        {
            
        }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
