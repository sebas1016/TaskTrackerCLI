using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TaskTrackerCLI
{
    internal class TaskRepository
    {
        private const string FilePath = "tasks.json"; 

        public TaskData Load()
        {
            if (!File.Exists(FilePath))
            {
                TaskData data = new TaskData();
                File.WriteAllText(FilePath, JsonSerializer.Serialize(data));

                return data;
            }
            
            string jsonString = File.ReadAllText(FilePath);
            TaskData tasks = JsonSerializer.Deserialize<TaskData>(jsonString)!;
            if (tasks == null)
            {
                return new TaskData();
            } else
            {
                return tasks;
            }

        }

        public void Save(TaskData data)
        {
            string jsonString = JsonSerializer.Serialize(data);
            File.WriteAllText(FilePath, jsonString);

        }  
        
    }
}
