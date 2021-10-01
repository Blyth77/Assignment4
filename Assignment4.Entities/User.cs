namespace Assignment4.Entities
{
    public class User
    {
        public int Id {get; set;}

        [Required]
        [StringLength(100)]
        public string Name {get; set;}

        [Required]
        [Unique("Email")]
        [StringLength(100)]
        public string Email {get; set;}

        public List<User<Task>> Tasks {get; set;}
    }
}
