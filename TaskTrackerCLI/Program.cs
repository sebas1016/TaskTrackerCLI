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
                    Console.WriteLine("List command executed.");
                    break;

                case "delete":
                    if (args.Length == 2)
                    {
                        string taskId = args[1];
                        Console.WriteLine($"Task ID to delete: {taskId}");

                    }
                    else
                    {
                        Console.WriteLine("No task ID provided for deletion.");
                        Environment.Exit(1);
                    }
                    break;

                default:
                    Console.WriteLine($"Unknown command: {comand}");
                    Environment.Exit(1);
                    break;
            }
        }
    }
}