using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    public static IEnumerator InsertionSort(int[] array, Action<int, int> swapCallback, float delay)
    {
        int n = array.Length;
        for (int i = 1; i < n; i++)
        {
            int key = array[i];
            int j = i - 1;
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                swapCallback(j + 1, j);  // Visualize the swap
                yield return new WaitForSeconds(delay);
                j--;
            }
            array[j + 1] = key;
        }
    }

    public static IEnumerator SelectionSort(int[] array, Action<int, int> swapCallback, float delay)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIdx = i;
            for (int j = i + 1; j < n; j++)
            {
                if (array[j] < array[minIdx])
                {
                    minIdx = j;
                }
            }
            if (minIdx != i)
            {
                int temp = array[i];
                array[i] = array[minIdx];
                array[minIdx] = temp;

                swapCallback(i, minIdx); // Visualize the swap
                yield return new WaitForSeconds(delay);
            }
        }
    }

    public static IEnumerator CocktailShakerSort(int[] array, Action<int, int> swapCallback, float delay)
    {
        bool swapped = true;
        int start = 0;
        int end = array.Length - 1;

        while (swapped)
        {
            swapped = false;

            for (int i = start; i < end; i++)
            {
                if (array[i] > array[i + 1])
                {
                    int temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;

                    swapCallback(i, i + 1); // Visualize the swap
                    yield return new WaitForSeconds(delay);
                    swapped = true;
                }
            }

            if (!swapped) break;

            swapped = false;
            end--;

            for (int i = end - 1; i >= start; i--)
            {
                if (array[i] > array[i + 1])
                {
                    int temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;

                    swapCallback(i, i + 1); // Visualize the swap
                    yield return new WaitForSeconds(delay);
                    swapped = true;
                }
            }
            start++;
        }
    }

    public static IEnumerator CombSort(int[] array, Action<int, int> swapCallback, float delay)
    {
        int n = array.Length;
        int gap = n;
        bool swapped = true;

        while (gap != 1 || swapped)
        {
            gap = (int)(gap / 1.3);
            if (gap < 1) gap = 1;

            swapped = false;
            for (int i = 0; i < n - gap; i++)
            {
                if (array[i] > array[i + gap])
                {
                    int temp = array[i];
                    array[i] = array[i + gap];
                    array[i + gap] = temp;

                    swapCallback(i, i + gap); // Visualize the swap
                    yield return new WaitForSeconds(delay);
                    swapped = true;
                }
            }
        }
    }

    public static IEnumerator CycleSort(int[] array, Action<int, int> swapCallback, float delay)
    {
        int n = array.Length;

        for (int cycleStart = 0; cycleStart < n - 1; cycleStart++)
        {
            int item = array[cycleStart];
            int pos = cycleStart;

            for (int i = cycleStart + 1; i < n; i++)
                if (array[i] < item) pos++;

            if (pos == cycleStart) continue;

            while (item == array[pos]) pos++;

            if (pos != cycleStart)
            {
                int temp = item;
                item = array[pos];
                array[pos] = temp;

                swapCallback(cycleStart, pos); // Visualize the cycle start swap
                yield return new WaitForSeconds(delay);
            }

            while (pos != cycleStart)
            {
                pos = cycleStart;
                for (int i = cycleStart + 1; i < n; i++)
                    if (array[i] < item) pos++;

                while (item == array[pos]) pos++;

                if (item != array[pos])
                {
                    int temp = item;
                    item = array[pos];
                    array[pos] = temp;

                    swapCallback(cycleStart, pos); // Visualize the cycle continuation swap
                    yield return new WaitForSeconds(delay);
                }
            }
        }
    }
}