namespace SearchFor2DArray.Search
{
    public class QuickSort
    {
        private readonly int[,] arr;
        private readonly int cols;
        private readonly int rows;


        public QuickSort(int[,] arr, int cols, int rows)
        {
            this.arr = arr;
            this.cols = cols;
            this.rows = rows;
        }

        private void increaseLeftIndex(ref int leftCol, ref int leftRow, ref int i)
        {
            if (leftCol == cols - 1)
            {
                leftRow++;
                leftCol = 0;
            }
            else
            {
                leftCol++;
            }
            i++;
        }

        private void decreaseRightIndex(ref int rightCol, ref int rightRow, ref int j)
        {
            if (rightCol == 0)
            {
                rightRow--;
                rightCol = cols - 1;
            }
            else
            {
                rightCol--;
            }
            j--;
        }

        private void quickSort(int[,] arr, int left, int right)
        {
            int mid = (left + right) / 2;
            int midRow = mid / cols;
            int midCol = mid % cols;

            int middle = arr[midRow, midCol];

            int i = left, j = right;


            int leftRow = i / cols;
            int leftCol = i % cols;

            int rightRow = j / cols;
            int rightCol = j % cols;


            while (i < j)
            {
                while (arr[leftRow, leftCol] < middle)
                {
                    increaseLeftIndex(ref leftCol, ref leftRow, ref i);
                }

                while (arr[rightRow, rightCol] > middle)
                {
                    decreaseRightIndex(ref rightCol, ref rightRow, ref j);
                }

                if (i <= j)
                {
                    int temp = arr[leftRow, leftCol];
                    arr[leftRow, leftCol] = arr[rightRow, rightCol];
                    arr[rightRow, rightCol] = temp;

                    increaseLeftIndex(ref leftCol, ref leftRow, ref i);

                    decreaseRightIndex(ref rightCol, ref rightRow, ref j);
                }
            }


            if (left < j) quickSort(arr, left, j);
            if (i < right) quickSort(arr, i, right);
        }

        public void sort()
        {
            quickSort(arr, 0, arr.Length - 1);
        }
    }
}