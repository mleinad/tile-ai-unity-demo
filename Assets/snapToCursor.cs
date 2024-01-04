using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToMouse : MonoBehaviour
{
    private bool isObjectSelected = false;

    void Update()
    {
        if (isObjectSelected)
        {
            // Get the mouse position in world coordinates
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Set the image's position to the mouse position
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
    }

    public void ObjectSelected(bool isSelected)
    {
        isObjectSelected = isSelected;
    }
}

