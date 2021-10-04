namespace Assignment4.Entities
{
    public class Task
    {
        public int Id {get; set;}

        [Required]
        [StringLength(100)]
        public string Title {get; set;}

        public User? AssignedTo {get; set;}

        [MaxLength]
        public string? Description {get; set;}
        
        [Required]
        public enum State {
            New,
            Active,
            Resolved,
            Closed,
            Removed
        }

        public ICollection<Tag> Tags {get; set;}
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder
            .Entity<Task>()
            .Property(e => e.State)
            .HasConversion<string>();
    }

}
