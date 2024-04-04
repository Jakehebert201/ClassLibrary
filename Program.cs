using System.Buffers;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;


/// <summary>
/// The purpose of this file is to have a list of things I can reuse later on.
/// </summary>
public class ClassLibrary
{

    /// <summary>
    /// Just a shitty pyramid
    /// </summary>
    /// <param name="height"></param>
    public static void ShittyPyramid(int height)
    {
        string line = "*";
        for (int i = 0; i < height; ++i)
        {
            System.Console.WriteLine(line);
            line += "*";
        }
    }

    /// <summary>
    /// A pyramid that actaully looks good
    /// </summary>
    /// <param name="height"></param>
    public static void GoodPyramid(int height)
    {
        //Output should look like
        /*
             *
            ***
           *****
          *******
         *********
        ***********
        */

        //string.Join("", Enumerable.Repeat("ab", 2)); 
        //I'll be using this type of method to do what I want to do.

        int starCount = 1; // As far as I believe, i will serve as the width in the for loop, I think this is redundant
        int spaceCount = 2 * height - 1; //spaces should be 0 at the bottom, 2*height -1 at the top?
        string line; // spaces + stars
        for (int i = 0; i < height; ++i)
        {
            line = string.Join("", Enumerable.Repeat(" ", spaceCount));
            line += string.Join("", Enumerable.Repeat("*", starCount));

            System.Console.WriteLine(line);
            starCount += 2;
            spaceCount--;
        }

    }


    #region useless validation code
    //Generic user input, hopefully this works the way I want it to #IT DIDNT
    public static T ValidateUserInput<T>()
    {
        Console.Write("Please enter a value:\t ");
        string input = Console.ReadLine();
        Console.Write("\nWhat type should this data be? 1 = string, 2 = int, 3 = double, 4 = long: ");
        while (!int.TryParse(Console.ReadLine(), out int switchControl))
        {
            Console.WriteLine("\nPlease Try Again!");
            Console.Write("What type should this data be? 1 = string, 2 = int, 3 = double, 4 = long: ");

        }
        // Because of T values I just have to specify the return type while calling the method, this is neat, but also kinda useless! ^^ Mainly this!
        // I guess instead of doing the user input on this end, I can have an argument passed through instead that I have to validate, 
        // maybe do it as a bool, but then its just a try parse...hmm
        // OK, I'll just scrap this method for now :(
        T validInput = default;
        return validInput;



    }
    #endregion

    //Ok, lets try something different, SORTING ALGORITHMS

