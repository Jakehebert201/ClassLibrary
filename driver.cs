using System.Data;

public class Program
{
    static void Main(string[] args)
    {
        ClassLibrary.GoodPyramid(5);
        ClassLibrary.ShittyPyramid(5);
        //string test = ClassLibrary.ValidateUserInput<string>();
        int[] sortme = { 5, 7, 1, 0, 29, 109, 309, 195, 125, 68, 188, 10 };
        int[] sortedarr = (ClassLibrary.BubbleSort(sortme));
        // foreach (int num in sortedarr)
        // {
        //     if (num != sortedarr.Last())
        //         Console.Write("{0},", num);
        //     else
        //         Console.Write("{0}\n", num);
        // }
        System.Console.WriteLine($"Sorted Array: {string.Join(", ", sortedarr)}");

        char[] alphabet = { 'a', 'l', 'c', 'd', 'f', 'g', 'h', 'i', 'b', 'j', 'k', 'm', 'e', 'n', 'o', 'p', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'q', 'z' }; // It's not quite in order
        ClassLibrary.GenericBubbleSort(alphabet);
        Console.WriteLine($"Sorted Alphabet: {string.Join(",", alphabet)}");
        string makeMeACharArray = "This should really just be an array of characters!";
        char[] basicallyAString = new char[255];
        int basicallyAStringindexer = 0;
        foreach (char letter in makeMeACharArray)
        {
            basicallyAString[basicallyAStringindexer] = letter;
            basicallyAStringindexer++;
        }
        Console.WriteLine("This is basically a string:\t {0}", string.Join("", basicallyAString));





    }
}