using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Networking;

public class WeaponSwitchMulti : NetworkBehaviour
{


    //debut par defaut a au debut l arme numero 0
    public int currentweapon = 0;
    private Transform playerTransform;
    private List<GameObject> listeItems;

    //max arme debut a zero donc le joueur ici pourra porter 3 armes
    public int maxweapon = 2;
    //var pour access animator controler
    public Animator theAnimator;


    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
        {
            this.playerTransform = GetComponent<Transform>();
            //GameObject items = gameObject.transform.FindChild("Items").gameObject;
            GameObject items = playerTransform.FindChild("Reference").FindChild("Hips").FindChild("Spine").FindChild("Chest").FindChild("RightShoulder").FindChild("RightArm").FindChild("RightForeArm").FindChild("RightHand").FindChild("Items").gameObject;
            listeItems = new List<GameObject>();
            foreach (Transform item in items.transform)
            {
                listeItems.Add(item.gameObject);
            }
            Debug.Log(listeItems.Count);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            // changement d'arme avec la mollette de la souris
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if ((currentweapon + 1) <= maxweapon)
                {
                    currentweapon++;
                }
                else
                {
                    currentweapon = 0;
                }
                SelectWeapon(currentweapon);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if ((currentweapon - 1) >= 0)
                {
                    currentweapon--;
                }
                else
                {
                    currentweapon = maxweapon;
                }
                SelectWeapon(currentweapon);
            }
            if (currentweapon == maxweapon + 1)
            {
                currentweapon = 0;
            }
            if (currentweapon == -1)
            {
                currentweapon = maxweapon;
            }

            //Changement d'arme en pressant la touche 0 ,1 ou 2
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentweapon = 0;
                SelectWeapon(currentweapon);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                currentweapon = 1;
                SelectWeapon(currentweapon);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                currentweapon = 2;
                SelectWeapon(currentweapon);
            }
        }

    }

    public void SelectWeapon(int index)
    {
        if (isLocalPlayer)
        {
            for (int i = 0; i < 3; i++)
            {
                //active la selection arme 
                if (i == index)
                {
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
                    //regarde si l'arme ( gameobject.child) est bien celle voulu a l index, si oui on l active
                    listeItems[i].gameObject.SetActive(true);
                }
                else
                {
                    //sinon on desactive l arme
                    listeItems[i].gameObject.SetActive(false);
                }
            }
        }
    }
}
