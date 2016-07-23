using UnityEngine;
using System.Collections;

public class Nez_ramasseArme : MonoBehaviour
{

    private Nez_ramasseMult nRM;

    // Use this for initialization
    void Start()
    {
        this.nRM = transform.parent.parent.GetComponent<Nez_ramasseMult>();

    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {

            //Debug.Log("Nez rencontre bouton : " + gameObject.name);
            if (Input.GetKeyDown(KeyCode.F))
            {
                Weapon wp;
                this.nRM.Ramasse(other.gameObject, wp);
            }


        }
    }

}
