using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TaskTrackerCLI
{
    internal class TaskService
    {
        private List<Task> tasks = new List<Task>();
        private int nextId = 1;
        private TaskRepository repository = new TaskRepository();
        private TaskData data;

        public TaskService()
        { 
            data = repository.Load();
            tasks = data.Tasks;
            nextId = data.NextId;
        }

        public Task AddTask(string description)
        {
            
            Task task = new Task(nextId, description);
            tasks.Add(task);
            nextId++;
            data.NextId = nextId;
            repository.Save(data);
            
            return task;
        }

        public IReadOnlyList<Task> GetTasks()
        {
            IReadOnlyList<Task> tasklist = tasks.AsReadOnly();

            return tasklist;
            //Tambien se puede hacer de la siguiente manera:
            //return tasks.AsReadOnly();
        }

        public Task? DeleteTask(int id)
        {
            Task? task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
                repository.Save(data);
                return task;

            }
            else
            {
                return null;

            }

        }

        public Task? UpdateTask(int id, string newDescription)
        {
            Task? task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return null;
            }

            if (!task.UpdateDescription(newDescription)) 
            {
                return null;
            }

            repository.Save(data);
            return task;

        }
    }
}
