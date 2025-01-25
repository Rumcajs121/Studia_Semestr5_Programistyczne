using System.Diagnostics;

var stopwatch = Stopwatch.StartNew();
var array = RandomNumberGenerator.RandomGenerator(1000000);
Console.WriteLine("QuickSort start ...");
LogicalExercise2ConcurrencyProgramming.ExecuteExercise2(array);
Console.WriteLine("QuickSortComplete Succes");
stopwatch.Stop();
Console.WriteLine($"Execute time: {stopwatch.ElapsedMilliseconds} ms");


public static class LogicalExercise2ConcurrencyProgramming
{
    public static int[] ExecuteExercise2(int[]array)
    {
        int parts = 10;
        int partSize = array.Length / parts;
        List<int[]> subArrays = [];
        for (int i = 0; i < parts; i++)
        {
            int start = i * partSize;
            int end = (i == parts - 1) ? array.Length : start + partSize;

            subArrays.Add(array[start..end]);
        }
        List<Task> tasks = new List<Task>();

        for (int i = 0; i < parts; i++)
        {
            int[] subArray = subArrays[i];
            tasks.Add(Task.Run(() => QuickSortAlgorithm.QuickSort(subArray, 0, subArray.Length - 1)));
        }
        Task.WaitAll(tasks.ToArray());

        var sortedArray = MergeArray.MergeSortedArrays(subArrays);
        return sortedArray;
    }
}

public static class RandomNumberGenerator
{
    public static int[] RandomGenerator(int n)
    {
        List<int> data = [];
        for (int i = 0; i < n; i++)
        { 
            int rnd = new Random().Next(1,100);
            data.Add(rnd);
        }

        var dataArray = data.ToArray();
        return dataArray;
    }
}

public static class QuickSortAlgorithm
{
    public static int[] QuickSort(int[] array, int leftIndex, int rightIndex)
    {
        if (leftIndex >= rightIndex)
        {
            return array;
        }

        var pivot = array[(leftIndex + rightIndex) / 2];
        var i = leftIndex;
        var j = rightIndex;

        while (i <= j)
        {
            while (array[i] < pivot)
            {
                i++;
            }

            while (array[j] > pivot)
            {
                j--;
            }

            if (i <= j)
            {
                (array[i], array[j]) = (array[j], array[i]);
                i++;
                j--;
            }
        }

        if (leftIndex < j)
        {
            QuickSort(array, leftIndex, j);
        }

        if (i < rightIndex)
        {
            QuickSort(array, i, rightIndex);
        }

        return array;
    }
}
public static class MergeArray{
    public static int[] MergeSortedArrays(List<int[]> sortedArrays)
    {
        var result = sortedArrays[0]; 

        for (int i = 1; i < sortedArrays.Count; i++)
        {
            result = MergeTwoArrays(result, sortedArrays[i]); 
        }

        return result;
    }

    public static int[] MergeTwoArrays(int[] arr1, int[] arr2)
    {
        int i = 0, j = 0;
        var merged = new List<int>();
        
        while (i < arr1.Length && j < arr2.Length)
        {
            if (arr1[i] < arr2[j])
            {
                merged.Add(arr1[i]);
                i++;
            }
            else
            {
                merged.Add(arr2[j]);
                j++;
            }
        }
        
        while (i < arr1.Length) merged.Add(arr1[i++]);
        while (j < arr2.Length) merged.Add(arr2[j++]);

        return merged.ToArray();
    }
}


