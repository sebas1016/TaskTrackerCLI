using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TaskTrackerCLI
{
    internal class TaskRepository
    {
        private const string FilePath = "tasks.json"; 
        public List<Task> Load()
        {
            if (!File.Exists(FilePath))
            {
                string JsonString = "[]";
                File.WriteAllText(FilePath, JsonString);

                return new List<Task>();
            }
            
            string jsonString = File.ReadAllText(FilePath);
            List<Task> tasks = JsonSerializer.Deserialize<List<Task>>(jsonString)!;
            if (tasks == null)
            {
                return new List<Task>();
            } else
            {
                return tasks;
            }

        }

        public void Save(List<Task> tasks)
        {
            string jsonString = JsonSerializer.Serialize(tasks);
            File.WriteAllText(FilePath, jsonString);

        }

        public void Save(int nextId)
        {
            string jsonString = JsonSerializer.Serialize(nextId);
            File.WriteAllText(FilePath, jsonString);
        }
    }
}
