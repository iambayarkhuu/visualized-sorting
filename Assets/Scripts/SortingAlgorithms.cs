using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SortingAlgorithms
{
    public static IEnumerator BubbleSort(int[] array, System.Action<int, int> swapCallback, float delay)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    // Swap elements in the array
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;

                    // Call the swap callback to animate the swap in the main script
                    swapCallback(j, j + 1);
                    
                    yield return new WaitForSeconds(delay);
                }
            }
        }
    }
}