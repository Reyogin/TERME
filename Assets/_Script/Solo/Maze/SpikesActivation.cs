using UnityEngine;
using System.Collections;

public class SpikesActivation : MonoBehaviour
{
    public GameObject spikes;

    void Start()
    {
        //spikes = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
            spikes.SetActive(true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            spikes.SetActive(false);
        }
    }
}
