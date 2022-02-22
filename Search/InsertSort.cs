namespace SearchFor2DArray.Search
{
    public class InsertSort
    {
        private readonly int[,] arr;
        private readonly int cols;
        private readonly int rows;


        public InsertSort(int[,] arr, int cols, int rows)
        {
            this.arr = arr;
            this.cols = cols;
            this.rows = rows;
        }

        public void sort()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int curColIndex = j;
                    int curRowIndex = i;


                    while ((curColIndex > 0 && curRowIndex >= 0) || (curColIndex >= 0 && curRowIndex > 0))
                    {
                        int preindexCols = (curColIndex == 0) ? (cols - 1) : (curColIndex - 1);
                        int preindexRows = (curColIndex == 0) ? (curRowIndex - 1) : curRowIndex;
                        
                        if (arr[curRowIndex, curColIndex] < arr[preindexRows, preindexCols])
                        {
                            int tmp = arr[curRowIndex, curColIndex];
                            arr[curRowIndex, curColIndex] = arr[preindexRows, preindexCols];
                            arr[preindexRows, preindexCols] = tmp;
                        }
                        curColIndex = preindexCols;
                        curRowIndex = preindexRows;
                    }
                }
            }
        }
    }
}