using System.Collections.Generic;

namespace Assignment4.Entities
{
    public class Tag
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [IsUnique("Name")]
        public string Name { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
