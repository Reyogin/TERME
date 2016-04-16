using UnityEngine;
using System.Collections;

public class CQCCombat : PlayerClass
{
    private float distance;
    private float damage = 30f;
    private float range = 2f;
    protected Animator m_animator;
    bool isDead;
    private float atkcooldown = 1.2f;
    private float atkSpeed;
    //private readonly int hashAtkSpeed = Animator.StringToHash("AtkSpeed");

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        m_animator = GetComponent<Animator>();
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        atkSpeed += Time.deltaTime;
        Attack();
    }

    void Attack()
    {
        bool attack = Input.GetButtonDown("Fire1");

        if (attack)
        {
            atkSpeed = 0f;
            Animate_atk();

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                distance = hit.distance;
                if (distance <= range)
                    hit.transform.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    public bool Guard()
    {
        bool guard = Input.GetButton("Fire2");

        if (guard && currentGP > 0)
            return true;
        else
            return false;
    }

    public void TakingPunishment(float dmg) ///Refresh HP Values + Hurting Animations
    {
        Die();

        if (currentHealth > 0 && !isDead)
        {
            m_animator.SetTrigger("IsHurt");
            currentHealth -= dmg;
        }

        //m_animator.SetBool("IsHurt", false);
        m_animator.SetTrigger("Unhurt");
    }

    public void Die() ///Animations de mort
    {
        if (currentHealth <= 0 && !isDead)
        {
            MoveControlsSolo moves = GetComponent<MoveControlsSolo>();
            CameraControllerSolo camCtrl = GetComponent<CameraControllerSolo>();

            isDead = true;
            m_animator.SetTrigger("Dead");

            moves.enabled = false;
            camCtrl.enabled = false;
        }
    }

    void Animate_atk() ///Animations d'attaque
    {
        //m_animator.SetFloat(hashAtkSpeed, atkcooldown);

        if (Input.GetButtonDown("Fire1")) //lance la première attaque
        {
            ///FIXME : gérer différemment la valeur d'atkSpeed
            m_animator.SetBool("IsAtking", true);
            //atkSpeed = 0;
            //atkSpeed += Time.deltaTime;

            if (m_animator.GetBool("IsAtking") && Input.GetButtonDown("Fire1") && atkSpeed <= atkcooldown)///FIXME = gérer le comboing différemment
            //lance les combos tant que l'on ne dépasse pas la valeur d'AtkSpeed
            {
                m_animator.SetBool("Comboing", true);
                //atkSpeed = 0f;
            }

            else
                m_animator.SetBool("Comboing", false);
        }
        else
            m_animator.SetBool("IsAtking", false);


    }
}
