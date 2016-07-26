using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class collect : MonoBehaviour
{


    public GameObject sword;
    public Text win;
    private bool finis;


    // Use this for initialization
    void Start()
    {
        finis = true;
        win.text = "";
    }


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Nez")
        {

            if (Input.GetKeyDown(KeyCode.E))
            {

                Destroy(sword);
                finis = false;
                //win.gameObject.SetActive(true);
                win.text = "Congratulations! You've collected Cless' mastersword. Now let's get out of this creepy house...";
                if (Input.GetKeyDown(KeyCode.Space))
                    win.gameObject.SetActive(false);


            }
        }
    }
    /*void FixedUpdate()
    {
        transform.Rotate(0, 1.5f, 0);
    }*/
}
