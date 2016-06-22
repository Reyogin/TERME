using UnityEngine;
using System.Collections;

public class CristalRot : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.Rotate(0, 0, -1.5f);
	}
}
