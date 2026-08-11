using System.Text.Json.Serialization;

namespace TaskTrackerCLI
{
    internal class Task
    {
        public int Id { get; }
        public string Description { get; private set; }
        public string Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        [JsonConstructor]
        public Task(int id, string description, string status, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Description = description;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
        public Task(int id,string description)
        {
            Id = id;
            Description = description;
            Status = "todo";
            CreatedAt = DateTime.Now;
            UpdatedAt = CreatedAt;
        }

        public override string ToString()
        {
            return $"\nID: {Id}" +
                $"\nDescription: {Description}" +
                $"\nStatus: {Status}" +
                $"\nCreated At: {CreatedAt}" +
                $"\nUpdated At: {UpdatedAt}";
        }
    }
}
