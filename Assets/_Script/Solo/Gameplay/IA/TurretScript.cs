using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour
{

    Collider range;
    public float timeBetweenAttacks = 0.5f;
    float timer;
    // Use this for initialization
    void Start()
    {
        range = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //InflictPain();
    }

    void OnTriggerStay(Collider other)
    {
        if (timer >= timeBetweenAttacks && other.gameObject.tag == "Player")
        {
            timer = 0f;
            GUI_HealthPlayer hpplayer = other.gameObject.GetComponent<GUI_HealthPlayer>();
            GUI_HealthPlayer playerGP = other.gameObject.GetComponent<GUI_HealthPlayer>();

            if (playerGP.Guard())
                playerGP.currentGP -= 10;


            else
            {
                if (hpplayer.currentHealth > 0)
                {
                    //hpplayer.damageImage.color = hpplayer.flashColor;
                    hpplayer.currentHealth -= 10;
                    //player.healthSlider.value = player.currentHealth;
                    //hpplayer.SetHealthUI();
                }

                if (hpplayer.currentHealth <= 0)
                {
                    MoveControlsSolo moves = other.GetComponent<MoveControlsSolo>();
                    CameraControllerSolo camCtrl = other.GetComponent<CameraControllerSolo>();
                    Animator m_anim = other.GetComponent<Animator>();

                    moves.enabled = false;
                    camCtrl.enabled = false;
                    m_anim.enabled = false;
                }

                //hpplayer.damageImage.color = Color.Lerp(hpplayer.damageImage.color, Color.clear, hpplayer.flashSpeed * Time.deltaTime);
            }
        }
    }
}
