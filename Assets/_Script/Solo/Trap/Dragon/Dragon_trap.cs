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
        if (CD <= 0 && other.gameObject.tag == "Player")
        {
            GUI_HealthPlayer otherPl = other.gameObject.GetComponent<GUI_HealthPlayer>();
            otherPl.TakingPunishment(10f);
            CD = 0.8f;
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
