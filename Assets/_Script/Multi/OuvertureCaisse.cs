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
            //Debug.Log("Nez en vu de caisse");
            if (finis)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //Debug.Log("Essai d ouvrir caisse");
                    Anim.enabled = true;
                    Sond.Play();
                    finis = false;
                }
            }
        }
    }
}

