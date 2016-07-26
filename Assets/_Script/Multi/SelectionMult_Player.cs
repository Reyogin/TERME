using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SelectionMult_Player : NetworkBehaviour
{

    public GameObject items;
    public GameObject nez;

    public int indexSelect;

    public GameObject PlayerPrefab;
    public GameObject BulletEmitt;
    public GameObject Bullet;
    public GameObject HUDWp;
    public float vitesse;
    public float degatSupp;
    public Weapon armePredilection;

    // Use this for initialization
    void Awake()
    {
        indexSelect = PlayerPrefs.GetInt("Model");
        PlayerPrefab = this.transform.GetChild(indexSelect).gameObject;
        items = PlayerPrefab.GetComponent<PlayerMulti>().items;

        for (int i = 0; i < 3; i++)
            this.transform.GetChild(i).gameObject.SetActive(i == indexSelect);

        vitesse = PlayerPrefab.GetComponent<PlayerMulti>().vitesse;
        degatSupp = PlayerPrefab.GetComponent<PlayerMulti>().degatSupp;
        BulletEmitt = PlayerPrefab.GetComponent<PlayerMulti>().BulletEmitt;
        
        nez = PlayerPrefab.GetComponent<PlayerMulti>().nez;
        armePredilection = PlayerPrefab.GetComponent<PlayerMulti>().arme;

            

}
    public GameObject GetItems
    {
        get { return items; }
        set { items = value; }
    }
}
