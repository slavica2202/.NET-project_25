using System;
using System.Collections.Generic;
using System.IO;  // For file handling
using Newtonsoft.Json;  // For JSON serialization (make sure you add the NuGet package)

namespace KanbanBoardApp
{
    public class Program
    {
        // Display the Kanban board
        public static void DisplayBoard(KanbanBoard board)
        {
            Console.Clear();
            Console.WriteLine("KANBAN BOARD");
            Console.WriteLine("------------");

            // Display To Do Column
            Console.WriteLine("\nTo Do:");
            if (board.ToDo.Count == 0)
                Console.WriteLine("No tasks in To Do.");
            else
                foreach (var task in board.ToDo)
                    Console.WriteLine($"[{board.ToDo.IndexOf(task) + 1}] {task.TaskId}: {task.TaskDescription}");

            // Display In Progress Column
            Console.WriteLine("\nIn Progress:");
            if (board.InProgress.Count == 0)
                Console.WriteLine("No tasks in In Progress.");
            else
                foreach (var task in board.InProgress)
                    Console.WriteLine($"[{board.InProgress.IndexOf(task) + 1}] {task.TaskId}: {task.TaskDescription}");

            // Display Done Column
            Console.WriteLine("\nDone:");
            if (board.Done.Count == 0)
                Console.WriteLine("No tasks in Done.");
            else
                foreach (var task in board.Done)
                    Console.WriteLine($"[{board.Done.IndexOf(task) + 1}] {task.TaskId}: {task.TaskDescription}");
        }

        // Create a new task
        public static Task CreateTask()
        {
            Console.Write("Enter Task ID (short description): ");
            string taskId = Console.ReadLine();
            Console.Write("Enter Task Description (detailed): ");
            string taskDescription = Console.ReadLine();

            return new Task(taskId, taskDescription);
        }

        // Move task to In Progress
        public static void MoveTaskToInProgress(KanbanBoard board)
        {
            Console.WriteLine("\nEnter the Task number to move to In Progress:");
            int taskIndex = Convert.ToInt32(Console.ReadLine()) - 1;

            if (taskIndex >= 0 && taskIndex < board.ToDo.Count)
            {
                Task taskToMove = board.ToDo[taskIndex];
                board.ToDo.RemoveAt(taskIndex);
                board.InProgress.Add(taskToMove);
                Console.WriteLine($"Task {taskToMove.TaskId} moved to In Progress.");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }

        // Move task to Done
        public static void MoveTaskToDone(KanbanBoard board)
        {
            Console.WriteLine("\nEnter the Task number to move to Done:");
            int taskIndex = Convert.ToInt32(Console.ReadLine()) - 1;

            if (taskIndex >= 0 && taskIndex < board.InProgress.Count)
            {
                Task taskToMove = board.InProgress[taskIndex];
                board.InProgress.RemoveAt(taskIndex);
                board.Done.Add(taskToMove);
                Console.WriteLine($"Task {taskToMove.TaskId} moved to Done.");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
        }

        // Save the board to a file
        public static void SaveBoardToFile(KanbanBoard board, string filename)
        {
            string json = JsonConvert.SerializeObject(board, Formatting.Indented);  // Serialize board to JSON
            File.WriteAllText(filename, json);  // Save to file

            Console.WriteLine($"Board saved to {filename}");
        }

        // Load the board from a file
        public static KanbanBoard LoadBoardFromFile(string filename)
        {
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                KanbanBoard board = JsonConvert.DeserializeObject<KanbanBoard>(json);
                Console.WriteLine("Board loaded successfully.");
                return board;
            }
            else
            {
                Console.WriteLine("File not found, creating a new board.");
                return new KanbanBoard();
            }
        }

        public static void Main(string[] args)
        {
            KanbanBoard board = new KanbanBoard();

            Console.WriteLine("Do you want to load an existing board or create a new one?");
            Console.WriteLine("1. Load Existing Board");
            Console.WriteLine("2. Create New Board");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter the file name to load the board from: ");
                string filename = Console.ReadLine();
                board = LoadBoardFromFile(filename);
            }
            else if (choice == "2")
            {
                Console.Write("Enter the project name: ");
                string projectName = Console.ReadLine();
                Console.Write("Enter the file name to save the board: ");
                string filename = Console.ReadLine();

                Console.WriteLine($"Creating new board for {projectName}.");
            }

            // Main loop to interact with the user
            bool running = true;
            while (running)
            {
                DisplayBoard(board);
                Console.WriteLine("\nChoose an action:");
                Console.WriteLine("F1 - Add Task");
                Console.WriteLine("F5 - Move Task to In Progress");
                Console.WriteLine("F6 - Move Task to Done");
                Console.WriteLine("F7 - Save and Exit");

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.F1:
                        Task newTask = CreateTask();
                        if (board.ToDo.Count < 10)
                        {
                            board.ToDo.Add(newTask);
                        }
                        else
                        {
                            Console.WriteLine("Cannot add more tasks to To Do (max 10 tasks).");
                        }
                        break;
                    case ConsoleKey.F5:
                        MoveTaskToInProgress(board);
                        break;
                    case ConsoleKey.F6:
                        MoveTaskToDone(board);
                        break;
                    case ConsoleKey.F7:
                        Console.Write("Enter the filename to save the board: ");
                        string saveFile = Console.ReadLine();
                        SaveBoardToFile(board, saveFile);
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid key. Try again.");
                        break;
                }
            }
        }
    }
}
