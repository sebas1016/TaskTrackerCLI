
namespace TaskTrackerCLI
{
    internal class TaskData
    {
        public int NextId { get; set; }
        public List<Task> Tasks {  get; set; }

        public TaskData()
        {
            NextId = 1;
            Tasks = new List<Task>();
        }
    }
}
