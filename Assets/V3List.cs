using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class V3List : MonoBehaviour
{
    public Vector3[] liste;
	// Use this for initialization
	void Start ()
    {
        int i = 0;
        liste = new Vector3[transform.childCount];
        foreach (Transform child in transform)
        {
            liste[i] = child.position;
            i++;
        }
        Debug.Log(liste);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
