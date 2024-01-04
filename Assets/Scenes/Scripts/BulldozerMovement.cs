using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BulldozerMovement : MonoBehaviour
{

    public TileManager TileManager;
    public Transform pivot1, pivot2;
    public TileScript currentTile;

    private float lastCallTime = 0f;

    private float lastCallTime2 = 0f;

    public float attackTime = 3f;

    float fuel;

    public bool Movement;

    private bool clicked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (currentTile != null)
        {
            if (currentTile.tree.active)
            {

                Attack();

            }
            else
            {
                if (Time.time - lastCallTime >= 3f)
                {
                    MoveRandom();
                    lastCallTime = Time.time;
                }
           
               currentTile.KillTile();
            }
            
        }
        findCurrentTile();



        //if(Input.GetKey(KeyCode.Space) && !clicked) 
        //{
        //    PathFind();
        //    clicked = true;
        //}
    }

    private void Attack()
    {

        if (currentTile.tree.life > 0)
        {
            currentTile.UnderAttack();

            if (Time.time - lastCallTime2 >= attackTime)
            {

                Debug.Log(gameObject.name + "attacked " + currentTile.index);


                lastCallTime = Time.time;
            }

            return; 
        }
        else
        {
            currentTile.KillTile();
            currentTile.tree.KillTree();
            return;
        }

    }


    void PathFind()
    {
        Graph graph = TileManager.PathFindGraph(currentTile);

        List<int>path = TileManager.PathFindDFS(graph);
    
        //foreach (int i in path)
        //{
        //    Debug.Log("go to: " + i);
        //} 
    }

    void MoveRandom()
    {
        int randomTile = Random.Range(1, currentTile.adjecentTile.Count);

        int searchCount=0;


        while (!currentTile.adjecentTile[randomTile].isAlive || !currentTile.adjecentTile[randomTile].isConnected)
        {
            randomTile = Random.Range(1, currentTile.adjecentTile.Count);
        
            searchCount++;
            if (searchCount == currentTile.adjecentTile.Count)
            {
                break;
            }
        }

        //add rotate bulldozer 
        
        transform.DOMove(currentTile.adjecentTile[randomTile].pivot.transform.position, 2);
    
    }


    void findCurrentTile()
    {
        var currentGrid = TileManager.getGraph();


        float lowest = Vector3.Distance(transform.position, currentGrid[0].transform.position);

        foreach (var t in currentGrid)
        {
           float distance = Vector3.Distance(transform.position, t.pivot.position);
            if(distance < lowest)
            {
                lowest = distance;
                currentTile = t;
            }
        }

       // currentTile.KillTile();
    }

}
