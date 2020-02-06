using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _4dayClean
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> userList = new List<string>();
            List<int> completed = new List<int>();
            ConsoleKey keyInfo;
            string filepath1 = @"D:\Documents\MSSA\C#\4dayClean\task1.md";
            string filepath2 = @"D:\Documents\MSSA\C#\4dayClean\task2.md";
            string filepath3 = @"D:\Documents\MSSA\C#\4dayClean\task3.md";


            var done = false;
            Console.Write("Type 'new' to create a new task list, Type 'load' to load an existing task list: ");
            var userInit = Console.ReadLine();
            FileLoad(ref userList, filepath1, filepath2, filepath3, ref done, userInit);

            Console.Clear();
            int currentTask = 0;
            var startingPoint = 0;
            var taskLength = userList.Count();


            do
            {

                var pageLimit = 20;
                var testLength = taskLength - startingPoint;
                pageLimit = Paging(startingPoint, pageLimit, testLength);
                Console.Clear();
                Console.WriteLine("\nPress 'X' to navigate Down, Press 'Z' to navigate Up \n" +
                                    "Press 'N' for next page, Press 'B' for previous page \nPress 'C' to complete a task \n" +
                                    "Press 'A' to add a task \nPress 'R' to re-add a task\nPress 'D' to delete current Task\n" +
                                    "Press 'Escape' to Save and Quit");
                DisplayList(userList, completed, currentTask, startingPoint, pageLimit);

                Console.CursorVisible = false;
                keyInfo = Console.ReadKey(true).Key;
                UserKeys(userList, completed, keyInfo, ref currentTask, ref startingPoint, ref taskLength);

                var completeLength = completed.Count();
                DeleteDone(userList, completed, ref taskLength, ref completeLength);

            } while (keyInfo != ConsoleKey.Escape);
            Console.Clear();
            Console.WriteLine("Choose save file: 1, 2, 3 \nEnter 'Q' to quit without saving");
            var saveResponse = Console.ReadLine();
            FileSave(userList, filepath1, filepath2, filepath3, saveResponse);

        }

        private static void FileSave(List<string> userList, string filepath1, string filepath2, string filepath3, string saveResponse)
        {
            switch (saveResponse)
            {

                case "1":
                    {

                        File.WriteAllLines(filepath1, userList);
                        break;
                    }
                case "2":
                    {

                        File.WriteAllLines(filepath2, userList);
                        break;
                    }
                case "3":
                    {

                        File.WriteAllLines(filepath3, userList);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private static void DeleteDone(List<string> userList, List<int> completed, ref int taskLength, ref int completeLength)
        {
            if (completed.Contains(0))
            {
                var j = 0;
                completed.Sort();
                for (int i = 1; i < completeLength; i++)
                {
                   
                    if (completed.ElementAt(i) == completed.ElementAt(i-1) + 1)
                    {
                        j++;
                    }

                }
                j++;
                userList.RemoveRange(0, j);
                taskLength = userList.Count();

                completed.RemoveRange(0, j);
                completeLength = completed.Count();

                for (int i = 0; i < completeLength; i++)
                {
                    completed[i] = completed.ElementAt(i) - (j);
                }

            }
        }

        private static void UserKeys(List<string> userList, List<int> completed, ConsoleKey keyInfo, ref int currentTask, ref int startingPoint, ref int taskLength)
        {
            switch (keyInfo)
            {
                case ConsoleKey.A:
                    {
                        Console.Clear();
                        Console.Write("Please type a Task and press enter. Type 'done' when finished, type 'cancel' to return: ");
                        var userInput = Console.ReadLine();
                        if (userInput == "cancel")
                        {
                            break;
                        }
                        else
                        {
                            userList.Add(userInput);
                            taskLength = userList.Count();
                        }
                        break;
                    }
                case ConsoleKey.X:
                    {
                        if (currentTask < taskLength - 1)
                        {
                            currentTask++;
                        }
                        else
                        {
                            currentTask = 0;
                        }
                        break;
                    }
                case ConsoleKey.Z:
                    {
                        if (currentTask > 0)
                        {
                            currentTask--;
                        }
                        else
                        {
                            currentTask = taskLength - 1;
                        }
                        break;
                    }
                case ConsoleKey.C:
                    {
                        if (currentTask <= (taskLength - 1))
                        {

                            completed.Add(currentTask);

                            currentTask++;

                        }
                        else
                        {
                            currentTask = 0;
                        }
                        break;
                    }
                case ConsoleKey.R:
                    {
                        completed.Add(currentTask);
                        var reAdd = userList.ElementAt(currentTask);
                        userList.Add(reAdd);
                        taskLength = userList.Count();
                        currentTask++;

                        break;
                    }
                case ConsoleKey.D:
                    {

                        userList.RemoveAt(currentTask);
                        completed.Remove(currentTask);
                        taskLength = userList.Count();
                        break;

                    }
                case ConsoleKey.N:
                    {

                        startingPoint += 20;
                        currentTask = startingPoint;

                        break;

                    }
                case ConsoleKey.B:
                    {

                        startingPoint -= 20;

                        if (startingPoint < 0)
                        {
                            startingPoint = 0;
                        }                    

                        currentTask = startingPoint;                       
                        break;

                    }

            }

            
        }

        private static void DisplayList(List<string> userList, List<int> completed, int currentTask, int startingPoint, int pageLimit)
        {
            for (int i = startingPoint; i < pageLimit; i++)
            {
                Console.WriteLine();


                if (i == currentTask)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"{i + 1}. {userList.ElementAt(i)}");
                    Console.ResetColor();
                }
                else if (completed.Contains(i))
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"{i + 1}. {userList.ElementAt(i)}");
                    Console.ResetColor();
                }


                else
                {
                    Console.WriteLine($"{i + 1}. {userList.ElementAt(i)}");
                }


            }
        }

        private static int Paging(int startingPoint, int pageLimit, int testLength)
        {
            if (testLength >= 20)
            {
                pageLimit = 20 + startingPoint;

            }
            else if (testLength < 20)
            {
                pageLimit = testLength + startingPoint;
            }

            return pageLimit;
        }

        private static List<string> FileLoad(ref List<string> userList, string filepath1, string filepath2, string filepath3, ref bool done, string userInit)
        {
            if (userInit == "load")
            {

                Console.WriteLine("Choose file to load: 1, 2, 3");
                var loadResponse = Console.ReadLine();
                switch (loadResponse)
                {
                    case "1":
                        {
                            userList = File.ReadAllLines(filepath1).ToList();
                            break;
                        }
                    case "2":
                        {
                            userList = File.ReadAllLines(filepath2).ToList();
                            break;
                        }
                    case "3":
                        {
                            userList = File.ReadAllLines(filepath3).ToList();
                            break;
                        }
                }

            }
            else if (userInit == "new")
            {
                Console.Clear();

                while (!done)
                {

                    Console.Write("Please type a Task and press enter. Type 'done' when finished: ");

                    var userInput = Console.ReadLine();

                    if (userInput == "done")
                    {
                        done = true;
                    }
                    else
                    {
                        userList.Add(userInput);
                    }

                }
            }

            return userList;
        }
    }
}
