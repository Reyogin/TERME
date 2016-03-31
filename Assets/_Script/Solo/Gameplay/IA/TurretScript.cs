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
        InflictPain();
    }

    void OnTriggerStay(Collider other)
    {
        if (timer >= timeBetweenAttacks && other.gameObject.tag == "Player")
        {
            timer = 0f;
            HealthPlayer player = other.gameObject.GetComponent<HealthPlayer>();

            if (player.currentHealth > 0)
            {
                player.damageImage.color = player.flashColor;
                player.currentHealth -= 10;
                //player.healthSlider.value = player.currentHealth;
                player.SetHealthUI();
            }

            if (player.currentHealth <= 0)
            {
                MoveControlsSolo moves = other.GetComponent<MoveControlsSolo>();
                CameraControllerSolo camCtrl = other.GetComponent<CameraControllerSolo>();
                Animator m_anim = other.GetComponent<Animator>();

                moves.enabled = false;
                camCtrl.enabled = false;
                m_anim.enabled = false;
            }

            player.damageImage.color = Color.Lerp(player.damageImage.color, Color.clear, player.flashSpeed * Time.deltaTime);

        }
    }

    void InflictPain()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 1.5f, Vector3.zero, out hit, 0))
            //if (hit.transform.CompareTag("Player"))
                if (timer >= timeBetweenAttacks)
                {
                    timer = 0f;
                    HealthPlayer player = hit.transform.gameObject.GetComponent<HealthPlayer>();

                    if (player.currentHealth > 0)
                    {
                        player.damageImage.color = player.flashColor;
                        player.currentHealth -= 10;
                        //player.healthSlider.value = player.currentHealth;
                        player.SetHealthUI();
                    }

                    if (player.currentHealth <= 0)
                    {
                        MoveControlsSolo moves = hit.transform.gameObject.GetComponent<MoveControlsSolo>();
                        CameraControllerSolo camCtrl = hit.transform.gameObject.GetComponent<CameraControllerSolo>();
                        Animator m_anim = hit.transform.gameObject.GetComponent<Animator>();

                        moves.enabled = false;
                        camCtrl.enabled = false;
                        m_anim.enabled = false;
                    }

                    player.damageImage.color = Color.Lerp(player.damageImage.color, Color.clear, player.flashSpeed * Time.deltaTime);

                }
    }
}
