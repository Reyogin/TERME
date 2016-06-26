using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Networking;

public class WeaponSwitchMulti : NetworkBehaviour
{


    //debut par defaut a au debut l arme numero 0
    public int currentweapon;
    public Weapon[] listeArme;

    public int indexOBJ;
    private List<GameObject> listeItems;

    //max arme debut a zero donc le joueur ici pourra porter 3 armes
    public int maxweapon = 2;



    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
        {
            this.indexOBJ = 1;
            currentweapon = 0;
            listeArme = new Weapon[3] { new Knife_script(), new Fist_script(), new Fist_script() };
        }
        GameObject items = gameObject.GetComponent<SelectionMult_Player>().items;
        listeItems = new List<GameObject>();
        foreach (Transform item in items.transform)
            listeItems.Add(item.gameObject);
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
            if (newWp != currentweapon)
            {
                SelectWeapon(newWp);
                currentweapon = newWp;
            }
        }

    }

    public void SelectWeapon(int index)
    {
        if (!isLocalPlayer)
            return;

        CmdActivWeapon(this.indexOBJ, false);

        Weapon wp = listeArme[index];
        if (wp is Fist_script)
            this.indexOBJ = 0;

        if (wp is Knife_script)
            this.indexOBJ = 1;

        if (wp is Sword_script)
            this.indexOBJ = 2;

        if (wp is Gun_script)
            this.indexOBJ = 3;

        CmdActivWeapon(this.indexOBJ, true);
    }

    public void ChangeWeapon(Weapon wp)
    {
        this.listeArme[currentweapon] = wp;
        gameObject.GetComponent<WeaponHudUpDate>().UpdateHUD();
        SelectWeapon(currentweapon);
    }
    [Command]
    private void CmdActivWeapon(int index, bool state)
    {
        RpcActivWeapon(index, state);
    }

    [ClientRpc]
    private void RpcActivWeapon(int index, bool state)
    {
        listeItems[index].SetActive(state);
    }
}
