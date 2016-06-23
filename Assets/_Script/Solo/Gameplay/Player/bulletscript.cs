using UnityEngine;
using System.Collections;

public class bulletscript : MonoBehaviour
{
    public GameObject player;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
        if (other.gameObject.tag == "LightGuard")
        {
            AI_Reboot hp = other.gameObject.GetComponent<AI_Reboot>();
            hp.TakingPunishment(35);
        }
        else
        {
            Spider_AI hp = other.gameObject.GetComponent<Spider_AI>();
            hp.TakingPunishment(35);
        }

        Destroy(this.gameObject);
    }
}
