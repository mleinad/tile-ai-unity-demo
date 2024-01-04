using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileScript : MonoBehaviour
{

    public List <TileScript> adjecentTile;
    public int index;
    Transform colliders;
    public bool walkable = true;
    public Light hoverLight;
    public Light connectionLight;
    public Transform pivot;

    public bool isAlive;
    public bool isMotherTree = false;
    public bool isConnected;




    GameObject motherTree;

    public TreeState tree;

    float resistance;
    private void Awake()
    {
       
       

        colliders = transform.Find("Colliders");
        pivot = transform.Find("Pivot");
        isMotherTree = false;
        motherTree = transform.Find("mother_tree").gameObject;
        motherTree.SetActive(false);
    
    
    
    }
    // Start is called before the first frame update
    void Start()
    {
       
        isAlive = true;
        isConnected = false;

        FindAdjecent();
    }
    public void FindAdjecent()
    {
        colliders.gameObject.SetActive(true);

      //  Debug.Log("find adjecent");

        foreach(Collider col in colliders.GetComponentsInChildren<Collider>()) 
        {
            // Check if Collider is colliding with Collideres of another tile
            var overlappedColliders = Physics.OverlapBox(col.transform.position, Vector3.one * 0.5f, Quaternion.identity, 1 << 7);
            for(int i = 0; i < overlappedColliders.Length; i++)
            {
                if (overlappedColliders[i] == col)
                    continue;

                var tileScript = overlappedColliders[i].transform.parent.parent.GetComponent<TileScript>();
                if (tileScript != null)
                {
                    adjecentTile.Add(tileScript);
              //      Debug.Log("Current tile: " + index + " adjecent to: " + adjecentTile.Count);
                }
            }

            
        }

        //colliders.gameObject.SetActive(false);

    }


    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            SwitchTileLive();
        }
        else
        {
            SwitchTileDead();
        }

        if(isConnected)
        {
            Connect();
        }
        else
        {
            Disconnect();
        }

    }


    public void KillTile()
    {
        isAlive = false;
    }

    public void UnderAttack()
    {
        connectionLight.enabled = true;
        connectionLight.color = Color.red;
    }

    void SwitchTileDead()
    {
        transform.Find("DeadTile").gameObject.SetActive(true);
        transform.Find("LiveTile").gameObject.SetActive(false);
        connectionLight.enabled = false;
       // isMotherTree = false;
    }
    void SwitchTileLive()
    {
        transform.Find("DeadTile").gameObject.SetActive(false);
        transform.Find("LiveTile").gameObject.SetActive(true);
       // isConnected = true;
    }

    void Connect()
    {
        
        if(isAlive) connectionLight.enabled = true;
        
        isConnected = true;
    }

    void Disconnect()
    {
        connectionLight.enabled = false;
        isConnected = false;
    }


    public void MakeMotherTree()
    {
        isMotherTree = true;

        connectionLight.intensity = 200;
    
            motherTree.SetActive(true);
    
    }

    
}
