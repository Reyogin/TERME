using UnityEngine;
using System.Collections;

public class Spike_damage : MonoBehaviour {
    [SerializeField] private int damageReceive;
	// Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Combat otherPl = other.gameObject.GetComponent<Combat>();
            otherPl.TakingPunishment(damageReceive);

        }
    }
}
