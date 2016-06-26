using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SelectionMult_Player : NetworkBehaviour
{

    public GameObject items;
    public GameObject nez;
    
    int selected;

    public GameObject PlayerPrefab;
    public GameObject BulletEmitt;
    public GameObject Bullet;
    public GameObject HUDWp;
    public float vitesse;
    public float degatSupp;
    public Weapon armePredilection;
    bool notsync;

    // Use this for initialization
    void Start()
    {
        if (!isLocalPlayer)
        {
            this.notsync = true;
            return;
        }
        this.notsync = false;
        int indexSelect = PlayerPrefs.GetInt("Model");

        CmdSet(indexSelect);
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

    void Update()
    {
        if (notsync && !isServer)
            CmdAsk();
    }
    [Command]
    private void CmdSet(int model)
    {
        this.selected = model;


        PlayerPrefab = this.transform.GetChild(model).gameObject;
        items = PlayerPrefab.GetComponent<PlayerMulti>().items;

        for (int i = 0; i < 3; i++)
            this.transform.GetChild(i).gameObject.SetActive(i == model);

        vitesse = PlayerPrefab.GetComponent<PlayerMulti>().vitesse;
        degatSupp = PlayerPrefab.GetComponent<PlayerMulti>().degatSupp;
        BulletEmitt = PlayerPrefab.GetComponent<PlayerMulti>().BulletEmitt;

        nez = PlayerPrefab.GetComponent<PlayerMulti>().nez;
        armePredilection = PlayerPrefab.GetComponent<PlayerMulti>().arme;

    }

    [Command]
    private void CmdAsk()
    {
        RpcSet(this.selected);
    }

    [ClientRpc]
    private void RpcSet(int model)
    {
        if (!notsync)
            return;

        this.notsync = false;

        this.selected = model;

        PlayerPrefab = this.transform.GetChild(model).gameObject;
        items = PlayerPrefab.GetComponent<PlayerMulti>().items;

        for (int i = 0; i < 3; i++)
            this.transform.GetChild(i).gameObject.SetActive(i == model);

        vitesse = PlayerPrefab.GetComponent<PlayerMulti>().vitesse;
        degatSupp = PlayerPrefab.GetComponent<PlayerMulti>().degatSupp;
        BulletEmitt = PlayerPrefab.GetComponent<PlayerMulti>().BulletEmitt;

        nez = PlayerPrefab.GetComponent<PlayerMulti>().nez;
        armePredilection = PlayerPrefab.GetComponent<PlayerMulti>().arme;

        if (!isLocalPlayer)
            PlayerPrefab.transform.GetChild(0).gameObject.SetActive(false);

    }
    public GameObject GetItems
    {
        get { return items; }
        set { items = value; }
    }
}
