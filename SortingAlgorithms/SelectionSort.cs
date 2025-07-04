public static void SelectionSort<T>(T[] arr) where T:IComparable
{
    if (arr.Length == 0 || arr.Length == 1) return;
    for(int i = 0; i < arr.Length; i++)
    {
        int minInd = i;
        for(int j = i+1; j < arr.Length; j++)
        {
            if (arr[minInd].CompareTo( arr[j])>0)
            {
                minInd = j;
            }
        }
        if (minInd != i)
        {
            T temp = arr[minInd];
            arr[minInd] = arr[i];
            arr[i] = temp;
        }

    }
}
