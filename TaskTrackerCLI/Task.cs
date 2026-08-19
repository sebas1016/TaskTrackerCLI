using System.Text.Json.Serialization;

namespace TaskTrackerCLI
{
    public enum TaskStatus
    {
        Todo,
        InProgress,
        Done
    }
    internal class Task
    {
        
        public int Id { get; }
        public string Description { get; private set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TaskStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        [JsonConstructor]
        public Task(int id, string description, TaskStatus status, DateTime createdAt, DateTime updatedAt)
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
            Status = TaskStatus.Todo;
            CreatedAt = DateTime.Now;
            UpdatedAt = CreatedAt;
        }
        
        public bool UpdateDescription(string newDescription)
        {
           if(string.IsNullOrWhiteSpace(newDescription))
           {
                return false;
           }
           
           Description = newDescription;
           UpdatedAt = DateTime.Now;
           return true;
                   
        }

        public bool UpdateStatus(TaskStatus status)
        {
            Status = status;
            UpdatedAt = DateTime.Now;
            return true;
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
