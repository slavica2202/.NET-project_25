using System;
using System.Collections.Generic;

class Program
{
    static List<string> tasks = new List<string>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nTASK MANAGER");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Delete Task");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option (1-4): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ViewTasks();
                    break;
                case "3":
                    DeleteTask();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Enter task description: ");
        string task = Console.ReadLine();
        tasks.Add(task);
        Console.WriteLine("Task added!");
    }

    static void ViewTasks()
    {
        Console.WriteLine("\nYour Tasks:");
        if (tasks.Count == 0)
            Console.WriteLine("No tasks yet!");
        else
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }
    }

    static void DeleteTask()
    {
        ViewTasks();
        Console.Write("Enter task number to delete: ");
        int taskNumber;
        if (int.TryParse(Console.ReadLine(), out taskNumber))
        {
            if (taskNumber >= 1 && taskNumber <= tasks.Count)
            {
                tasks.RemoveAt(taskNumber - 1);
                Console.WriteLine("Task deleted!");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid number.");
        }
    }
}
