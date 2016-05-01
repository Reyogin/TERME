using UnityEngine;
using System.Collections;

public class Enigme : MonoBehaviour {

    public GameObject PorteDerobe;
    public AudioSource Sond;
    public Animator BouttonPlay;
    public GameObject PiegeMortelle;
    private bool finis;


	// Use this for initialization
	void Start () {
        finis = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Nez")
        {
            //Debug.Log("Nez rencontre bouton : " + gameObject.name);
            if(Input.GetKeyDown(KeyCode.E) && finis == true && gameObject.name == "win")
            {
                //Debug.Log("Activation boutton");
                BouttonPlay.enabled = true;
                Sond.Play();
                Destroy(PorteDerobe);               
                finis = false;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                //Debug.Log("Mauvais activation boutton");
                BouttonPlay.enabled = true;
                PiegeMortelle.SetActive(true);

            
            }

        }
    }
}
