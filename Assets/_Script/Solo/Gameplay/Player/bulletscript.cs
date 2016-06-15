using UnityEngine;
using System.Collections;

public class bulletscript : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        //gère la partie joueur
        if (other.tag == "Player" && other.gameObject != player)
        {
            CQCCombat hp = other.GetComponent<CQCCombat>();
            hp.TakingPunishment(35);
        }
        if(other.tag == "Enemy")
        {
            IAHealth hp = other.GetComponent<IAHealth>();
            hp.TakingPunishment(35);
        }
        Destroy(this.gameObject);
    }
}
