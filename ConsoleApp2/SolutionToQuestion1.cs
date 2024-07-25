public static class SolutionToQuestion1
{
    public enum Color
    {
        Green = 0,
        Yellow = 1,
        Red = 2
    }

    public static void SortColors(Color[] arr)
    {
        int low = 0;
        int mid = 0;
        int high = arr.Length - 1;

        while (mid <= high)
        {
            if (arr[mid] == Color.Green)
            {
                Swap(arr,mid,low);
                low++;
                mid++;
            }
            else if (arr[mid] == Color.Yellow)
            {
                mid++;
            }
            else
            {
                Swap(arr,mid,high);
                high--;
            }
        }
    }

    public static void Swap(Color[] arr, int i, int j)
        =>  (arr[i], arr[j]) = (arr[j], arr[i]);
}