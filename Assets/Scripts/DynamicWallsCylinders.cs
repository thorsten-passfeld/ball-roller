using UnityEngine;
using System.Collections;

public class DynamicWallsCylinders : MonoBehaviour {

    public GameObject wallPrefab;
    private GameObject myWallPrefab;
    private bool isFirstPlatform, isLastPlatform;
    private GameObject SceneControllerObject;
    private GameObject previousPlatform;
    private int creationCounter;
    public float height;

   void Awake ()
    {
        SceneControllerObject = GameObject.Find("SceneController");
        isLastPlatform = SceneControllerObject.GetComponent<mapGeneration>().isLastPlatform;
        isFirstPlatform = SceneControllerObject.GetComponent<mapGeneration>().isFirstPlatform;
        previousPlatform = SceneControllerObject.GetComponent<mapGeneration>().previousPlatform;
    }

    // Use this for initialization
    void Start()
    {
        creationCounter = 1;
            
            //First platform
            if (isFirstPlatform)
            {
                generateWalls(1);
            }

            //Platforms between the first and the last one
            else if (!isFirstPlatform && !isLastPlatform)
            {
                generateWalls(2);
            }

            //Last platform
            else if (isLastPlatform)
            {
                generateWalls(3);
            }
    }
            


    public void generateWalls (int generationNumber)
    {
        switch (generationNumber)
        {
            case 1:
                generateWallsSouthEastWest();
                break;

            case 2:
                generateWallsEastWest();
                //Generate walls on the previous platform
                if (previousPlatform.transform.localScale.x > transform.localScale.x)
                {
                    generateWallsNorthAddition(previousPlatform);
                }
                else if (previousPlatform.transform.localScale.x < transform.localScale.x)
                {
                    generateWallsSouthAddition(previousPlatform);
                }
                break;

            case 3:
                generateWallsNorthEastWest();
                break;
        }
    }

    //May never be used.
    public void generateWallsFully ()
    {
        creationCounter = 1;

        for (int i = 0; i < 4; i++)
        {
            switch (creationCounter)
            {
                case 1:
                    wallPrefab.transform.position = new Vector3(transform.position.x, transform.position.y + transform.localScale.y / 2, transform.position.z + transform.localScale.z / 2 - 0.125f);
                    wallPrefab.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                    wallPrefab.transform.localScale = new Vector3(height, transform.localScale.x / 2, height);

                    myWallPrefab = Instantiate(wallPrefab);
                    myWallPrefab.transform.SetParent(transform);
                    break;

                case 2:
                    wallPrefab.transform.position = new Vector3(transform.position.x, transform.position.y + transform.localScale.y / 2, transform.position.z - transform.localScale.z / 2 + 0.125f);
                    wallPrefab.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
                    wallPrefab.transform.localScale = new Vector3(height, transform.localScale.x / 2, height);

                    myWallPrefab = Instantiate(wallPrefab);
                    myWallPrefab.transform.SetParent(transform);
                    break;

                case 3:
                    wallPrefab.transform.position = new Vector3(transform.position.x + transform.localScale.x / 2 - 0.125f, transform.position.y + transform.localScale.y / 2, transform.position.z);
                    wallPrefab.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
                    wallPrefab.transform.localScale = new Vector3(height, transform.localScale.z / 2, height);

                    myWallPrefab = Instantiate(wallPrefab);
                    myWallPrefab.transform.SetParent(transform);

                    break;

                case 4:
                    wallPrefab.transform.position = new Vector3(transform.position.x - transform.localScale.x / 2 + 0.125f, transform.position.y + transform.localScale.y / 2, transform.position.z);
                    wallPrefab.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
                    wallPrefab.transform.localScale = new Vector3(height, transform.localScale.z / 2, height);

                    myWallPrefab = Instantiate(wallPrefab);
                    myWallPrefab.transform.SetParent(transform);

                    break;

            }
            creationCounter++;
        }
    }

    public void generateWallsSouthEastWest ()
    {
        creationCounter = 1;
        for (int i = 0; i < 3; i++)
        {
            switch (creationCounter)
            {
                case 1:
                    wallPrefab.transform.position = new Vector3(transform.position.x, transform.position.y + transform.localScale.y / 2, transform.position.z - transform.localScale.z / 2 + 0.125f);
                    wallPrefab.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
                    wallPrefab.transform.localScale = new Vector3(height, transform.localScale.x / 2, height);

                    myWallPrefab = Instantiate(wallPrefab);
                    myWallPrefab.transform.SetParent(transform);
                    break;

                case 2:
                    wallPrefab.transform.position = new Vector3(transform.position.x + transform.localScale.x / 2 - 0.125f, transform.position.y + transform.localScale.y / 2, transform.position.z);
                    wallPrefab.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
                    wallPrefab.transform.localScale = new Vector3(height, transform.localScale.z / 2, height);

                    myWallPrefab = Instantiate(wallPrefab);
                    myWallPrefab.transform.SetParent(transform);

                    break;

                case 3:
                    wallPrefab.transform.position = new Vector3(transform.position.x - transform.localScale.x / 2 + 0.125f, transform.position.y + transform.localScale.y / 2, transform.position.z);
                    wallPrefab.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
                    wallPrefab.transform.localScale = new Vector3(height, transform.localScale.z / 2, height);

                    myWallPrefab = Instantiate(wallPrefab);
                    myWallPrefab.transform.SetParent(transform);

                    break;

            }
            creationCounter++;
        }
    }

