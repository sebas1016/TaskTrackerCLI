using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;

namespace TaskTrackerCLI
{
    internal class TaskService
    {
        
        private TaskRepository repository = new TaskRepository();
        private TaskData data;

        public TaskService()
        { 
            data = repository.Load();
            
        }

        public Task AddTask(string description)
        {
            
            Task task = new Task(data.NextId, description);
            data.Tasks.Add(task);
            data.NextId++;
            repository.Save(data);
            
            return task;
        }

        public IReadOnlyList<Task> GetTasks(TaskStatus? status)
        {
            if (status == null)
            {
                return data.Tasks.AsReadOnly();
            }else
            {
                return data.Tasks
                    .Where(t => t.Status == status)
                    .ToList()
                    .AsReadOnly();
            }

        }

        public Task? DeleteTask(int id)
        {
            Task? task = data.Tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                data.Tasks.Remove(task);
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
            Task? task = data.Tasks.FirstOrDefault(t => t.Id == id);
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

        public Task? UpdateStatus(int id, string status)
        {
            Task? task = data.Tasks.FirstOrDefault(t => t.Id == id);
            

            if (task == null)
            {
                return null;
            }
            if (string.IsNullOrWhiteSpace(status)) 
            {
                return null;
            }
            TaskStatus newStatus;
            switch (status.ToLower())
            {
                case "todo":

                    newStatus = TaskStatus.Todo;
                    break;
                
                case "in-progress":
                    newStatus = TaskStatus.InProgress;
                    break;
                case "done":
                    newStatus = TaskStatus.Done;
                    break;
                default:
                    
                    return null;
            }
            task.UpdateStatus(newStatus);
            repository.Save(data);
            return task;
            
        }

       
    }
}
