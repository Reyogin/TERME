using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Networking;

public class WeaponSwitchMulti : NetworkBehaviour
{


    //debut par defaut a au debut l arme numero 0
    public int currentweapon;
    private Transform playerTransform;
    private List<GameObject> listeItems;

    private Weapon[] listeArme;


    //max arme debut a zero donc le joueur ici pourra porter 3 armes
    public int maxweapon = 2;
    //var pour access animator controler
    public Animator theAnimator;


    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
        {
            currentweapon = 0;
            this.playerTransform = GetComponent<Transform>();
            //GameObject items = gameObject.transform.FindChild("Items").gameObject;
            GameObject items = playerTransform.FindChild("Reference").FindChild("Hips").FindChild("Spine").FindChild("Chest").FindChild("RightShoulder").FindChild("RightArm").FindChild("RightForeArm").FindChild("RightHand").FindChild("Items").gameObject;
            listeArme = new Weapon[3];
            listeItems = new List<GameObject>();
            int index = 0;
            foreach (Transform item in items.transform)
            {
                listeArme[index] = item.GetComponent<Weapon>();
                listeItems.Add(item.gameObject);
                index++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            int newWp = currentweapon;
            // changement d'arme avec la mollette de la souris
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if ((newWp + 1) <= maxweapon)
                {
                    newWp++;
                }
                else
                {
                    newWp = 0;
                }
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if ((newWp - 1) >= 0)
                {
                    newWp--;
                }
                else
                {
                    newWp = maxweapon;
                }
            }
            if (newWp == maxweapon + 1)
            {
                newWp = 0;
            }
            if (newWp == -1)
            {
                newWp = maxweapon;
            }

            //Changement d'arme en pressant la touche 0 ,1 ou 2
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                newWp = 0;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                newWp = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                newWp = 2;
            }
            SelectWeapon(newWp);
        }

    }

    public void SelectWeapon(int index)
    {
        if (!isLocalPlayer || index == currentweapon)
            return;
        //active la selection arme 
        /*
        if (listeItems[i].name == "Fist")
        {
            //animation quand on est a main nue
            theAnimator.SetBool("WeaponIsOn", false);
        }
        else
        {
            theAnimator.SetBool("WeaponIsOn", true);

        }
        */
        listeItems[index].gameObject.SetActive(true);
        listeItems[currentweapon].gameObject.SetActive(false);
        // sync en multi ??
        currentweapon = index;

    }
}