    public void generateWallsEastWest ()
    {
        creationCounter = 1;
        for (int i = 0; i < 2; i++)
        {
            switch (creationCounter)
            {
                case 1:
                    wallPrefab.transform.position = new Vector3(transform.position.x + transform.localScale.x / 2 - 0.125f, transform.position.y + transform.localScale.y / 2, transform.position.z);
                    wallPrefab.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
                    wallPrefab.transform.localScale = new Vector3(height, transform.localScale.z / 2, height);

                    myWallPrefab = Instantiate(wallPrefab);
                    myWallPrefab.transform.SetParent(transform);

                    break;

                case 2:
                    wallPrefab.transform.position = new Vector3(transform.position.x - transform.localScale.x / 2 + 0.125f, transform.position.y + transform.localScale.y / 2, transform.position.z);
                    wallPrefab.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
                    wallPrefab.transform.localScale = new Vector3(height, transform.localScale.z / 2, height);

                    myWallPrefab = Instantiate(wallPrefab);
                    myWallPrefab.transform.SetParent(transform);

                    break;

            }
            creationCounter++;
        }
    }

    public void generateWallsNorthEastWest()
    {
        creationCounter = 1;

        for (int i = 0; i < 3; i++)
        {
            switch (creationCounter)
            {
                case 1:
                    wallPrefab.transform.position = new Vector3(transform.position.x, transform.position.y + transform.localScale.y / 2, transform.position.z + transform.localScale.z / 2 - 0.125f);
                    wallPrefab.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                    wallPrefab.transform.localScale = new Vector3(height, transform.localScale.x / 2, height);

                    myWallPrefab = Instantiate(wallPrefab);
                    myWallPrefab.transform.SetParent(transform);
                    break;

                case 2:
                    wallPrefab.transform.position = new Vector3(transform.position.x + transform.localScale.x / 2 - 0.125f, transform.position.y + transform.localScale.y / 2, transform.position.z);
                    wallPrefab.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
                    wallPrefab.transform.localScale = new Vector3(height, transform.localScale.z / 2, height);

                    myWallPrefab = Instantiate(wallPrefab);
                    myWallPrefab.transform.SetParent(transform);

                    break;

                case 3:
                    wallPrefab.transform.position = new Vector3(transform.position.x - transform.localScale.x / 2 + 0.125f, transform.position.y + transform.localScale.y / 2, transform.position.z);
                    wallPrefab.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
                    wallPrefab.transform.localScale = new Vector3(height, transform.localScale.z / 2, height);

                    myWallPrefab = Instantiate(wallPrefab);
                    myWallPrefab.transform.SetParent(transform);

                    break;

            }
            creationCounter++;
        }
    }
    //Sehr unfertig
    public void generateWallsNorthAddition(GameObject previousPlatform)
    {
        creationCounter = 1;
        for (int i = 0; i < 2; i++)
        {
            switch (creationCounter)
            {
                case 1:
                    wallPrefab.transform.position = new Vector3(previousPlatform.transform.position.x - previousPlatform.transform.localScale.x * 3/8, previousPlatform.transform.position.y + previousPlatform.transform.localScale.y / 2, previousPlatform.transform.position.z + previousPlatform.transform.localScale.z / 2 - 0.125f);
                    wallPrefab.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                    wallPrefab.transform.localScale = new Vector3(height, previousPlatform.transform.localScale.x / (8*2.5f), height);

                    myWallPrefab = Instantiate(wallPrefab);
                    myWallPrefab.transform.SetParent(transform);

                    break;

                case 2:
                    wallPrefab.transform.position = new Vector3(previousPlatform.transform.position.x + previousPlatform.transform.localScale.x * 3/8, previousPlatform.transform.position.y + previousPlatform.transform.localScale.y / 2, previousPlatform.transform.position.z + previousPlatform.transform.localScale.z / 2 - 0.125f);
                    wallPrefab.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                    wallPrefab.transform.localScale = new Vector3(height, previousPlatform.transform.localScale.x / 8, height);

                    myWallPrefab = Instantiate(wallPrefab);
                    myWallPrefab.transform.SetParent(transform);

                    break;

            }
            creationCounter++;
        }
    }
    //Sehr unfertig
    public void generateWallsSouthAddition(GameObject previousPlatform)
    {
        creationCounter = 1;
        for (int i = 0; i < 2; i++)
        {
            switch (creationCounter)
            {
                case 1:
                    wallPrefab.transform.position = new Vector3(transform.position.x - transform.position.x / 4, transform.position.y + transform.localScale.y / 2, transform.position.z - transform.localScale.z / 2 - 0.125f);
                    wallPrefab.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                    wallPrefab.transform.localScale = new Vector3(height, previousPlatform.transform.localScale.x / 2, height);

                    myWallPrefab = Instantiate(wallPrefab);
                    myWallPrefab.transform.SetParent(transform);

                    break;

                case 2:
                    wallPrefab.transform.position = new Vector3(previousPlatform.transform.position.x + previousPlatform.transform.position.x / 4, previousPlatform.transform.position.y + previousPlatform.transform.localScale.y / 2, previousPlatform.transform.position.z + previousPlatform.transform.localScale.z / 2 - 0.125f);
                    wallPrefab.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                    wallPrefab.transform.localScale = new Vector3(height, previousPlatform.transform.localScale.x / 2, height);

                    myWallPrefab = Instantiate(wallPrefab);
                    myWallPrefab.transform.SetParent(transform);

                    break;

            }
            creationCounter++;
        }
    }

}