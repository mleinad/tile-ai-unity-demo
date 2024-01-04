using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIcontroller : MonoBehaviour
{

    public GameManager manager;
    public Button seedButton;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        seedButton = root.Q<Button>("seedsButton");

        seedButton.clicked += SeedsButtonPressed;

    }



   void SeedsButtonPressed()
   {
        manager.spawnTree = true;
        Debug.Log("pressed");
   }
}
