using System.Buffers;
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

}


