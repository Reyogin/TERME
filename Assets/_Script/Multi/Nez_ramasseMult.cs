using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Nez_ramasseMult : NetworkBehaviour
{
    NetworkManager nm;
    WeaponSwitchMulti wpSwiMult;

    public enum ArmeType { Fist, Knife, Sword, Gun }
    // Use this for initialization
    void Start()
    {
        this.nm = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        wpSwiMult = gameObject.GetComponent<WeaponSwitchMulti>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Ramasse(GameObject gOb)
    {
        if (!isLocalPlayer)
            return;

        Weapon wp = wpSwiMult.listeArme[wpSwiMult.currentweapon];
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
    private void CmdRamasse(GameObject gOB, ArmeType type, float durabilite)
    {
        WeaponMono wp = gOB.GetComponent<WeaponMono>();
        ArmeType type2 = wp.armetype;
        float dur2 = wp.durability;


        //detruire gob
        NetworkServer.UnSpawn(gOB);
        GameObject.Destroy(gOB);

        Vector3 pos = gameObject.transform.position + Vector3.up * 1;
        if (durabilite > 0)
        {
            GameObject obj = null;
            switch (type)
            {
                case ArmeType.Knife:
                    obj = Resources.Load<GameObject>("_Prefabs/Items/Knife");
                    obj.GetComponent<WeaponMono>().durability = durabilite;
                    obj = GameObject.Instantiate(obj) as GameObject;
                    break;
                case ArmeType.Sword:
                    obj = Resources.Load<GameObject>("_Prefabs/Items/Sword");
                    obj.GetComponent<WeaponMono>().durability = durabilite;
                    obj = GameObject.Instantiate(obj) as GameObject;
                    break;
                case ArmeType.Gun:
                    obj = Resources.Load<GameObject>("_Prefabs/Items/Gun");
                    obj.GetComponent<WeaponMono>().durability = durabilite;
                    obj = GameObject.Instantiate(obj) as GameObject;
                    break;
                default:
                    return;
            }
            obj.transform.position = pos;
            NetworkServer.Spawn(obj);

        }
        RpcRamasse(type2, dur2);
    }


    [ClientRpc]
    private void RpcRamasse(ArmeType type, float durabilite)
    {
        if (!isLocalPlayer)
            return;
        switch (type)
        {
            case ArmeType.Fist:
                wpSwiMult.ChangeWeapon(new Fist_script());
                break;
            case ArmeType.Knife:
                wpSwiMult.ChangeWeapon(new Knife_script(durabilite));
                break;
            case ArmeType.Sword:
                wpSwiMult.ChangeWeapon(new Sword_script(durabilite));
                break;
            case ArmeType.Gun:
                wpSwiMult.ChangeWeapon(new Gun_script(durabilite));
                break;
            default:
                break;
        }
    }
}
