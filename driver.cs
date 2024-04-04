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
    }
}