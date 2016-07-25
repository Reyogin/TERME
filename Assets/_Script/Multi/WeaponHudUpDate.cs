using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;

public class WeaponHudUpDate : NetworkBehaviour
{

    private List<Transform> listeItems;
    private List<Transform> listehudWImg;
    public GameObject hudW;
    //pour item drag and drop, object contenant toutes les armes , mais de base elles sont desactive sauf le couteau
    public GameObject items;

    private int itemslot;

    // Use this for initialization
    void Start()
    {
        if (!isLocalPlayer)
            return;

        UpdateHUD();
    }

    //fonction qui change le sprite dans l hud des armes
    public void changeImage(Transform gObjectImg, string ImgName)

    {
        //Debug.Log(gObjectImg.name + " avec pour image : " + ImgName);
        
        gObjectImg.FindChild("Image").GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Image/weaponssprites/" + ImgName);
    }

    public void changeDurabilite(Transform gObjectEmplacementn, int dura, int duraMax)
    {
        gObjectEmplacementn.FindChild("Durabilite").GetComponent<Text>().text = dura.ToString() + "/" + duraMax.ToString();

    }
    public void UpdateHUD()
    {
       
        //fait la liste des items
        listeItems = new List<Transform>();
        //liste contenant les gameobject images de l'hud
        listehudWImg = new List<Transform>();
        for (int i = 0; i < 3; i++)
        {
            listeItems.Add(items.transform.GetChild(i));
            listehudWImg.Add(hudW.transform.GetChild(i));
        }
        //index qui sert a checker les armes
        int indexW = 0;
        //indexWM = 3
        int indexWM = listeItems.Count;
        while (indexW < indexWM)
        {
            string name = listeItems[indexW].name;
            changeImage(listehudWImg[indexW], name);
            changeDurabilite(listehudWImg[indexW], listeItems[indexW].GetComponent<Weapon>().durabilite, listeItems[indexW].GetComponent<Weapon>().MaxDurability);
            indexW++;

        }
    }
}


