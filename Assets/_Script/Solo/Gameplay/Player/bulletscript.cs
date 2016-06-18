﻿using UnityEngine;
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

    void OnCollisionEnter(Collision other)
    {
        //gère la partie joueur
        if (other.gameObject.tag == "Player" && other.gameObject != player)
        {
            Combat hp = other.gameObject.GetComponent<Combat>();
            hp.TakingPunishment(35);
        }
        if(other.gameObject.tag == "Enemy")
        {
            IAHealth hp = other.gameObject.GetComponent<IAHealth>();
            hp.TakingPunishment(35);
        }
        Destroy(this.gameObject);
    }
}
