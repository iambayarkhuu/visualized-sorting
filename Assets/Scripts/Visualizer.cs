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

    void Awake()
    {
        // Make a copy of the fixedDeltaTime, it defaults to 0.02f, but it can be changed in the editor
        // Time.timeScale = 0.01f;
    }
    void Start()
    {
        values = new int[numberOfElements];
        shapes = new GameObject[numberOfElements];

        for (int i = 0; i < numberOfElements; i++)
        {
            values[i] = i + 1;
            shapes[i] = Instantiate(Cylinder, new Vector3(i - 4, 0, 0), Quaternion.identity);
            shapes[i].transform.localScale += new Vector3(0, -0.5f + (i - 1) / 4f, 0);
        }

        StartCoroutine(RunCoroutinesInOrder());

        // Create a Stopwatch instance
        Stopwatch stopwatch = new();

        // Start timing
        stopwatch.Start();

        // Call the method you want to time

        // StartCoroutine(DataHelper.Shuffle(values, shapes, shapes, delay, this));


        // Stop timing
        stopwatch.Stop();

        // UnityEngine.Debug.Log("Time taken: " + numbers);

        // Output the time taken in milliseconds
        UnityEngine.Debug.Log("Time taken: " + stopwatch.ElapsedMilliseconds + " ms");

        // test array order
        // foreach (int element in values)
        // {
        //     int elementIndex = Array.IndexOf(values, element);
        //     UnityEngine.Debug.Log("elementIndex" + elementIndex);
        //     UnityEngine.Debug.Log("element" + element);
        // }

    }

    void Update()
    {

        foreach (GameObject element in shapes)
        {
            UnityEngine.Debug.Log(element.transform.position);
        }

        foreach (int element in values)
        {
            UnityEngine.Debug.Log(element);
        }


    }

    IEnumerator RunCoroutinesInOrder()
    {

        // Shuffle the array
        yield return StartCoroutine(DataHelper.Shuffle(values, shapes, shapes, delay, this));


        // Wait for SecondCoroutine to finish
        yield return StartCoroutine(SortingAlgorithms.BubbleSort(values, (index1, index2) => StartCoroutine(DataHelper.SwapShapes(shapes, index1, index2, delay)), delay));
    }

}
