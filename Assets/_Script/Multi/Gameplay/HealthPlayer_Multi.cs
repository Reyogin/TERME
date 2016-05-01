﻿using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class HealthPlayer_Multi : NetworkBehaviour
{
    /*
    private PlayerClass pc;
    //public int startingHealth = 100;
    public float currentHealth;
    public Slider healthSlider;
    public Image m_fillImage;
    public Color m_fullHealthColor = Color.green;
    public Color m_ZeroHealthColor = Color.red;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    MoveControls movecontrol;
    CameraController cameracontrol;
    bool isDead;
    bool isDamaged;

    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
        {
            pc = GetComponent<PlayerClass>();
            pc.getmaxHealth = 100;
            pc.currentHealth = pc.getmaxHealth;
            movecontrol = GetComponent<MoveControls>();
            cameracontrol = GetComponent<CameraController>();

            SetHealthUI();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            isDamaged = Input.GetKeyDown(KeyCode.H);

            if (isDamaged && !isDead)
            {
                damageImage.color = flashColor;
                TakeDamage(10);
            }
            else
                damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);

            isDamaged = false;
        }

    }

    public void TakeDamage(int amount)
    {
        if (isLocalPlayer)
        {
            isDamaged = true;

            if (Input.GetKeyDown(KeyCode.H))
            {
                currentHealth -= amount;
                SetHealthUI();
            }

            if (currentHealth <= 0 && !isDead)
            {
                isDead = true;
                movecontrol.enabled = false;
                cameracontrol.enabled = false;
            }
        }

    }
        public void SetHealthUI()
    {
        // Set the slider's value appropriately.
        healthSlider.value = pc.currentHealth;

        if (pc.currentHealth <= pc.getmaxHealth / 2)
            // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
            m_fillImage.color = Color.yellow;

        if (pc.currentHealth <= pc.getmaxHealth / 5)
            m_fillImage.color = Color.red;
    }*/
}
