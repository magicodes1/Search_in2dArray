namespace SearchFor2DArray.Search;

public class BinarySearch
{
    private readonly int[,] arr;
    private readonly int cols;
    private readonly int rows;


    public BinarySearch(int[,] arr, int cols, int rows)
    {
        this.arr = arr;
        this.cols = cols;
        this.rows = rows;
    }

    private void binarySearch(int left, int right, int[,] arr, int x)
    {
        int mid = (left + right) / 2;
        int midRow = mid / cols;
        int midCol = mid % cols;

        if (arr[midRow, midCol] == x)
        {
            System.Console.WriteLine($"your number that you want to find is at row {midRow}  and column {midCol}.");
            return;
        }
        if(left > right) 
        {
            System.Console.WriteLine("not found");
            return;
        }

        if (x < arr[midRow, midCol])
        {
            binarySearch(left, mid - 1, arr, x);
        }
        else
        {
            binarySearch(mid + 1, right, arr, x);
        }


    }

    public void Search(int x)
    {
        binarySearch(0, arr.Length - 1, arr,x);
    }

}