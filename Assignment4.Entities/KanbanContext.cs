using System;
using Assignment4.Core;
using Assignment4;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;


namespace Assignment4.Entities
{
    public class KanbanContext : DbContext, IKanbanContext
    {
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        
        public KanbanContext(DbContextOptions<KanbanContext> options) : base(options) { }
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().Property(e => e.State).HasConversion(new EnumToStringConverter<State>());

            modelBuilder.Entity<Tag>()
                        .HasIndex(s => s.Name)
                        .IsUnique();

            modelBuilder.Entity<User>()
                        .HasIndex(s => s.Name)
                        .IsUnique();
        }
    }
}
