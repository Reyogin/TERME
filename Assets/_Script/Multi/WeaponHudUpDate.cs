using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WeaponHudUpDate : MonoBehaviour
{
    private CQCCombat CQC_script;
    private Transform playerTransform;
    private List<Transform> listeItems;
    private List<Transform> AncieneListeItems;
    private List<Transform> listehudWImg;
    //pour item drag and drop, object contenant toutes les armes , mais de base elles sont desactive sauf le couteau
    public GameObject items;

    // Use this for initialization
    void Start()
    {
        CQC_script = GetComponent<CQCCombat>();//a deactivate si index == 1 => on va faire ca pour activer les combats a distance
        playerTransform = GetComponent<Transform>();
        AncieneListeItems = new List<Transform>();
    }

    //fonction qui change le sprite dans l hud des armes
    public void changeImage(Transform gObjectImg, string ImgName)
    {
        //modifie l image
        gObjectImg.GetChild(0).GetComponent<Image>().overrideSprite = (Sprite)Resources.Load("Resources/Image/weapons sprites/" + ImgName);
    }

    // Update is called once per frame
    void Update()
    {


        listeItems = new List<Transform>();
        //fait la liste des items
        foreach (Transform item in items.transform)
        {
            listeItems.Add(item.gameObject.transform);
        }
        if (AncieneListeItems.Count == 0 || listeItems != AncieneListeItems)
        {
            GameObject hudW = playerTransform.FindChild("Hud weapon").gameObject;
            //liste contenant les images
            listehudWImg = new List<Transform>();
            //recupere le gameobject image
            foreach (Transform item in hudW.transform)
            {
                listehudWImg.Add(hudW.gameObject.transform.GetChild(0));
            }
            //index qui sert a checker les armes
            int indexW = 0;
            int indexWM = listeItems.Count;

            while (indexW < indexWM)
            {
                string name = listeItems[indexW].name;
                changeImage(listehudWImg[indexW], name);
                indexW++;

            }
            if (indexWM < 3)
            {
                for (int i = indexWM; i < 3; i++)
                {
                    changeImage(listehudWImg[i], "Empty");
                }
            }
            AncieneListeItems = listeItems;
        }
    }
}
