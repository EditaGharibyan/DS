namespace QuickSort{
  namespace QuickSort
{
    
    internal class Program
    {
        public static void  QuickSort(int[] arr,int left,int right)
        {
            if (left >= right) return;
            int mid = KPartitionFirst(arr,left,right);
            QuickSort(arr,left,mid-1);
            QuickSort(arr,mid+1,right);


        }
        private static readonly Random rand = new Random();
        public static int RandomPart(int[] arr,int left,int right)
        {
            int rand1 = rand.Next(left, right+1);
            Swap(arr, rand1, right);
            return PartitionLast(arr,left,right);
        }
        public static void Swap(int[] arr, int i, int j)
        {
            int tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
        public static int MedianPart(int[] arr,int left,int right)
        {
            int mid = left + (right - left) / 2;
            if (arr[left] > arr[mid])
            {
                Swap(arr,left,mid);
            }
            if (arr[left] > arr[right])
            {
                Swap(arr, left, right);
            }
            if (arr[mid] > arr[right])
            {
                Swap(arr, right, mid);
            }
            Swap(arr, mid, right);
            return PartitionLast(arr, left, right);
        }
        public static int PartitionLast(int[] arr,int left,int right)
        {
            int i = left;
            int j = right - 1;
            int pivot = arr[right];
            while (i<=j)
            {
                while (i <= j && arr[i] < pivot) i++;
                while (i <= j && arr[j] > pivot) j--;
                if (i < j)
                {
                    Swap(arr, i, j);
                }
            }
            Swap(arr, right, i);
            return i;
        }
        //first index
        public static int PartitionFirst(int[] arr ,int left,int right)
        {
            int pivot = arr[left];
            int i = left + 1;
            int j = right;
            while (i <=j)
            {
                while (i <= j && arr[i] < pivot) i++;
                while (i <= j && arr[j] > pivot) j--;
                if (i <= j)
                {
                    Swap(arr, i, j);
                    i++;
                    j--;
                }
            }
            Swap(arr, j, left);
            return j;

        }
    }
