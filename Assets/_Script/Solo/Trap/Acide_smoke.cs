using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Acide_smoke : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay (Collider other)
    {
        if (other.transform.parent.gameObject.tag == "Player")
            other.transform.parent.gameObject.GetComponent<Combat_multi>().currentHealth -= 0.1f;
    }
}
