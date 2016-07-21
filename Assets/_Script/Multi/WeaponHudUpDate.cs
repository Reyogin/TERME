using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WeaponHudUpDate : MonoBehaviour
{

    private List<Transform> listeItems;
    private List<Transform> listehudWImg;
    public GameObject hudW;
    //pour item drag and drop, object contenant toutes les armes , mais de base elles sont desactive sauf le couteau
    public GameObject items;

    // Use this for initialization
    void Start()
    {
        UpdateHUD();
    }

    //fonction qui change le sprite dans l hud des armes
    public void changeImage(Transform gObjectImg, string ImgName)

    {
        Debug.Log("Vient de changer une image");
        //modifie l image
        if (ImgName == "Fist")
            gObjectImg.FindChild("Image").GetComponent<Image>().overrideSprite = (Sprite)Resources.Load("Resources/Image/weapons sprites/" + ImgName);
        else
            gObjectImg.FindChild("Image").GetComponent<Image>().overrideSprite = (Sprite)Resources.Load("Resources/Image/weapons sprites/" + ImgName);
    }

    public void changeDurabilite(Transform gObjectEmplacementn, string dura , string duraMax)
    {
        Debug.Log("Vient de modifie la durabilite");
        gObjectEmplacementn.FindChild("Durabilite").GetComponent<Text>().text = dura + "/" + duraMax;

    }
    // Update is called once per frame
    public void UpdateHUD()
    {

        listeItems = new List<Transform>();
        //fait la liste des items
        foreach (Transform item in items.transform)
        {
            listeItems.Add(item.gameObject.transform);
        }
        //liste contenant les gameobject images de l'hud
        listehudWImg = new List<Transform>();
        //recupere le gameobject image
        foreach (Transform item in hudW.transform)
        {
            listehudWImg.Add(hudW.gameObject.transform.GetChild(0));
        }
        //index qui sert a checker les armes
        int indexW = 0;
        //indexWM = 3
        int indexWM = listeItems.Count;
        while (indexW < indexWM)
        {
            string name = listeItems[indexW].name;
            changeImage(listehudWImg[indexW], name);
            changeDurabilite(listehudWImg[indexW], "10" , "10");
            indexW++;

        }
    }
}

