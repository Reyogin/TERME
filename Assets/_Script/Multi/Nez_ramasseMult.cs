using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Nez_ramasseMult : NetworkBehaviour
{
    NetworkManager nm;

    public enum ArmeType { Fist, Knife, Sword, Gun }
    // Use this for initialization
    void Start()
    {
        this.nm = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Ramasse(GameObject gOb, Weapon wp)
    {
        if (!isLocalPlayer)
            return;
        ArmeType type = ArmeType.Fist;
        if (wp is Knife_script)
            type = ArmeType.Knife;
        else if (wp is Sword_script)
            type = ArmeType.Sword;
        else if (wp is Gun_script)
            type = ArmeType.Gun;


        CmdRamasse(gOb, type, wp.durabilite);
    }

    [Command]
    private void CmdRamasse(GameObject gOB, ArmeType type, int durabilite)
    {
        ArmeType type2 = ArmeType.Fist;
        Weapon wp = gOB.GetComponent<Weapon>();
        if (wp is Knife_script)
            type2 = ArmeType.Knife;
        else if (wp is Sword_script)
            type2 = ArmeType.Sword;
        else if (wp is Gun_script)
            type2 = ArmeType.Gun;
        int dur2 = wp.durabilite;


        //detruire gob


        Vector3 pos = gameObject.transform.position;
        Vector3 force = gameObject.transform.forward * Random.Range(1, 2f) + Vector3.up * Random.Range(0.5f, 1.5f);
        if (durabilite > 0)
        {
            GameObject obj = null;
            switch (type)
            {
                case ArmeType.Knife:
                    obj = Resources.Load<GameObject>(""); // Fix les chemain d'acces
                    obj = GameObject.Instantiate(obj) as GameObject;
                    obj.AddComponent<Knife_script>(/* a faire cionstructeur avec dura*/);
                    break;
                case ArmeType.Sword:
                    obj = Resources.Load<GameObject>(""); // Fix les chemain d'acces
                    obj = GameObject.Instantiate(obj) as GameObject;
                    obj.AddComponent<Sword_script>(/* a faire cionstructeur avec dura*/);
                    break;
                case ArmeType.Gun:
                    obj = Resources.Load<GameObject>(""); // Fix les chemain d'acces
                    obj = GameObject.Instantiate(obj) as GameObject;
                    obj.AddComponent<Gun_script>(/* a faire cionstructeur avec dura*/);
                    break;
                default:
                    obj = Resources.Load<GameObject>(""); // Fix les chemain d'acces
                    obj = GameObject.Instantiate(obj) as GameObject;

                    obj.AddComponent<Fist_script>(/* a faire cionstructeur avec dura*/);
                    break;
            }
            obj.transform.position = pos;
            obj.GetComponent<Rigidbody>().AddForce(force);
            NetworkServer.Spawn(obj);
        }
        RpcRamasse(type2, dur2);
    }


    [ClientRpc]
    private void RpcRamasse(ArmeType type, int durabilite)
    {
        switch (type)
        {
            case ArmeType.Fist:

                break;
            case ArmeType.Knife:
                break;
            case ArmeType.Sword:
                break;
            case ArmeType.Gun:
                break;
            default:
                break;
        }
    }
}
