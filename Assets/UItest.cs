using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UItest : MonoBehaviour
{
    public GameObject tree;
    public GameObject cat;

    public static bool isObject1Selected = false;
    public static bool isObject2Selected = false;

    private Vector3 originalPositionObj1;
    private Vector3 originalPositionObj2;
    public static Action EventMouseButtonDown = delegate { };


    public void test()
    {
        Debug.Log("Button pressed");
    }

    private void Start()
    {
        originalPositionObj1 = tree.transform.position;
        originalPositionObj2 = cat.transform.position;
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        if (isObject1Selected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                EventMouseButtonDown();
                isObject1Selected = false;
            }

            tree.transform.position = mousePosition;
        }
        else if (isObject2Selected)  // Use "else if" for exclusive execution
        {
            if (Input.GetMouseButtonDown(0))
            {
                EventMouseButtonDown();
                isObject2Selected = false;
            }

            cat.transform.position = mousePosition;
        }
        else
        {
            // Snap back to the original location
            tree.transform.position = originalPositionObj1;
            cat.transform.position = originalPositionObj2;
        }
    }

    public void Object1Selected(bool isSelected)
    {
        isObject1Selected = isSelected;
    }

    public void Object2Selected(bool isSelected)
    {
        isObject2Selected = isSelected;
    }
}

