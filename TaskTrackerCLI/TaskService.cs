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

        public TaskService()
        {
            tasks = repository.Load();
            if (tasks.Count == 0)
            {
                nextId = 1;
            }
            else
            {
                nextId = tasks.Max(t => t.Id) + 1;
            }


        }

        public Task AddTask(string description)
        {
            Task task = new Task(nextId, description);
            tasks.Add(task);
            repository.Save(tasks);
            nextId++;
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
                repository.Save(tasks);
                return task;

            }
            else
            {
                return null;

            }

        }
    }
}
