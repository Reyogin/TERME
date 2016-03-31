﻿using UnityEngine;
using System.Collections;

public class CrosshairsBehaviour : MonoBehaviour
{
    Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            anim.SetTrigger("Shoot");
    }
}
