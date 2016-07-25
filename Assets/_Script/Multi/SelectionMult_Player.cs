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
    public float vitesse;
    public float degatSupp;
    public Weapon armePredilection;

    // Use this for initialization
    void Start()
    {
        indexSelect = PlayerPrefs.GetInt("Model");
        PlayerPrefab = this.transform.GetChild(indexSelect).gameObject;
        for (int i = 0; i < 3; i++)
            this.transform.GetChild(i).gameObject.SetActive(i == indexSelect);

        vitesse = PlayerPrefab.GetComponent<PlayerMulti>().vitesse;
        degatSupp = PlayerPrefab.GetComponent<PlayerMulti>().degatSupp;
        BulletEmitt = PlayerPrefab.GetComponent<PlayerMulti>().BulletEmitt;
        armePredilection = ArmedePred(indexSelect);

    }

    public Weapon ArmedePred(int index)
    {
        if (index == 0)
            return new Gun_script();
        else if (index == 1)
            return new Sword_script();
        else
            return new Knife_script();
    }

}
