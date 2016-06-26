using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class Traps_activation : MonoBehaviour
{
    GameObject[] trap_list;
    private float cd = 0;
    private bool trapActive;

    // Use this for initialization
    void Start()
    {
        int i = 0;
        trap_list = new GameObject[transform.childCount];
        foreach (Transform child in transform)
        {
            trap_list[i] = child.gameObject;
            i++;
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
        Debug.Log("1");
        trapActive = true;
        int nb = (int)Random.Range(1, trap_list.Length);
        Debug.Log(nb);
        List<int> number = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        while (nb > 0)
        {
            int i = Random.Range(0, number.Count);
            GameObject trap = trap_list[i];
            Debug.Log(trap.activeInHierarchy);
            if (!trap.activeSelf)
            {
                trap.SetActive(true);
                nb--;
            }
            number.Remove(i);
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
