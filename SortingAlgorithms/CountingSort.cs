namespace Counting_Sort
{
    internal class Program
    {
        public static void CountingSort(int[] arr)
        {
            int max = Int32.MinValue;
            int min = Int32.MaxValue;
            foreach (var item in arr)
            {
                if (item > max)
                {
                    max = item;
                }
                if (min > item) min = item;
            }
            int[] counts = new int[max-min+1];
            foreach (var item in arr)
            {
                counts[item - min]++;
            }
            int i = 0;
            int j = 0;
            while (i < counts.Length)
            {
                if (counts[i] == 0)
                {
                    i++;
                    continue;
                }
                arr[j] =min + i;
                counts[i]--;
                j++;
            }
        }
        public static void CountingSortStable(int[] arr)
        {
            int max = Int32.MinValue;
            int min = Int32.MaxValue;
            int[] res = new int[arr.Length];
            foreach (var item in arr)
            {
                if (item > max)
                {
                    max = item;
                }
                if (min > item) min = item;
            }
            int[] counts = new int[max - min + 1];
            foreach (var item in arr)
            {
                counts[item - min]++;
            }
            for (int i = 1; i < counts.Length; i++)
            {
                counts[i] += counts[i - 1];
            }
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                res[--counts[arr[i] - min]] = arr[i];
            }
            for (int i = 0; i < res.Length; i++)
            {
                arr[i] = res[i];
            }
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
            
        }
    }
}
