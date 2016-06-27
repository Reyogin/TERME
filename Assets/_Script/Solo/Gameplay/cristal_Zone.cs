using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class cristal_Zone : MonoBehaviour
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
        if (other.gameObject.transform.parent.gameObject.CompareTag("Player"))
            count++;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.transform.parent.gameObject.CompareTag("Player"))
        {
            if (count <= 1)
            {
                Combat_multi hp = other.gameObject.transform.parent.gameObject.GetComponent<Combat_multi>();
                hp.currentHealth += 5 * Time.deltaTime;
                if (hp.currentHealth >= 100)
                    hp.currentHealth = 100;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.parent.gameObject.CompareTag("Player"))
            count--;
    }
}
