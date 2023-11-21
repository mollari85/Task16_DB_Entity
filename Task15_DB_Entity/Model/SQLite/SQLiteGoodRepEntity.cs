using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Task15_DB_Entity.Model.SQLite
{
    internal class SQLiteGoodRepEntity:DbContext
    {
        public DbSet<Good> dbGood { get; set; } = null!;
        public SQLiteGoodRepEntity() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Good.db");
                }

    }
}
