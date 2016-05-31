using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    private float speed;
	// Use this for initialization
	void Start ()
    {
        speed = 10f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
	}
}
