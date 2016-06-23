﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class cristal_Zone : NetworkBehaviour
{
    int count = 0;

    void Start()
    {

    }

    void Update()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            count++;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (count <= 1)
            {
                Combat hp = other.gameObject.GetComponent<Combat>();
                hp.currentHealth += 5 * Time.deltaTime;
                if (hp.currentHealth >= 100)
                    hp.currentHealth = 100;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            count--;
    }
}
