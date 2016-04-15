using UnityEngine;
using System.Collections;

public class CQCCombat : PlayerClass
{
    private float distance;
    private float damage = 30f;
    private float range = 2f;
    protected Animator m_animator;
    bool isDead;

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
        Attack();
    }

    void Attack()
    {
        bool attack = Input.GetButtonDown("Fire1");

        if (attack)
        {
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
        if (currentHealth > 0 && !isDead)
        {
            m_animator.SetTrigger("IsHurt");
            currentHealth -= dmg;
        }

        //m_animator.SetBool("IsHurt", false);

        Die();

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
        if (Input.GetButtonDown("Fire1"))
            m_animator.SetBool("IsAtking", true);
        else
            m_animator.SetBool("IsAtking", false);

        if (m_animator.GetBool("IsAtking") && Input.GetButtonDown("Fire1"))
            m_animator.SetBool("Comboing", true);
        else
            m_animator.SetBool("Comboing", true);
    }
}
