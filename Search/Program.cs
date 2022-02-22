
using SearchFor2DArray.Search;

const int cols = 8;
const int rows = 7;


bool CheckDuplicate(int newrandomNum, List<int> arr)
{
    foreach (var item in arr)
    {
        if (item == newrandomNum)
        {
            return true;
        }
    }
    return false;
}

bool checkEmptyValue(int[,] arr)
{
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            if (arr[i, j] == 0)
            {
                return true;
            }
        }
    }
    return false;
}

void input(ref int[,] arr, Random ran, int min, int max, List<int> uniqueNumbers)
{
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            int uniqueNumber = ran.Next(min, max);

            if (arr[i, j] != 0) continue;

            if (i == 0 && j == 0)
            {
                uniqueNumbers.Add(uniqueNumber);
                arr[i, j] = uniqueNumber;

            }
            else
            {
                bool check = CheckDuplicate(uniqueNumber, uniqueNumbers);
                if (!check)
                {
                    uniqueNumbers.Add(uniqueNumber);
                    arr[i, j] = uniqueNumber;
                }
            }
        }
    }

}

void random(ref int[,] arr)
{
    int min = 1;
    int max = 100;
    List<int> uniqueNumbers = new List<int>((rows * cols));
    var ran = new Random(DateTime.Now.Millisecond);
    input(ref arr, ran, min, max, uniqueNumbers);

    while (checkEmptyValue(arr)) input(ref arr, ran, min, max, uniqueNumbers);
}



void print(int[,] arr)
{
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            System.Console.Write($"{arr[i, j]} \t");
        }
        System.Console.WriteLine();
    }
}

void main()
{
    var arr = new int[rows, cols];

    random(ref arr);
    System.Console.WriteLine("A random array which is not sorted at all:\n");
    print(arr);

    // var insertSort = new InsertSort(arr, cols, rows);
    // insertSort.sort();
    var quickSort = new QuickSort(arr, cols, rows);
    quickSort.sort();

    System.Console.WriteLine("\nArray has been sorted:\n");

    print(arr);

    System.Console.Write("\nPlease input a number that you want to find:");
    int number = int.Parse(Console.ReadLine()!);

    var binarySearch = new BinarySearch(arr,cols,rows);

    binarySearch.Search(number);


}

main();