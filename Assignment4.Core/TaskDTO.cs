using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment4.Core
{
    public record TaskDTO(int Id, string Title, string AssignedToName, IReadOnlyCollection<string> Tags, State State);

    public record TaskDetailsDTO(int Id, string Title, string Description, DateTime Created, string AssignedToName, IReadOnlyCollection<string> Tags, State State, DateTime StateUpdated) : TaskDTO(Id, Title, AssignedToName, Tags, State);

    public record TaskCreateDTO
    {
        [Required]
        [StringLength(100)]
        public string Title { get; init; }

        public int? AssignedToId { get; init; }

        public string Description { get; init; }

        public ICollection<string> Tags { get; init; }
    }

    public record TaskUpdateDTO : TaskCreateDTO
    {
        public int Id { get; init; }

        public State State { get; init; }
    }
}















/* namespace Assignment4.Core
{
    public record TaskDTO(int Id, string Title, string Description, int? AssignedToId, State state);

    public record TaskDetailsDTO(int Id, string Title, string Description, int? AssignedToId, string AssignedToName, string AssignedToEmail, IEnumerable<string> Tags, State State) : TaskDTO(Id, Title, Description, AssignedToId, State);
    
    public record TaskCreateDTO
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }

        //public User? AssignedToUser {get; init;}
        public int? AssignedToId { get; init; }
        public IReadOnlyCollection<string> Tags { get; init; }
        public State State { get; init; }
    }

    public record TaskUpdateDTO : TaskCreateDTO
    {
        public int Id { get; init; }
    }
} */