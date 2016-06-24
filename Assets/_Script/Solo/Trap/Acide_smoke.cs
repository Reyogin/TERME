using UnityEngine;
using System.Collections;

public class Acide_smoke : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void onParticuleCollison(GameObject other)
    {
        if(other.tag == "Player")
        {
            
        }
    }
}
