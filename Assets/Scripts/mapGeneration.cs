using UnityEngine;
using System.Collections;

public class mapGeneration : MonoBehaviour {

    public GameObject platformPrefab;
    [HideInInspector]
    public GameObject previousPlatform;
    private GameObject player;
    [HideInInspector]
    public bool isFirstPlatform, isLastPlatform;
    public int platformsToGenerate;


    void Awake ()
    {
        player = GameObject.Find("Player");
        isFirstPlatform = true;
        isLastPlatform = false;

        generateFirstPlatform();

        generateMap(platformPrefab);
    }

    void generateMap(GameObject platformPrefab)
    {
        isFirstPlatform = false;
        isLastPlatform = false;

        //Generating all the platforms between the first and the last one
        for (int i = 0; i <= platformsToGenerate-3; i++)
        {
            generatePlatform(platformPrefab);
        }

        //Generating the last platform
        isLastPlatform = true;
        generatePlatform(platformPrefab);
    }

    void generateFirstPlatform()
    {
        platformPrefab.transform.localScale = new Vector3(player.transform.localScale.x + 2 + Random.Range(5f, 20f), player.transform.localScale.y + 2 + Random.Range(1f, 5f), player.transform.localScale.z + 2 + Random.Range(5f, 20f));
        platformPrefab.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - player.transform.localScale.y - platformPrefab.transform.localScale.y/2.35f, player.transform.position.z);
        previousPlatform = Instantiate(platformPrefab);
    }

    void generatePlatform (GameObject platformPrefab)
    {
        platformPrefab.transform.localScale = new Vector3(Random.Range(5f, 20f), previousPlatform.transform.localScale.y, Random.Range(1f, 20f));
        platformPrefab.transform.position = new Vector3(previousPlatform.transform.position.x, previousPlatform.transform.position.y, previousPlatform.transform.position.z + previousPlatform.transform.localScale.z / 2 + platformPrefab.transform.localScale.z / 2);
        previousPlatform = Instantiate(platformPrefab);
    }
}