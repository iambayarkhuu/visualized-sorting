using System;
using System.Diagnostics;
using System.Collections;
using UnityEngine;
public class DataHelper : MonoBehaviour
{
    private static readonly System.Random rng = new();

    // Generic shuffle method to shuffle any array in place
    public static IEnumerator Shuffle<T1, T2>(T1[] array, T2[] array2, GameObject[] shapes, float delay, MonoBehaviour coroutineStarter)
    {
        if (array.Length != array2.Length)
            throw new ArgumentException("Both arrays must have the same length.");

        int n = array.Length;
        for (int i = n - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            Swap(array, i, j);       // Swap elements in the first array
            
            // Start the SwapShapes coroutine to animate the swap
            yield return coroutineStarter.StartCoroutine(SwapShapes(shapes, i, j, delay));
            Swap(array2, i, j);      // Swap elements in the second array

        }
    }


    // Swap method to exchange elements at positions i and j
    private static void Swap<T>(T[] array, int i, int j)
    {
        (array[j], array[i]) = (array[i], array[j]);
    }

    private static void Swap<T>(T[] array, int i, int j, string k)
    {
        if(k=="gameObject")
        {
            (array[j], array[i]) = (array[i], array[j]);

        }
    }

    public static IEnumerator SwapShapes(GameObject[] shapes, int index1, int index2, float duration)
    {
        Vector3 startPos1 = shapes[index1].transform.position;
        Vector3 startPos2 = shapes[index2].transform.position;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            shapes[index1].transform.position = Vector3.Lerp(startPos1, startPos2, elapsed / duration);
            shapes[index2].transform.position = Vector3.Lerp(startPos2, startPos1, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Final positions to ensure exact swap
        shapes[index1].transform.position = startPos2;
        shapes[index2].transform.position = startPos1;

        // Swap GameObject references to keep tracking consistent
        GameObject temp = shapes[index1];
        shapes[index1] = shapes[index2];
        shapes[index2] = temp;
    }
    
}   