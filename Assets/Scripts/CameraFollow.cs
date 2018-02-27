using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    private Vector3 offset, currentRotation;
    private float h, v, hSmooth, vSmooth;
    public float speed, maxRotation, smoothness;

	// Use this for initialization
	void Start ()
    {
        offset = transform.position - player.transform.position;
        currentRotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        
        speed = 5f;
        smoothness = 5f;
    }

    //Viel zu frustrierend. Funktioniert alles nicht
    void Update ()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        hSmooth = Mathf.MoveTowardsAngle(h, h * maxRotation, smoothness * Time.deltaTime);
        vSmooth = Mathf.MoveTowardsAngle(v, v * maxRotation, smoothness * Time.deltaTime);
    }
	
	//LateUpdate, um sicher zu gehen, dass der Code nach FixedUpdate ausgeführt wird.
	void LateUpdate ()
    {
        transform.position = player.transform.position + offset;
        transform.rotation = Quaternion.Slerp(Quaternion.Euler(currentRotation), Quaternion.Euler(new Vector3 (vSmooth, hSmooth, hSmooth)),Time.time * speed);

    }
 }

