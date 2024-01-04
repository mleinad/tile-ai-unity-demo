using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeState : MonoBehaviour
{

    public GameObject small_Tree;

    public GameObject medium_Tree;

    public GameObject large_Tree;

    public GameObject dead_Tree;

    public bool active;
    
    public float life;

    int growthStage;

    bool s1, s2, s3 = false;

    private float lastCallTime = 0f;

    private void Awake()
    {

        small_Tree.SetActive(false);
        medium_Tree.SetActive(false);
        large_Tree.SetActive(false);
        dead_Tree.SetActive(false);
    }
    void Start()
    {
        growthStage = 0;

        active = false;

        //KillTree();

        int rand = Random.Range(1, 5);

        if (rand == 3)
        {
            active = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            switch (growthStage)
            {
                case 0:
                    if (!s1)
                    {
                        SetStageOne();
                        life += 5f;
                    }
                    break;
                case 1:
                    if (!s2)
                    {
                        SetStageTwo();
                        life += 10f;
                    }
                    break;
                case 2:
                    if (!s3)
                    {
                        SetStageThree();
                        life += 20f;
                    }
                    break;
            }

            if (Time.time - lastCallTime >= 6f)
            {

                growthStage++;

                if (growthStage >= 2)
                {
                    growthStage = 2;
                }
                lastCallTime = Time.time;
            }
           // Debug.Log(growthStage);

        }
    
    }

    void SetStageOne()
    {
        small_Tree.SetActive(true);
        medium_Tree.SetActive(false);
        large_Tree.SetActive(false);
        dead_Tree.SetActive(false);

        life += Random.Range(35, 55);

        s1 = true;
    }


    void SetStageTwo()
    {

        small_Tree.SetActive(false);
        medium_Tree.SetActive(true);
        large_Tree.SetActive(false);
        dead_Tree.SetActive(false);

        life += Random.Range(80, 100);
    
        s2 = true;
    }

    void SetStageThree()
    {

        small_Tree.SetActive(false);
        medium_Tree.SetActive(false);
        large_Tree.SetActive(true);
        dead_Tree.SetActive(false);

        life += Random.Range(190, 250);

        s3= true;
    }


   public void KillTree()
    {
        small_Tree.SetActive(false);
        medium_Tree.SetActive(false);
        large_Tree.SetActive(false);
        dead_Tree.SetActive(true);

        active = false;
    }
    
}


