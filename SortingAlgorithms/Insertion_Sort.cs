namespace InsSort{
public static void Insertion<T>(T[] arr) where T :IComparable
{
    if (arr.Length == 0 || arr.Length == 1) return;
    for (int i = 1; i < arr.Length; i++)
    {
        T val = arr[i ];
        int j = i - 1;
        while (j >= 0 && arr[j].CompareTo(val) > 0)
        {
            arr[j + 1] = arr[j];
            j--;
        }
        arr[j + 1] = val;
    }
}
}
