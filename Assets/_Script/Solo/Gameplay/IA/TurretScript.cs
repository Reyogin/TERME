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
                hpplayer.TakingPunishment(10);         
            ///Decommenter le code ci-dessous une fois que la méthode pour faire flasher l'écran sera good
                    //hpplayer.damageImage.color = hpplayer.flashColor;
                    
                    //player.healthSlider.value = player.currentHealth;
                    //hpplayer.SetHealthUI();
                
                //hpplayer.damageImage.color = Color.Lerp(hpplayer.damageImage.color, Color.clear, hpplayer.flashSpeed * Time.deltaTime);
            
        }
    }

    ///Supposedly 
    /*void InflictPain() 
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 1.5f, Vector3.zero, out hit, 0))
            //if (hit.transform.CompareTag("Player"))
                if (timer >= timeBetweenAttacks)
                {
                    timer = 0f;
                    HealthPlayer player = hit.transform.gameObject.GetComponent<HealthPlayer>();

                    if (player.currHealth > 0)
                    {
                        player.damageImage.color = player.flashColor;
                        player.currHealth -= 10;
                        //player.healthSlider.value = player.currentHealth;
                        player.SetHealthUI();
                    }

                    if (player.currHealth <= 0)
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
    }*/
}
