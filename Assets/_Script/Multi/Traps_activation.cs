using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Traps_activation : NetworkBehaviour
{
    GameObject[] trap_list;
    private float cd_activation = 0;
    private float activate_cd = 0;
    private bool youarenotprepared;
    GameObject[] enabledtraps;

    // Use this for initialization
    void Start ()
    {
        int i = 0;
        trap_list = new GameObject[transform.childCount];
	    foreach (Transform child in transform)
        {
            trap_list[i] = child.gameObject;
            i++;
        }
        youarenotprepared = cd_activation >= 30;
    }

    // Update is called once per frame
    void Update ()
    {
        Debug.Log(cd_activation);
        Debug.Log(activate_cd);
        cd_activation += Time.deltaTime;
        youarenotprepared = cd_activation >= 10;
        YouJustActivatedMyTrapCard(youarenotprepared);
	}

    void YouJustActivatedMyTrapCard (bool cd)
    {
        if (cd)
            Activate();
    }

    void Activate()
    {
        int i = 0;
        activate_cd += Time.deltaTime;
        int nb = (int)Random.Range(1, trap_list.Length);
        enabledtraps = new GameObject[nb];
        while (nb > 0)
        {
            GameObject trap = trap_list[(int)Random.Range(0, trap_list.Length - 1)];
            if (trap.activeSelf == false)
            {
                enabledtraps[i] = trap;
                trap.SetActive(true);
                i++;
                nb--;
            }
        }
        if (activate_cd > 30)
            Deactivate();
    }

    void Deactivate()
    {
        int i = 0;
        activate_cd = 0;
        while (i < enabledtraps.Length)
        {
            enabledtraps[i].SetActive(false);
            i++;
        }
    }
}
