using UnityEngine;
using System.Collections;

public class Spikedamage : MonoBehaviour {
    [SerializeField] private int damageReceive;
	// Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GUI_HealthPlayer otherPl = other.gameObject.GetComponent<GUI_HealthPlayer>();
            otherPl.TakingPunishment(damageReceive);

        }
    }
}
