using UnityEngine;
using System.Collections;

public class OuvertureCaisse : MonoBehaviour
{
    private bool finis;
    public Animator Anim;
    public AudioSource Sond;

    // Use this for initialization
    void Start()
    {
        finis = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "Nez")
        {
            if (finis)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Anim.enabled = true;
                    Sond.Play();
                    finis = false;
                }
            }
        }
    }
}

