using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class PLayerScript_multi : NetworkBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
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
        currentHealth = startingHealth;
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
                healthSlider.value = currentHealth;
            }

            if (currentHealth <= 0 && !isDead)
            {
                isDead = true;
                movecontrol.enabled = false;
                cameracontrol.enabled = false;
            }
        }

    }
}
