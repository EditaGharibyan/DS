namespace MergeSort{
public static void MergeSort<T>(T[] arr,int left,int right) where T : IComparable
  {
      if (left >= right) return;
      int mid = left + (right - left) / 2;
      MergeSort(arr, left, mid);
      MergeSort(arr, mid + 1, right);
      Merge(arr,left,mid,right);
  }
  public static void Merge<T>(T[] arr,int left,int mid,int right) where T: IComparable
  {
      T[] tmpArray = new T[right-left+1];
      int i = left;
      int j = mid+1;
      int k = 0;
    
      while(i<=mid && j <= right)
      {
          if (arr[i].CompareTo(arr[j])>0)
          {
              tmpArray[k] = arr[j];
              j++;
          }
          else
          {
              tmpArray[k] = arr[i];
              i++;
          }
          k++;
      }
      while (i <= mid)
      {
          tmpArray[k] = arr[i];
          k++;
          i++;
      }
      while (j <= right)
      {
          tmpArray[k] = arr[j];
          j++;
          k++;
      }
      k = 0;
      while (k < tmpArray.Length)
      {
          arr[left + k] = tmpArray[k];
          k++;
      }
  }
  }
