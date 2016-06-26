using UnityEngine;
using System.Collections;

public class Dragon_trap : MonoBehaviour
{

    public ParticleSystem part;
    private float CD;
    void Start()
    {
        part.enableEmission = false;
        CD = -1f;

    }

    void Update()
    {
        if(CD>0)
        {
            CD -= Time.deltaTime;
        }
    }

    //a mettre dans le collider
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Debug.Log("PLayer enter the  collider");
            part.enableEmission = true;
            part.Play();

        }
    }
    void OnTriggerStay(Collider other)
    {
        //Debug.Log("Player on fire");
        if (/*CD <= 0 && */other.gameObject.tag == "Player")
        {
            Combat otherPl = other.gameObject.GetComponent<Combat>();
            otherPl.currentHealth -= 10 * Time.deltaTime;
            //CD = 0.8f;
            if (otherPl.currentHealth <= 0)
                otherPl.Die();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("PLayer exit the collider");
            part.enableEmission = false;
        }
    }
}
