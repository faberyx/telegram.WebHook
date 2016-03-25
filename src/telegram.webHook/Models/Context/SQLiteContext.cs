using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using telegram.webHook.Models.Entities;

namespace telegram.webHook.Models.Context
{
    public class SQLiteContext : DbContext
    {
        public DbSet<Dictionary> Dictionary { get; set; }
        public DbSet<Message> Message { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             
        }
    }
}
