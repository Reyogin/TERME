using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;

public class WeaponHudUpDate : NetworkBehaviour
{
    private List<Transform> listehudWImg;
    public GameObject hudW;

    private WeaponSwitchMulti switche;
    //pour item drag and drop, object contenant toutes les armes , mais de base elles sont desactive sauf le couteau
    public GameObject items;

    // Use this for initialization
    void Start()
    {
        if (!isLocalPlayer)
            return;

        hudW = gameObject.GetComponent<SelectionMult_Player>().HUDWp;
        
        items = gameObject.GetComponent<SelectionMult_Player>().items;
        switche = gameObject.GetComponent<WeaponSwitchMulti>();
        UpdateHUD();
    }

    //fonction qui change le sprite dans l hud des armes
    public void changeImage(Transform gObjectImg, Weapon wp)

    {
        //Debug.Log(gObjectImg.name + " avec pour image : " + ImgName);

        gObjectImg.FindChild("Image").GetComponent<Image>().overrideSprite = Resources.Load<Sprite>(wp.imageName);
    }

    public void changeDurabilite(Transform gObjectEmplacementn, float dura, float duraMax)
    {
        gObjectEmplacementn.FindChild("Durabilite").GetComponent<Text>().text = dura.ToString() + "/" + duraMax.ToString();

    }
    public void UpdateHUD()
    {
        //liste contenant les gameobject images de l'hud
        listehudWImg = new List<Transform>();
        for (int i = 0; i < 3; i++)
            listehudWImg.Add(hudW.transform.GetChild(i));
        

        Weapon[] listewp = switche.listeArme;

        for (int i = 0; i < 3; i++)
        {
            changeImage(listehudWImg[i], listewp[i]);
            changeDurabilite(listehudWImg[i], listewp[i].durabilite, listewp[i].MaxDurability);
        }

    }
}


