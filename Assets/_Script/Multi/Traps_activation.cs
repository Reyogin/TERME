using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class Traps_activation : MonoBehaviour
{
    GameObject[] trap_list;
    private float cd;
    private bool trapActive;

    // Use this for initialization
    void Start()
    {
        cd = 0;
        trap_list = new GameObject[transform.childCount];
        for (int i = 0; i < trap_list.Length; i++)
        {
            trap_list[i] = transform.GetChild(1).gameObject;
            transform.GetChild(1).gameObject.SetActive(false);
        }
        trapActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        cd += Time.deltaTime;

        if (cd >= 10 && !trapActive)
            GameObject.FindGameObjectWithTag("Player");
        Activate();

        if (cd > 40)
            Deactivate();
    }

    void Activate()
    {
        trapActive = true;
        int nb = Random.Range(1, trap_list.Length);
        List<int> number = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        while (nb > 0)
        {
            int i = Random.Range(0, number.Count);
            GameObject trap = trap_list[i];
            trap.SetActive(true);
            number.Remove(i);
            nb--;
        }
    }

    void Deactivate()
    {
        cd = 0;
        foreach (GameObject trap in trap_list)
            trap.SetActive(false);
        trapActive = false;
    }
}
