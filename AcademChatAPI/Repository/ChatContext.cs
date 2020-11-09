using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademChatAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcademChatAPI.Repository
{
    public class ChatContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Message> Messages { get; set; }

        public ChatContext() { }

        public ChatContext(DbContextOptions<ChatContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
            new User[]
            {
                    new User { id = -1, name = "Vitaly", password = "chat", status = "Using ChatClient", position = "CEO"},
                    new User { id = -2, name = "Valery", password = "chat", status = "Using ChatClient", position = "CTO"},
                    new User { id = -3, name = "Matvey", password = "chat", status = "Free for chat", position = "Lead"},
                    new User { id = -4, name = "Natalya", password = "chat", status = "Come to taste a coockies!", position = "CFO"},
                    new User { id = -5, name = "Aydar", password = "chat", status = "Busy", position = "SWE"}
            });
        }
    }
}
