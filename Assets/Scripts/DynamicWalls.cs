using UnityEngine;
using System.Collections;

public class DynamicWalls : MonoBehaviour {

    public GameObject wallPrefab;
    private GameObject myWallPrefab;
    private int creationCounter;
    public float height;

    // Use this for initialization
    void Start()
    {
        creationCounter = 1;

        for (int i = 0; i < 4; i++)
        {
            switch (creationCounter)
            {
                case 1:
                    wallPrefab.transform.position = new Vector3(transform.position.x, transform.position.y + transform.localScale.y / 2, transform.position.z + transform.localScale.z / 2 - 0.125f);
                    wallPrefab.transform.localScale = new Vector3(transform.localScale.x, height, 0.25f);

                    myWallPrefab = Instantiate(wallPrefab);
                    myWallPrefab.transform.SetParent(transform);
                    break;

                case 2:
                    wallPrefab.transform.position = new Vector3(transform.position.x, transform.position.y + transform.localScale.y / 2, transform.position.z - transform.localScale.z / 2 + 0.125f);
                    wallPrefab.transform.localScale = new Vector3(transform.localScale.x, height, 0.25f);

                    myWallPrefab = Instantiate(wallPrefab);
                    myWallPrefab.transform.SetParent(transform);
                    break;

                case 3:
                    wallPrefab.transform.position = new Vector3(transform.position.x + transform.localScale.x / 2 - 0.125f, transform.position.y + transform.localScale.y / 2, transform.position.z);
                    wallPrefab.transform.Rotate(new Vector3(0, -90, 0));
                    wallPrefab.transform.localScale = new Vector3(transform.localScale.z, height, 0.25f);

                    myWallPrefab = Instantiate(wallPrefab);
                    myWallPrefab.transform.SetParent(transform);
                    wallPrefab.transform.Rotate(new Vector3(0, 90, 0));
                    break;

                case 4:
                    wallPrefab.transform.position = new Vector3(transform.position.x - transform.localScale.x / 2 + 0.125f, transform.position.y + transform.localScale.y / 2, transform.position.z);
                    wallPrefab.transform.Rotate(new Vector3(0, 90, 0));
                    wallPrefab.transform.localScale = new Vector3(transform.localScale.z, height, 0.25f);

                    myWallPrefab = Instantiate(wallPrefab);
                    myWallPrefab.transform.SetParent(transform);
                    wallPrefab.transform.Rotate(new Vector3(0, -90, 0));
                    break;

            }
            creationCounter++;
        }
        
    }
}