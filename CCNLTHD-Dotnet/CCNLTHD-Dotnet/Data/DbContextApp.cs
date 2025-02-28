using CCNLTHD_Dotnet.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CCNLTHD_Dotnet.Data
{
    public class DbContextApp: DbContext
    {
        public DbContextApp(DbContextOptions<DbContextApp> options) : base(options)
        {

        }

        public DbSet<TodoList> TodoList { get; set; }
    }
}
