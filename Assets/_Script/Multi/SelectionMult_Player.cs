using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class SelectionMult_Player : NetworkBehaviour
{

    public GameObject items;
    public GameObject nez;

    [SyncVar]
    string selected;

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
        this.selected = PlayerPrefs.GetInt("Model").ToString();

        CmdSet(int.Parse(selected));
        PlayerPrefab = this.transform.GetChild(int.Parse(selected)).gameObject;
        items = PlayerPrefab.GetComponent<PlayerMulti>().items;

        for (int i = 0; i < 3; i++)
            this.transform.GetChild(i).gameObject.SetActive(i.ToString() == selected);

        vitesse = PlayerPrefab.GetComponent<PlayerMulti>().vitesse;
        degatSupp = PlayerPrefab.GetComponent<PlayerMulti>().degatSupp;
        BulletEmitt = PlayerPrefab.GetComponent<PlayerMulti>().BulletEmitt;

        nez = PlayerPrefab.GetComponent<PlayerMulti>().nez;
        armePredilection = PlayerPrefab.GetComponent<PlayerMulti>().arme;

        gameObject.GetComponent<Combat_multi>().m_animator = PlayerPrefab.GetComponent<Animator>();
        gameObject.GetComponent<MoveControls>().m_animator = PlayerPrefab.GetComponent<Animator>();

    }

    void Update()
    {
        if (isLocalPlayer)
            foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
                if (player != null && !gameObject.Equals(player))
                {
                    player.GetComponent<SelectionMult_Player>().Set();
                }
    }

    [Command]
    private void CmdSet(int model)
    {
        this.selected = model.ToString();


        PlayerPrefab = this.transform.GetChild(model).gameObject;
        items = PlayerPrefab.GetComponent<PlayerMulti>().items;

        for (int i = 0; i < 3; i++)
            this.transform.GetChild(i).gameObject.SetActive(i == model);

        vitesse = PlayerPrefab.GetComponent<PlayerMulti>().vitesse;
        degatSupp = PlayerPrefab.GetComponent<PlayerMulti>().degatSupp;
        BulletEmitt = PlayerPrefab.GetComponent<PlayerMulti>().BulletEmitt;

        nez = PlayerPrefab.GetComponent<PlayerMulti>().nez;
        armePredilection = PlayerPrefab.GetComponent<PlayerMulti>().arme;


        gameObject.GetComponent<Combat_multi>().m_animator = PlayerPrefab.GetComponent<Animator>();
        gameObject.GetComponent<MoveControls>().m_animator = PlayerPrefab.GetComponent<Animator>();
    }

    private void Set()
    {

        if ( !notsync || this.selected == null)
            return;

        this.notsync = false;

        PlayerPrefab = this.transform.GetChild(int.Parse(this.selected)).gameObject;
        items = PlayerPrefab.GetComponent<PlayerMulti>().items;

        for (int i = 0; i < 3; i++)
            this.transform.GetChild(i).gameObject.SetActive(i.ToString() == this.selected);

        vitesse = PlayerPrefab.GetComponent<PlayerMulti>().vitesse;
        degatSupp = PlayerPrefab.GetComponent<PlayerMulti>().degatSupp;
        BulletEmitt = PlayerPrefab.GetComponent<PlayerMulti>().BulletEmitt;

        nez = PlayerPrefab.GetComponent<PlayerMulti>().nez;
        armePredilection = PlayerPrefab.GetComponent<PlayerMulti>().arme;

        gameObject.GetComponent<WeaponSwitchMulti>().listeItems = new List<GameObject>();
        foreach (Transform item in items.transform)
            gameObject.GetComponent<WeaponSwitchMulti>().listeItems.Add(item.gameObject);


        gameObject.GetComponent<Combat_multi>().m_animator = PlayerPrefab.GetComponent<Animator>();
        gameObject.GetComponent<MoveControls>().m_animator = PlayerPrefab.GetComponent<Animator>();
    }
    public GameObject GetItems
    {
        get { return items; }
        set { items = value; }
    }
}
