using System.Collections.Specialized;
using System.Data.Common;
using System.Net.NetworkInformation;

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
                    if (args.Length == 2)
                    {
                        string status = args[1];
                        
                        var parseStatus = ParseStatus(status);
                        if (parseStatus != null)
                        {
                            var taskList = service.GetTasks(parseStatus);
                            PrintTasks(taskList);
                        } 
                        else
                        {
                            Console.WriteLine("Estado no valido. es de la forma: " +
                                "\nTodo" +
                                "\nIn-progress" +
                                "\nDone");
                        }
                        
                        
                    } 
                    else if (args.Length == 1)
                    {
                        var taskList = service.GetTasks(null);
                        PrintTasks(taskList);
                    }
                    else
                    {
                        Console.WriteLine("Comando no valido");
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
                case "status":
                    if (args.Length == 3)
                    {
                        string taskId = args[1];
                        if(int.TryParse(taskId, out int id))
                        {
                            Task? task = service.UpdateStatus(id, args[2]);
                            if (task == null)
                            {
                                Console.WriteLine($"No se encontro tarea con el Id {id} ó el estado {args[2]}. No es valido");
                            }
                            else
                            {
                                Console.WriteLine($"Se actualizo el estatdo con exito: {task}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("El Id debe ser un número entero");
                        }
                    } else
                    {
                        Console.WriteLine("Argumentos insuficientes. Es de la forma command id new status");
                    }
                    break;
                default:
                    Console.WriteLine($"Unknown command: {comand}");
                    Environment.Exit(1);
                    break;
            }
        }

        private static TaskStatus? ParseStatus(string status)
        {
            switch (status.ToLower())
            {
                case "todo":
                    return TaskStatus.Todo;

                case "in-progress":
                    return TaskStatus.InProgress;

                case "done":
                    return TaskStatus.Done;

                default:
                    return null;
            }
        }

        private static void PrintTasks(IReadOnlyList<Task> tasksList)
        {
            if (tasksList.Count == 0)
            {
                Console.WriteLine("No hay tareas aún");
                return;
            }
            
            foreach (var task in tasksList)
            {
                Console.WriteLine(task);
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