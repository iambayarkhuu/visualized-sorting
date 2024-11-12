using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Diagnostics;

public class Visualizer : MonoBehaviour
{
    int[] values;
    public int numberOfElements = 10;
    public float delay = 0.5f; // Delay between swaps for visualization
    private GameObject[] shapes;
    public GameObject Cylinder;
    public List<GameObject> gameObjects = new();
    // Start is called before the first frame update
    private float fixedDeltaTime;

    void Awake()
    {
        // Make a copy of the fixedDeltaTime, it defaults to 0.02f, but it can be changed in the editor
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }
    void Start()
    {
        Time.fixedDeltaTime = 0.01f;
        values = new int[numberOfElements];
        shapes = new GameObject[numberOfElements];

        for (int i = 0; i < numberOfElements; i++)
        {
            values[i] = i+1;
            shapes[i] = Instantiate(Cylinder, new Vector3(i - 4, 0, 0), Quaternion.identity);
            shapes[i].transform.localScale += new Vector3(0, -0.5f + (i - 1) / 2f, 0);
        }



        // Shuffle the array
        DataHelper.Shuffle(values, shapes);

        // test array order
        // foreach (int element in numbers)
        // {
        //     int elementIndex = Array.IndexOf(numbers, element);
        //     UnityEngine.Debug.Log("elementIndex" + elementIndex);
        //     UnityEngine.Debug.Log("element" + element);
        // }


    }

    // Update is called once per frame
    void Update()
    {


        // Create a Stopwatch instance
        Stopwatch stopwatch = new();

        // Start timing
        stopwatch.Start();

        // Call the method you want to time


        BubbleSort(values, numberOfElements);

        // Stop timing
        stopwatch.Stop();

        // UnityEngine.Debug.Log("Time taken: " + numbers);

        // Output the time taken in milliseconds
        UnityEngine.Debug.Log("Time taken: " + stopwatch.ElapsedMilliseconds + " ms");
    }



    


    // An optimized version of Bubble Sort
    static void BubbleSort(int[] arr, int n)
    {
        int i, j, temp;
        bool swapped;
        for (i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {

                    // Swap arr[j] and arr[j+1]
                    temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
            }

            // If no two elements were
            // swapped by inner loop, then break
            if (swapped == false)
                break;
        }
    }
}
