using Microsoft.EntityFrameworkCore;
using NSM.SERVER.Models;

namespace NSM.SERVER.Database
{
    class DatabaseContext : DbContext
    {

        public DbSet<Chat> Chat { get; set; }
        public DbSet<User> User {  get; set; }
        public DbSet<ChatUser> ChatUser { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Notification> Notification { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=NSM.db");
        }

    }
}
