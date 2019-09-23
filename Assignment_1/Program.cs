using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace Assignment1_F19
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1, b = 22;
            printSelfDividingNumbers(a, b);
            int n2 = 5;
            printSeries(n2);
            int n3 = 5;
            printTriangle(n3);
            int[] J = new int[] { 1, 3 };
            int[] S = new int[] { 1, 3, 3, 2, 2, 2, 2, 2 };
            int r4 = numJewelsInStones();
            Console.WriteLine(r4);

            int[] arr1 = { 1, 2, 5, 6, 7, 8, 9 };
            int[] arr2 = { 1, 2, 3, 4, 5 };

            int[] LargestCommonSubArray = getLargestCommonSubArray(arr1, arr2);
            Console.WriteLine("The Largest contiguous sub array is ");
            Console.Write("[");
            for (int i = 0; i < LargestCommonSubArray.Length; i++)
            {
                if (i == 0)
                {
                    Console.Write(LargestCommonSubArray[i]);
                }
                else
                {
                    Console.Write("," + LargestCommonSubArray[i]);
                }

            }

            Console.Write("]");
            //SolvePuzzle();
        }

        public static void printSelfDividingNumbers(int a, int b)
        {
            try
            {

                // Function to check if all 
                // digits of n divide it or not, 

                for (int i = a; i < b + 1; i++)
                {
                    string i_s = i.ToString();
                    //considering each digit of the number into a list
                    char[] digilist = i_s.ToCharArray();
                    string condition = "";

                    //Console.WriteLine(" CHecking number .... " + i);
                    while (i > 0)
                    {
                        //checking if the number is divisible by each digit
                        for (int d = 0; d < digilist.Length; d++)
                        {
                            int digit = int.Parse(digilist[d].ToString());

                            //Checking if the digit is Zero, As anything divided by zero is infinite.
                            if (digit == 0)
                            {
                                condition = condition + "false";
                            }

                            else
                            {
                                int remainder = i % digit;
                                if (remainder != 0)
                                {
                                    condition = condition + "false";
                                }
                                else
                                {
                                    condition = condition + "true";
                                }
                            }
                        }
                        if (condition.Contains("false"))
                        {
                            //Shows us the non-self divisible numbers. 
                            //Console.WriteLine(i + "   Is not a Self-Divisible Number" );
                        }
                        else
                        {
                            Console.WriteLine(i + "   Is a Self Divisble Number");
                        }
                        break;
                    }

                    Console.ReadLine();
                }
                //return true;

            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSelfDividingNumbers()");
            }
        }

        public static void printSeries(int n2)
        {
            try
            {
                Console.WriteLine("enter a number for printing series : ");
                n2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("The Series of the entered number is: ");
                //declaring a string to print all the numbers in a single line
                string toprint = "";
                // Starting loop from 1 to lessthan or equal to n.  
                for (int i = 1; i < n2 + 1; i++)
                {
                    //starting j from 1, to 1
                    for (int j = 1; j < i + 1; j++)
                    {
                        //converting i to string and assigning it to 'toprint'
                        toprint = toprint + " " + i.ToString();
                    }
                }
                Console.WriteLine(toprint);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSeries()");
            }
        }

        public static void printTriangle(int n3)
        {
            try
            {
                //taking the number n from console.
                Console.WriteLine("enter the number of rows : ");
                //Reading the user input
                n3 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("The pattern for Inverted Triangle is: ");
                //
                int j = 0;
                for (int i = n3; i > 0; i--)
                {
                    for (j = n3 - i; j > 0; j--)
                    {
                        Console.Write(" ");
                    }
                    //Determining the pattern of the triangle for printing
                    for (j = (2 * i) - 1; j > 0; j--)
                    {
                        Console.Write("*");
                    }
                    Console.Write("\n");
                }
                Console.ReadKey();
                //Ref for Print Inverted traingle "http://alltypecoding.blogspot.com/2015/05/how-to-printing-reverse-triangle-in-c.html"
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }

        public static int numJewelsInStones()
        {
            try
            {
                //Declaring new lists and providing values
                List<int> j = new List<int>(new int[] { 1, 2, 2, 3, 3 });
                List<int> s = new List<int>(new int[] { 3, 3, 3, 4, 4 });
                int count = 0;
                //Loop to check the distinct values of jewels.
                foreach (int u in j.Distinct())
                {
                    //Findall to check all the distinct values in j.
                    List<int> TEST = s.FindAll(item => item == u);
                    //Checking the count as the count of no of stones that are jewels is requested. 
                    count = count + TEST.Count();
                }
                Console.WriteLine(count);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing numJewelsInStones()");
            }
            return 0;
        }

        public static int[] getLargestCommonSubArray(int[] arr1, int[] arr2)
        {

            Array.Sort(arr1);
            Array.Sort(arr2);

            //Checking the length of the variable 
            int arr1_length = arr1.Length;
            int arr2_length = arr2.Length;

            var subarray_intersect = new List<int>();

            //for every element in arr1
            for (int i = 1; i <= arr1.Length - 1; i++)
            {
                //checking for contiguous subarray 
                bool cont = false;
                //searching each element of arr1. If it is continuous.
                if (arr1[i] == arr1[i - 1] + 1)
                {
                    if (i == 1)
                    {
                        //search for arr1[i-1];
                        cont = SearchInArray(arr1[i - 1], arr2);
                        if (cont == true)
                        {
                            //keeping the number which matches 
                            subarray_intersect.Add(arr1[i - 1]);
                        }

                    }

                    //search for current value arr1[i];
                    cont = SearchInArray(arr1[i], arr2);
                    if (cont == true)
                    {
                        subarray_intersect.Add(arr1[i]);
                    }

                }

                //If number in search less than length
                else if (i != arr1.Length - 1)
                {
                    if (arr1[i] == arr1[i + 1] - 1)
                    {
                        //search for arr1[i];
                        cont = SearchInArray(arr1[i], arr2);
                        if (cont == true)
                        {
                            subarray_intersect.Add(arr1[i]);
                        }
                    }

                }

            }

            foreach (int m in subarray_intersect)
            {
                Console.WriteLine(m);
            }
            int[] comm_sub_array = findCommonSubArray(subarray_intersect);
            return comm_sub_array;

        }

        public static bool SearchInArray(int val_eql, int[] arr2)
        {
            //checking the values for arr2
            int low = 0;
            int high = (arr2.Length) - 1;
            //Searching whether 
            int mid = (low + high) / 2;
            int mid_value = 0;
            int track_middle_high = 0;

            while (low <= high)
            {
                mid = (low + high) / 2;
                mid_value = arr2[mid];

                if (mid_value == val_eql)
                {
                    Console.WriteLine("Search Element Found");
                    return true;

                }

                else if (mid_value > val_eql && track_middle_high != mid_value)
                {
                    high = mid - 1;
                    track_middle_high = mid_value;
                }

                else
                {
                    low = mid + 1;
                }

            }

            if (low > high)
            {
                Console.WriteLine("Number doens't exist ");
                return false;
            }

            return false;

        }

        public static int[] findCommonSubArray(List<int> common_sub_array)
        {
            //Initializing temperory vaiables
            List<int> t1 = new List<int>();
            List<int> t2 = new List<int>();
            bool t3 = true;
            bool t4 = true;

            for (int i = 0; i < common_sub_array.Count - 1; i++)
            {
                //comparing sub-arrays
                if (t3 == false && t4 == false)
                {
                    //checking variables counts
                    if (t1.Count == t2.Count)
                    {
                        if (t1[0] > t2[0])
                        {
                            t2.Clear();
                        }

                        else
                        {
                            t1.Clear();
                        }
                    }

                    else if (t1.Count > t2.Count)
                    {
                        t2.Clear();
                    }
                    else
                    {
                        t1.Clear();
                    }
                    //t1 after comparing

                    //For every value in t1
                    for (int j = 0; j < t1.Count; j++)
                    {
                        //Console.WriteLine(t1[j]);

                    }
                    //first comparison

                    for (int j = 0; j < t2.Count; j++)
                    {
                        ////checking temperory variable
                        //Console.WriteLine(t2[j]);
                    }

                }

                //checking for contiguous variables from common_sub_array

                if (common_sub_array[i] == (common_sub_array[i + 1] - 1))
                {
                    if (t3 == true || t1.Count == 0)
                    {
                        if (t1.Count == 0)
                        {
                            t1.Add(common_sub_array[i]);
                            t1.Add(common_sub_array[i + 1]);
                        }
                        else
                        {
                            t1.Add(common_sub_array[i + 1]);

                        }
                    }

                    else
                    {
                        if (t1.Count != 0)
                        {
                            t3 = false;
                        }
                        else { }

                        if (t2.Count == 0)
                        {
                            t2.Add(common_sub_array[i]);
                            t2.Add(common_sub_array[i + 1]);

                        }
                        else if (t4 == true)
                        {

                            t2.Add(common_sub_array[i + 1]);
                        }
                    }
                    if (i == common_sub_array.Count - 2)
                    {
                        t3 = false;
                        t4 = false;
                    }
                }
                else
                {

                    if (t1.Count != 0)
                    {
                        t3 = false;
                    }
                    else { }

                    if ((common_sub_array[i] == (common_sub_array[i + 1] - 1)) && t2.Count == 0)
                    {
                        t2.Add(common_sub_array[i]);
                        t2.Add(common_sub_array[i + 1]);
                    }
                    else if (common_sub_array[i] == (common_sub_array[i + 1] - 1) && t4 == true)
                    {
                        t2.Add(common_sub_array[i + 1]);
                    }
                    else if (t2.Count != 0)
                    {
                        t4 = false;
                    }

                    if (i == common_sub_array.Count - 2)
                    {
                        t3 = false;
                        t4 = false;
                    }
                }

                if (i == common_sub_array.Count - 2)
                {
                    t3 = false;
                    t4 = false;
                }
            }

            //Console.WriteLine("t1");

            for (int i = 0; i < t1.Count; i++)
            {
                //checking temperory variable
                //Console.WriteLine(t1[i]);

            }
            //checking temperory variable
            //Console.WriteLine(t3);

            for (int i = 0; i < t2.Count; i++)
            {
                //printing and checking the number 
                //Console.WriteLine(t2[i]);

            }
            //checking temperory variable
            //Console.WriteLine(t3);

            if (t3 == false && t4 == false)
            {
                if (t1.Count == t2.Count)
                {

                    if (t1[0] > t2[0])
                    {
                        t2.Clear();
                    }

                    // checking for t2
                    else
                    {
                        t1.Clear();
                    }
                }

                else if (t1.Count > t2.Count)
                {
                    t2.Clear();
                }
                else
                {
                    t1.Clear();
                }

                //Console.WriteLine("t1 after comparision 2");
                //t1 second comparison

                for (int j = 0; j < t1.Count; j++)
                {
                    //printing and checking the number 
                    //Console.WriteLine(t1[j]);

                }


                //Console.WriteLine("t2 after comparision 2");
                for (int j = 0; j < t2.Count; j++)
                {
                    //printing and checking the number 
                    //Console.WriteLine(t2[j]);

                }


            }

            //int final_common_sub_array_size = 0;

            if (t1.Count > t2.Count)
            {
                //final_common_sub_array_size = temp1.Count;
                int[] final_common_sub_array = t1.ToArray();
                return final_common_sub_array;
            }
            else
            {
                int[] final_common_sub_array = t2.ToArray();
                return final_common_sub_array;

            }


        }


        public void SolvePuzzle()
        {
            try
            {
                Console.WriteLine("Puzzle");
            }
            catch
            {
                Console.WriteLine("Exception occured while computing solvePuzzle()");
            }
        }

    }
}
/*
This assignment forced me to perfect on loops, conditional statements, strings, arrays out of many other things.
If there could be of some clue/tip for puzzle. It would be helpful in solving it.  */