    /// <summary>
    /// Performs bubble sort on an array
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public static int[] BubbleSort(int[] arr)
    {
        int tmp;
        bool swapped;
        //while not at the end of the array, compare the current index with the next index
        for (int i = 0; i < arr.Length - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < arr.Length - 1 - i; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    //swapping values if [i] is greater than [i+1], else do nothing
                    //take the first element, compare it to the next, swap it if it's higher
                    tmp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = tmp;
                    swapped = true;
                }
            }
            if (!swapped)
                break;
        }
        return arr;

    }

    /// <summary>
    /// Bubble sorts a generic data type, so anything can be churned through it!
    /// </summary>
    /// <param name="data"></param>
    /// <typeparam name="T"></typeparam>
    public static void GenericBubbleSort<T>(T[] data) where T : IComparable<T>
    {

        T tmp = default;
        bool swapped;
        for (int i = 0; i < data.Length; ++i)
        {
            swapped = false;
            for (int j = 0; j < data.Length - 1 - i; ++j)
            {
                if (data[j].CompareTo(data[j + 1]) > 0)
                {
                    tmp = data[j];
                    data[j] = data[j + 1];
                    data[j + 1] = tmp;
                    swapped = true;
                }
            }
            if (!swapped)
                break;
        }
    }

    //Merge sort?
    //Need Merge method and Merge Sort Method

    /// <summary>
    /// This is the Merge algorithm for Merge Sort
    /// </summary>
    /// <param name="array"></param>
    /// <param name="leftStart"></param>
    /// <param name="middle"></param>
    /// <param name="rightEnd"></param>
    /// <typeparam name="T"></typeparam>
    public static void Merge<T>(T[] array, int leftStart, int middle, int rightEnd) where T : IComparable<T>
    {
        //Cuts each array down to the smallest possible unit (1)

        //subarrays
        int num1 = middle - leftStart + 1;
        int num2 = rightEnd - middle;

        //new temp arrays
        T[] leftArr = new T[num1];
        T[] rightArr = new T[num2];

        int i, j;
        //Copying data to new arrays
        for (i = 0; i < num1; ++i)
        {
            leftArr[i] = array[leftStart + i];
        }
        for (j = 0; j < num2; ++j)
        {
            rightArr[j] = array[middle + 1 + j];
        }
        i = 0;
        j = 0;

        int k = leftStart;
        while (i < num1 && j < num2)
        {
            if (leftArr[i].CompareTo(rightArr[j]) <= 0)
            {
                array[k] = leftArr[i];
                ++i;
            }
            else
            {
                array[k] = rightArr[j];
                ++j;
            }
            ++k;
        }

        while (i < num1)
        {
            array[k] = leftArr[i];
            i++;
            k++;
        }

        while (j < num2)
        {
            array[k] = rightArr[j];
            k++;
            j++;
        }
    }

    public static void MergeSort<T>(T[] array, int leftStart, int rightEnd) where T : IComparable<T>
    {
        if (leftStart < rightEnd)
        {
            int middle = leftStart + (rightEnd - leftStart) / 2;

            MergeSort(array, leftStart, middle);
            MergeSort(array, middle + 1, rightEnd);

            Merge(array, leftStart, middle, rightEnd);
        }
    }

    public static void BogoSort<T>(T[] array) where T : IComparable<T>
    {
        int elements = array.Length;
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Random randy = new Random();
        while (!IsSorted(array))
        {
            Shuffle(array, randy);
        }
        sw.Stop();
        System.Console.WriteLine("Bogo Sort took {0} ms, that's pretty impressive!", sw.ElapsedMilliseconds);
        AppendToFile("BogoTimes.csv", (double)sw.ElapsedMilliseconds / 1000, elements);
    }
    private static bool IsSorted<T>(T[] array) where T : IComparable<T>
    {
        for (int i = 1; i < array.Length; ++i)
        {
            if (array[i - 1].CompareTo(array[i]) > 0)
            {
                return false;
            }
        }
        return true;
    }
    private static void Shuffle<T>(T[] array, Random randy)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = randy.Next(n--);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
        System.Console.WriteLine($"Bogo sort has this: {string.Join(" ", array)}");
    }
    /// <summary>
    /// Incredibly simple implementation, I think it works.
    /// </summary>
    /// <param name="filename"></param>
    /// <returns></returns>
    public static string[] GetArrayFromFile(string filename)
    {
        // Use a List<string> for dynamic collection of lines
        List<string> lines = new List<string>();

        // Use StreamReader within a using statement for automatic disposal
        using (StreamReader sr = new StreamReader(filename))
        {
            while (!sr.EndOfStream)
            {
                lines.Add(sr.ReadLine());
            }
        }

        // Convert the List<string> to an array and return it
        return lines.ToArray();
    }
    public static void AppendToFile(string filename, double completionTime, int arrSize)
    {
        // Check if file exists before creating StreamWriter
        bool fileExists = File.Exists(filename);

        using (StreamWriter sw = new StreamWriter(filename, true))
        {
            if (!fileExists)
            {
                // File was just created, so add the header
                sw.WriteLine("This is a file to log the bogo sort times!");
                sw.WriteLine("Completion Time, Array Size");
            }

            // Append the new data
            sw.WriteLine($"{completionTime}, {arrSize}");
        } // StreamWriter is automatically flushed and closed here, due to 'using'
    }



}


