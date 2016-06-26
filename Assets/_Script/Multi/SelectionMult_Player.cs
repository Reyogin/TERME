using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

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
            this.selected = -1;
            this.notsync = true;
            return;
        }
        this.notsync = false;
        this.selected = PlayerPrefs.GetInt("Model");

        CmdSet(selected);
        PlayerPrefab = this.transform.GetChild(selected).gameObject;
        items = PlayerPrefab.GetComponent<PlayerMulti>().items;

        gameObject.GetComponent<Combat_multi>().m_animator = PlayerPrefab.GetComponent<Animator>();
        gameObject.GetComponent<MoveControls>().m_animator = PlayerPrefab.GetComponent<Animator>();

        for (int i = 0; i < 3; i++)
            this.transform.GetChild(i).gameObject.SetActive(i == selected);

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
        if (this.selected != -1)
        RpcSet(this.selected);
    }

    [ClientRpc]
    private void RpcSet(int model)
    {
        if (!notsync)
            return;


        this.selected = model;

        PlayerPrefab = this.transform.GetChild(model).gameObject;
        items = PlayerPrefab.GetComponent<PlayerMulti>().items;


        gameObject.GetComponent<Combat_multi>().m_animator = PlayerPrefab.GetComponent<Animator>();

        for (int i = 0; i < 3; i++)
            this.transform.GetChild(i).gameObject.SetActive(i == model);

        vitesse = PlayerPrefab.GetComponent<PlayerMulti>().vitesse;
        degatSupp = PlayerPrefab.GetComponent<PlayerMulti>().degatSupp;
        BulletEmitt = PlayerPrefab.GetComponent<PlayerMulti>().BulletEmitt;

        nez = PlayerPrefab.GetComponent<PlayerMulti>().nez;
        armePredilection = PlayerPrefab.GetComponent<PlayerMulti>().arme;

        gameObject.GetComponent<WeaponSwitchMulti>().listeItems = new List<GameObject>();
        foreach (Transform item in items.transform)
            gameObject.GetComponent<WeaponSwitchMulti>().listeItems.Add(item.gameObject);
        this.notsync = false;
    }
    public GameObject GetItems
    {
        get { return items; }
        set { items = value; }
    }
}
