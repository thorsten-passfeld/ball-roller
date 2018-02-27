using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneRestart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Aktuelle Szene wird neu geladen. Praktisch, da sich das Script automatisch nach der aktiven Szene richtet.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
