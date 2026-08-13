namespace TaskTrackerCLI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
           

            if (args.Length == 0)
            {
                Console.WriteLine("No command provided. or No description provided.");
                Environment.Exit(1);
            }
            TaskService service = new TaskService();
            string comand = args[0];
            Console.WriteLine($"Comando: {comand}");

           
            switch (comand.ToLower())
            {
                case "add":
                    
                    if (args.Length == 2)
                    {
                        string description = args[1];
                        Task newTask = service.AddTask(description);
                        Console.WriteLine($"Task added successfully: {newTask.ToString()}");
                    }
                    else
                    {
                        Console.WriteLine("No description provided.");
                        Environment.Exit(1);
                    }
                    break;

                case "list":
                    var taskList = service.GetTasks();
                    if (taskList.Count == 0)
                    {
                        Console.WriteLine("No hay tareas aún");
                    }
                    else
                    {
                        foreach (var task in taskList)
                        {
                            Console.WriteLine(task.ToString());
                        }
                    }
                    break;

                case "delete":
                    if (args.Length == 2)
                    {
                        string taskId = args[1];
                        if (int.TryParse(taskId, out int id))
                        {
                            Task? task = service.DeleteTask(id);
                            if(task != null)
                            {
                                Console.WriteLine($"Task eliminada con exito {task}");
                            }
                            else
                            {
                                Console.WriteLine($"La tarea con id: {id} no fue encontrada");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid task ID provided for deletion.");
                            Environment.Exit(1);
                        }
                        

                    }
                    else
                    {
                     
                        Console.WriteLine("No task ID provided for deletion.");
                        Environment.Exit(1);
                    }
                    break;
                case "update":

                    if (args.Length == 3)
                    {

                        string taskId = args[1]; 

                        if (int.TryParse(taskId, out int id)) 
                        {

                            Task? task = service.UpdateTask(id, args[2]); 

                            if (task == null) 
                            { 

                                Console.WriteLine("Datos no validos, verifique Id o Descripcion");
                            } 

                            else 
                            { 

                                Console.WriteLine($"Tarea actualizada con exito: {task}"); 

                            }

                        }
                        else
                        {
                            Console.Write("El id debe de ser un número entero");
                        }
                         
                    }
                    else
                    {
                        Console.WriteLine("Hace falta uno o mas argumentos");
                    }

                    break;

                default:
                    Console.WriteLine($"Unknown command: {comand}");
                    Environment.Exit(1);
                    break;
            }
        }
        public void PrintHelp()
        {
            Console.WriteLine("Task Tracker CLI");
            Console.WriteLine("Usage:");
            Console.WriteLine("  add <description>   - Add a new task with the given description.");
            Console.WriteLine("  list                - List all tasks.");
            Console.WriteLine("  delete <taskId>     - Delete the task with the specified ID.");
        }
    }
}