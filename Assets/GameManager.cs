using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    TileManager tileManager;

    public GameObject sun;
    public GameObject moon;

    public bool spawnTree;

    private void Awake()
    {
        spawnTree = false;
    }
    void Start()
    {
        
    }



}
