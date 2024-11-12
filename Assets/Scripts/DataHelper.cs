using System;
public static class DataHelper
{
    private static readonly System.Random rng = new();

    // Generic shuffle method to shuffle any array in place
    public static void Shuffle<T1, T2>(T1[] array, T2[] array2)
    {
        if (array.Length != array2.Length)
            throw new ArgumentException("Both arrays must have the same length.");

        int n = array.Length;
        for (int i = n - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1); // Random index between 0 and i (inclusive)
            Swap(array, i, j); // Swap elements at indices i and j
            Swap(array2, i, j); // Swap elements at indices i and j
        }
    }

    public static void Initialize()
    {
        
    }

    // Swap method to exchange elements at positions i and j
    private static void Swap<T>(T[] array, int i, int j)
    {
        (array[j], array[i]) = (array[i], array[j]);
    }
}   