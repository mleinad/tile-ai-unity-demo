using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    public float growthRate = 0.1f; // Adjust this rate as needed
    public float maxGrowth = 1.0f; // Maximum growth stage

    private float currentGrowth = 0.0f;

    void Update()
    {
        if (currentGrowth < maxGrowth)
        {
            // Gradually increase the plant's scale to simulate growth
            currentGrowth += growthRate * Time.deltaTime;

            // Ensure growth doesn't exceed the maximum
            currentGrowth = Mathf.Min(currentGrowth, maxGrowth);

            // Apply the scale to the plant
            Vector3 newScale = Vector3.one * currentGrowth;
            transform.localScale = newScale;
        }
    }
}
