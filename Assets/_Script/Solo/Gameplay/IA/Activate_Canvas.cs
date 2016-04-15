using UnityEngine;
using System.Collections;

public class Activate_Canvas : MonoBehaviour
{
    private Transform other;
    //private float distance;
    // Use this for initialization
    void Start()
    {
        other = GameObject.FindGameObjectWithTag("Enemy").transform;
        //distance = Vector3.Distance(transform.GetComponentInParent<Transform>().position, player.position);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, other.position);
        Debug.Log("Distance = " + distance);
        if (distance > 5f)
            other.gameObject.GetComponentInChildren<Canvas>().enabled = false;
        else
            other.gameObject.GetComponentInChildren<Canvas>().enabled = true;

    }
}
