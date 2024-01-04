using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject tree; // The prefab you want to spawn
    public GameObject cube;
    //public GameObject Sidebar; //access to the isObjectSelected bool
    //private UItest uiTest;#
    public string pivotPointTag = "Pivot";
    List<Transform> pivotPoints = new List<Transform>();
    public TileManager tileManager;

    private void Start()
    {

        UItest.EventMouseButtonDown += OnMouseButton;
        
    }

    private void OnDestroy()
    {
        UItest.EventMouseButtonDown -= OnMouseButton;
       
    }

    public Transform FindNearestPivotPoint(Vector3 predefinedPoint) //looks for neares Pivot points and returns its transforms
    {

        var pivotList = tileManager.GetPivots();


        Transform nearestPivot = pivotList[0]; 
        float closestDistance = Vector3.Distance(predefinedPoint, nearestPivot.position);


        foreach(var pivot in pivotList)
        {
            float distance = Vector3.Distance(predefinedPoint, pivot.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestPivot = pivot;
            }

        }

            return nearestPivot;
    }


    private void OnMouseButton()
    {
        //Debug.Log("mousebtndown");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            bool isObject1Selected = UItest.isObject1Selected;
            bool isObject2Selected = UItest.isObject2Selected;

            Vector3 spawnPosition = hit.point;

            // Use the FindNearestPivotPoint function to find the nearest pivot point to hit.point
            Transform nearestPivotPoint = FindNearestPivotPoint(hit.point);
            Debug.Log("distance: " + Vector3.Distance(nearestPivotPoint.position, hit.point));

            if (nearestPivotPoint != null && Vector3.Distance(nearestPivotPoint.position, hit.point) < 1.7f)
            {
                spawnPosition = nearestPivotPoint.position;
            }
            else
            {
                isObject1Selected = false;
            }

            //Debug.Log("raycast");

            // Access the bool from ScriptWithBool

            // Use the bool value
            if (isObject1Selected == true)
            {
                Instantiate(tree, spawnPosition, Quaternion.identity);
                //Debug.Log("tree");
                

            }

            if (isObject2Selected == true)
            {
                Instantiate(cube, spawnPosition, Quaternion.identity);
                //Debug.Log("cat");
            }



        }


    }

    

}   

