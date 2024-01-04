using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;


#region Graph
public class Graph
{

    private Dictionary<int, List<int>> tList = new Dictionary<int, List<int>>();

    public Graph()
    {
        tList = new Dictionary<int, List<int>>();
    }

    public int newNode(int index)
    {
        if (!tList.ContainsKey(index))
        {
            tList.Add(index, new List<int>());
            return 0;
        }
        else return -1;
    }

    public void newConnection(int node, int connection)
    {

        if (!tList[node].Contains(connection))
        {
            tList[node].Add(connection);

        }
    }

    public List<int> DTS(int node)
    {
        List<int> visited = new List<int>();

        DTSrecurssive(node, visited);

        return visited;

    }

    private void DTSrecurssive(int node, List<int> visited)
    {
        visited.Add(node);

           Debug.Log("go to: " + node);

        foreach (int conection in tList[node])
        {
            if (!visited.Contains(conection))
            {
                DTSrecurssive(conection, visited);
            }
        }
    }


    public void showConnections(int node)
    {
        foreach (int conection in tList[node])
        {
            Debug.Log(node + " -> " + conection);
        }
    }
}

#endregion
public class TileManager : MonoBehaviour
{

    private Dictionary<string, List<string>> tList = new Dictionary<string, List<string>>();

    private TileScript[] tileGrid;
    // Start is called before the first frame update

    TileScript motherTree;

    private void Awake()
    {

        
    }

    void Start()
    {
        GenerateGraph();

        AssignMotherTree();
        FindMotherTree();

    }

  
    void Update()
    {
            CheckConnections();
    }

    #region MotherTree Manager
    void FindMotherTree()
    {
        motherTree = tileGrid[0];

        foreach (var tile in tileGrid)
        {
            if (tile.isMotherTree)
            {
                motherTree = tile;
                tile.isConnected = true;
            }
        }
    }

    void GenerateGraph()
    {
        Graph graph = new Graph();

        tileGrid = transform.GetComponentsInChildren<TileScript>();

        //  Debug.Log("graph size: "+ tileGrid.Length);

        int id = 0;


        foreach (var tile in tileGrid)
        {
            if (tile != null)
            {
                if (tile.walkable == true)
                {
                    tile.index = id;
                    graph.newNode(tile.index);

                //   Debug.Log("Tile: " + tile.index);

                    addConnections(graph, tile);
                    id++;
                    // Debug.Log(id);
                }
            }
        }
       
        
        
        
        // int motherTreeIndex = AssignMotherTree();

        //graph.DTS(motherTreeIndex);
       // graph.showConnections(0);
    }

    void addConnections(Graph graph, TileScript tile)
    {
      //  Debug.Log(tile.index + "has " + tile.adjecentTile.Count + " connections");
        foreach (var conTile in tile.adjecentTile)
        {
            // tile.FindAdjecent();
            graph.newConnection(tile.index, conTile.index);

       //     Debug.Log(tile.index + " -> " + conTile.index);
        }
    }

    void CheckConnections()
    {
        // Debug.Log("checking connections");
        if (!motherTree.isMotherTree) throw new Exception("mother tree not found");
        else
        {
            UncheckTiles();
            ConnectRecursive(motherTree.adjecentTile);
        }
        if (!motherTree.isAlive)
        {
            UncheckTiles();
        }
    }

    void ConnectRecursive(List<TileScript> adjecencyList)
    {
        foreach (var adjTile in adjecencyList)
        {
            if (!adjTile.isConnected && adjTile.isAlive)
            {
                adjTile.isConnected = true;
                ConnectRecursive(adjTile.adjecentTile);
            }

        }
    }


    void UncheckTiles()
    {
        foreach (var tile in tileGrid)
        {
            tile.isConnected = false;
        }
    }

    int AssignMotherTree()
    {
        int random = UnityEngine.Random.Range(1, tileGrid.Length);

        tileGrid[random].MakeMotherTree();

        return random;
    }

    #endregion



    #region PathFindind
    public Graph PathFindGraph(TileScript tile)
    {
        Graph pfGraph = new Graph();

        List<int> visited = new List<int>();

        // pfGraph.newNode(tile.index);

        //  Debug.Log("pf starting at " +  tile.index + " adj: " + tile.adjecentTile.Count);

        //visited.Add(tile.index);

        GenerateGraphRecursive(tile, pfGraph, visited);

        return pfGraph;
    }


    private void GenerateGraphRecursive(TileScript tile, Graph pfGraph, List<int> visited)
    {

        //ASK NINO, VERY SUS!!! 

        pfGraph.newNode(tile.index);
        visited.Add(tile.index);
        //  Debug.Log("pf: " + tile.index);

        foreach (TileScript at in tile.adjecentTile)
        {
            if (!visited.Contains(at.index))
            {
                pfGraph.newConnection(tile.index, at.index);

                Debug.Log(tile.index + " -> " + at.index);

                GenerateGraphRecursive(at, pfGraph, visited);

                // visited.Add(at.index);
            }
        }
    }


    public List<int> PathFindDFS(Graph graph)
    {
        List<int> pathByIndex;

        pathByIndex = graph.DTS(motherTree.index);

        return pathByIndex;
    }

    #endregion



    #region graph API


    public int GetAllTiles()
    {
        return tileGrid.Count();
    }



    public List<Transform> GetPivots()
    {
        List<Transform> result = new List<Transform>();
        foreach (var tile in tileGrid)
        {
            result.Add(tile.pivot);
        }
        return result;
    }
    public TileScript[] getGraph()
    {
        return tileGrid;
    }

    #endregion
}
