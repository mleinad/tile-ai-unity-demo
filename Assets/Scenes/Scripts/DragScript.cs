using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragScript : MonoBehaviour
{
    public TileScript tileScript;
    GameManager gameManager;
    private void Awake()
    {
        gameManager = FindFirstObjectByType(typeof(GameManager)).GetComponent<GameManager>();
    }


    private void OnMouseOver()
    {
        if (tileScript.isConnected) tileScript.hoverLight.enabled = true;
       // Debug.Log("hover");
    }

    private void OnMouseDown()
    {
        if (gameManager.spawnTree)
        {
            
            if(tileScript.isConnected) 
            {
                if (!tileScript.tree.active)
                {
                    tileScript.tree.active = true;

                    gameManager.spawnTree = false;
                }
            }
        }
    }
    private void OnMouseExit()
    {
        tileScript.hoverLight.enabled = false;
     //   Debug.Log("exit");
    }

}
