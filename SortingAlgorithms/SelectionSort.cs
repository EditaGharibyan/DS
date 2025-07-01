namespace SelectionSort{

public static void BubbleSort<T>(T[] arr) where T :IComparable
{
    if (arr.Length == 0 || arr.Length == 1) return;
    for (int i = 0; i < arr.Length; i++)
    {
        for(int j = 0; j < arr.Length; j++)
        {
            if (j+1<arr.Length && arr[j].CompareTo( arr[j + 1])>0)
            {
                T temp = arr[j + 1];
                arr[j + 1] = arr[j];
                arr[j] = temp;
            }
        }
    }
}
}
