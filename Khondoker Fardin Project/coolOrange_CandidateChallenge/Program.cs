using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static coolOrange_CandidateChallenge.Array;

namespace coolOrange_CandidateChallenge
{
    class Program
    {
        static int GetInt;
        static int[] GetIntArray;
        static int[,] Get2DIntArray;

        static int SelectedIndex = 0;
        static string[] Tasknames =             
        {
            "Maximum value occuring in the array between two positions",
            "Minimum value occuring in the array between two positions",
            "Swap the elements of the two passed positions in the array",
            "Shifts all elements between the given positions in an array",
            "Create an array with random numbers with user defined range",
            "Create a matrix with random numbers, the range of the numbers and size of the matrix is user defined",
            "Create a copy of a randomly generated array in a 2D array",
            "Finds the position of the user given number in a premade array",
            "Finds the position of the user given number in a premade array[Binary search algorithm]",
            "Check for palindrome in words given by the user",
            "Everyday tasks",
        };

        static void Main(string[] args)
        {
            Run();
        }

        public static void HighLightPos(int CurrentI, int P1, int P2)
        {
            if (CurrentI == P1)
            {
                ForegroundColor = ConsoleColor.Red;
            }
            else if (CurrentI == P2)
            {
                ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                ForegroundColor = ConsoleColor.White;
            }

        }

        static void PrintArray(int[] ints)
        {
            WriteLine();

            for (int i = 0; i < ints.Length; i++)
            {
                HighLightPos(i, POS1, POS2);

                WriteLine(i + 1 + ". " + ints[i]);
            }

            ForegroundColor = ConsoleColor.White;
        }

        static void PrintInSA(int[] ints)
        {
            if(GetInt != -1)
            {
                for (int i = 0; i < ints.Length; i++)
                {
                    if (i + 1 == GetInt)
                    {
                        ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.White;
                    }

                    WriteLine((i + 1) + ". " + ints[i]);
                }

                ForegroundColor = ConsoleColor.Green;
                WriteLine("\nThe inserted number can be found on position: " + GetInt);
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("\nThe inserted number cannot be found.");
            }

        }
        static void CallFuncs()
        {
            Console.Clear();

            if (SelectedIndex== 0)
            {
                GenerateRandomPositions();
                int[] TempArray = CreateRandomArray(DefaultArraySize, DefaultMinValue, DefaultMaxValue);

                
                PrintArray(TempArray);

                GetInt = FindMaxValue(TempArray, POS1, POS2);

                WriteLine("\nThe biggest number between position " + (POS1 + 1) + " and position " + (POS2 + 1) + " is " + GetInt);
            }
            else if (SelectedIndex== 1)
            {
                GenerateRandomPositions();
                int[] TempArray = CreateRandomArray(DefaultArraySize, DefaultMinValue, DefaultMaxValue);
                PrintArray(TempArray);

                GetInt = FindMinPosition(TempArray, POS1, POS2);

                WriteLine("\nThe smallest number between position " + (POS1 + 1) + " and position " + (POS2 + 1) + " can be found on position " + (GetInt + 1));
            }
            else if(SelectedIndex== 2)
            {
                GenerateRandomPositions();
                int[] TempArray = CreateRandomArray(DefaultArraySize, DefaultMinValue, DefaultMaxValue);

                Write("\nBEFORE");
                PrintArray(TempArray);

                WriteLine("\nAFTER");
                Swap(TempArray, POS1, POS2);
            }
            else if(SelectedIndex== 3)
            {
                GenerateRandomPositions();
                int[] TempArray = CreateRandomArray(DefaultArraySize, DefaultMinValue, DefaultMaxValue);

                Write("\nOriginal array: ");
                PrintArray(TempArray);

                WriteLine("\nShifted left(up) by one: ");
                ShiftLeftByOne(TempArray, POS1, POS2);
            }
            else if(SelectedIndex== 4)
            {
                Console.Write("Input array size: ");
                int size = Convert.ToInt32(Console.ReadLine());
                Console.Write("Input the lowest value in array: ");
                int min = Convert.ToInt32(Console.ReadLine());
                Console.Write("Input the highest value in array: ");
                int max = Convert.ToInt32(Console.ReadLine());

                GetIntArray = CreateRandomArray(size, min, max);
                WriteLine();
                for (int i = 0; i < GetIntArray.Length; i++)
                {
                    WriteLine((i + 1) + ". " + GetIntArray[i]);
                }
            }
            else if(SelectedIndex == 5)
            {
                Console.Write("Input array's row amount: ");
                int row = Convert.ToInt32(Console.ReadLine());
                Console.Write("Input array's column amount: ");
                int col = Convert.ToInt32(Console.ReadLine());
                Console.Write("Input the lowest value in array: ");
                int min = Convert.ToInt32(Console.ReadLine());
                Console.Write("Input the highest value in array: ");
                int max = Convert.ToInt32(Console.ReadLine());

                Get2DIntArray = CreateRandomMatrix(row, col, min, max);
                WriteLine();

                ForegroundColor = ConsoleColor.Red;

                for (int i = 0; i < row; i++)
                {
                    Write("{0,5}", (i + 1));
                }
                WriteLine();

                for (int i = 0; i < col; i++)
                {
                    ForegroundColor = ConsoleColor.Red;
                    Write("{0,2}",(i + 1));

                    if(i % 2 == 0)
                    {
                        ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.White;
                    }
                    for (int y = 0; y < row; y++)
                    {
                        Write("{0,5}",Get2DIntArray[i, y] + " ");
                    }
                    WriteLine();
                }
            }
            else if(SelectedIndex == 6)
            {
                Get2DIntArray = CopyArray(CreateRandomArray(DefaultArraySize, DefaultMinValue, DefaultMaxValue));

                Write("   ");
                for (int i = 0; i < DefaultArraySize; i++)
                {
                    Write("{0,3}", (i + 1));
                }
                WriteLine();

                for (int i = 0; i < 2; i++)
                {
                    ForegroundColor = ConsoleColor.Red;
                    Write("{0,3}", (i + 1));

                    if (i % 2 == 0)
                    {
                        ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.White;
                    }
                    for (int y = 0; y < DefaultArraySize; y++)
                    {
                        Write("{0,3}", Get2DIntArray[y, i]);
                    }
                    WriteLine();
                }

            }
            else if(SelectedIndex == 7)
            {
                int[] TempArray = CreateRandomArray(DefaultArraySize, DefaultMinValue, DefaultMaxValue);

                for (int i = 0; i < TempArray.Length; i++)
                {
                    WriteLine((i + 1) + ". " + TempArray[i]);
                }

                Console.Write("\nWhat number are you looking for: ");
                int num = Convert.ToInt32(Console.ReadLine());

                GetInt = FindInSortedArray(TempArray, num);
                WriteLine();
                PrintInSA(TempArray);

            }
            else if(SelectedIndex == 8)
            {
                int[] TempArray = new int[10] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

                for (int i = 0; i < TempArray.Length; i++)
                {
                    WriteLine((i + 1) + ". " + TempArray[i]);
                }

                Console.Write("\nWhat number are you looking for: ");
                int num = Convert.ToInt32(Console.ReadLine());

                GetInt = FindInSortedArrayBONUS(TempArray, num);
                WriteLine();
                PrintInSA(TempArray);
            }
            else if(SelectedIndex == 9)
            {
                Write("Input a word to see if it's a palindrome: ");
                string tempWord = ReadLine();

                if(PalindromeChecker.IsPalindrome(tempWord))
                {
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("\n\nThe string (" + tempWord + ") is a palindrome.");
                }
                else
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("\n\nThe string (" + tempWord + ") is not a palindrome.");
                }
            }
            else if(SelectedIndex == 10)
            {
                WriteLine("Didn't do");
            }

