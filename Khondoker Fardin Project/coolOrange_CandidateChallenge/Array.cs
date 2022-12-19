using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using static System.Console;

namespace coolOrange_CandidateChallenge
{
    public class Array
    {
        // Todo

        public static int DefaultArraySize = 10;
        public static int DefaultMinValue = 1;
        public static int DefaultMaxValue = 100;

        static Random random = new Random();
        public static int[] RandomNumbersArray;

        public static int POS1;
        public static int POS2;

        public static void GenerateRandomPositions()
        {
            POS1 = random.Next(0, DefaultArraySize - 2);
            POS2 = random.Next(POS1 + 2, DefaultArraySize);

            WriteLine("Randomly generated positions are:");

            ForegroundColor = ConsoleColor.Red;
            WriteLine("POS1: " + (POS1 + 1));
            ForegroundColor = ConsoleColor.Green;
            WriteLine("POS2: " + (POS2 + 1));

            ForegroundColor = ConsoleColor.White;
        }

        public static int FindMaxValue(int[] array, int position1, int position2)
        {
            //EXPLANATION: The for loop begins from position1 and runs till the var i has arrived position2 - 1
            //and everytime it checks if the element in the array at position i is bigger than the current
            //maxValue. If yes the var MaxValue saves the element of the array at position i. if not MaxValue
            //remains the same and the loop continues till it i hasn't arrived position2 - 1. When the loop 
            //ends the var MAxValue gets returned.

            int MaxValue = 0;
            for (int i = position1; i <= position2; i++)
            {
                if (array[i] > MaxValue)
                {
                    MaxValue = array[i];
                }

            }
            return MaxValue;
        }

        public static int FindMinPosition(int[] array, int position1, int position2)
        {
            //EXPLANATION: The loop works the same way as the one in FindMaxValue. But it checks if the element
            //in the array at position i is smaller than the current MinValue. if yes it updates both the 
            //var MinValue and MinPosition. In MinValue the element of the array at position i gets saved whereas
            //in MinPosition the var i, which when the loop ends gets returned.

            int MinPosition = 0;
            int MinValue = 100;

            for (int i = position1; i <= position2; i++)
            {
                if (array[i] < MinValue)
                {
                    MinPosition = i;
                    MinValue = array[i];
                }
            }

            return MinPosition;
        }

        public static void Swap(int[] array, int position1, int position2)
        {
            //EXPLANATION: Saves the the element of the array at position1 in the var temVal. Then the element
            //of the array at position2 gets saved in the array at position1. At last the tempVal is saved in
            //the array at position2.

            int tempVal = array[position1];
            array[position1] = array[position2];
            array[position2] = tempVal;

            for (int i = 0; i < array.Length; i++)
            {
                Program.HighLightPos(i, position1, position2);
                WriteLine((i + 1) + ". " + array[i]);
            }
        }

        public static void ShiftLeftByOne(int[] array, int position1, int position2)
        {
            //EXPLANATION: The loop works same as before. this time the element in the array at i gets updated
            //with the element in the array at i + 1. And it does that till var i doesn't equal to position2 - 1.

            
            for (int i = position1; i < position2; i++)
            {
                array[i] = array[i + 1];
            }

            for (int i = 0; i < array.Length; i++)
            {
                if(i >= position1&& i <= position2)
                {
                    ForegroundColor = ConsoleColor.DarkYellow;
                }
                else
                {
                    ForegroundColor = ConsoleColor.White;
                }
                WriteLine((i + 1) + ". " + array[i]);
            }
        }

        public static int[] CreateRandomArray(int size, int minValue, int maxValue)
        {
            //EXPLANATION: Using the Random class of C#, random numbers gets generated in the array. 
            //The size and the range are defined at the top.  
            int[] RandomNumbersArray = new int[size];

            for (int i = 0; i < size; i++)
            {
                RandomNumbersArray[i] = random.Next(minValue, maxValue);
            }

            return RandomNumbersArray;
        }

        public static int[,] CreateRandomMatrix(int rows, int columns, int minValue, int maxValue)
        {
            //EXPLANATION: Again using the Random class of C#, random numbers gets generated in the array. But this
            //time in a 2D array. We have two for loops since it is a 2D array. When the inner loop reaches it's
            //goal the outer loop's counter increments by one and the inner loop runs again.
            int[,] intsMatrix = new int[rows, columns];

            for (int i = 0; i < columns; i++)
            {
                for (int z = 0; z < rows; z++)
                {
                    intsMatrix[i, z] = random.Next(minValue, maxValue);
                }
            }
            return intsMatrix;
        }


        public static int[,] CopyArray(int[] array)
        {
            //EXPLANATION: Pretty much works the same way as the CreateRandomMatrix Function. But the elements are
            //from an array which gets saved in the 2D array. Of course with two loops. The outer loops runs only
            //twice since the array needs to be copied once.
            int[,] CopyArrayVar = new int[array.Length, 2];

            for (int i = 0; i < 2; i++)
            {
                for (int z = 0; z < array.Length; z++)
                {
                    CopyArrayVar[z,i] = array[z];
                }
            }

            return CopyArrayVar;
        }

        public static int FindInSortedArray(int[] array, int number)
        {
            //EXPLANATION: This algorithm is supposed to find the position of the biggest number in the array.
            //Since the numbers in array are randomly generated Binary search algorithm won't work, hence it's 
            //written this way. Every loop it controls if the element of the array is the same as the number. if
            //yes the i + 1 gets returned immediatey. if the whole loops runs through it returns -1, meaning the
            //inserted number is not in the array.
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    return i + 1;
                }
            }
            return -1;
        }

        public static int FindInSortedArrayBONUS(int[] array, int number)
        {
            //EXPLANATION: The binary search algorithm. We have range defined by two variables RangeMIN and RangeMAX
            //which gets updated every loop. Either it lowers or highers and the mid of the range gets compared
            //to the inserted number. Depending on the result the range changes. If RangeMIN becomes bigger than 
            //RangeMAX the code returns -1, meaning the inserted number is not in the array.
            int RangeMIN = 0;
            int RangeMAX = array.Length - 1;

            while (RangeMIN <= RangeMAX)
            {
                int mid = (RangeMIN + RangeMAX) / 2;
                if (number == array[mid])
                {
                    return mid + 1;
                }
                else if (number < array[mid])
                {
                    RangeMAX = mid - 1;
                }
                else
                {
                    RangeMIN = mid + 1;
                }
            }
            return -1;
        }

    }
}