            ForegroundColor = ConsoleColor.White;
            Console.Write("\n\nPress ENTER to return to the main menu...");
        }
        public static void Run()
        {
            ConsoleKey keyPressed;

            do
            {
                Clear();
                DisplayMenu();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = ReadKey(true);

                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    if (SelectedIndex == 0)
                    {
                        SelectedIndex = Tasknames.Length - 1;
                    }
                    else
                    {
                        SelectedIndex--;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    if (SelectedIndex == Tasknames.Length - 1)
                    {
                        SelectedIndex = 0;
                    }
                    else
                    {
                        SelectedIndex++;
                    }
                }
                else if(keyPressed == ConsoleKey.Enter)
                {
                    CallFuncs();
                    ReadKey();                    
                }

            } while (keyPressed
            != ConsoleKey.Escape);

        }

        public static void DisplayOptions()
        {
            for (int i = 0; i < Tasknames.Length; i++)
            {
                string currentOption = Tasknames[i];
                string prefix = i + 1 + ". ";

                if (i == SelectedIndex)
                {
                    BackgroundColor = ConsoleColor.DarkYellow;
                    ForegroundColor = ConsoleColor.White;
                }
                WriteLine(prefix + $"{currentOption}");

                ResetColor();
            }
        }

        public static void DisplayMenu()
        {
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine("\n                  _  ____                             \n                 | |/ __ \\                            \n   ___ ___   ___ | | |  | |_ __ __ _ _ __   __ _  ___ \n  / __/ _ \\ / _ \\| | |  | | '__/ _` | '_ \\ / _` |/ _ \\\n | (_| (_) | (_) | | |__| | | | (_| | | | | (_| |  __/\n  \\___\\___/ \\___/|_|\\____/|_|  \\__,_|_| |_|\\__, |\\___|\n                                            __/ |     \n                                           |___/      \n");

            ForegroundColor = ConsoleColor.Green;
            WriteLine("Name: Khondoker Fardin           Date: 19.12.2022");
            ForegroundColor = ConsoleColor.White;
            WriteLine("\nCandidate Challenge");
            WriteLine("What would you like to do? Use arrow keys to move up/down and ENTER to choose.");

            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine("\nTasks\n");
            ForegroundColor = ConsoleColor.White;
        }
        
    }
}
