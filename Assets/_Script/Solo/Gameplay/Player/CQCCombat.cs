using UnityEngine;
using System.Collections;

public class CQCCombat : PlayerClass
{
    private float distance;
    private float damage = 30f;
    private float range = 1f;
    protected Animator m_animator;
    bool isDead;
    private float atkcooldown = 0.4f;
    private float atkSpeed;
    private int slashNb = 0;
    //private readonly int hashAtkSpeed = Animator.StringToHash("AtkSpeed");

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        m_animator = GetComponent<Animator>();
        isDead = currentHealth <= 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("CQC : " + currentHealth);
        if (Input.GetKeyDown(KeyCode.C))
            TakingPunishment(10);
        //Die();
        atkSpeed += Time.deltaTime;
        if (atkSpeed > (atkcooldown + 0.2f))
            m_animator.SetBool("IsAtking", false);
        Attack();
    }

    void Attack()
    {
        bool attack = Input.GetButtonDown("Fire1");
        if (attack && currentHealth > 0 && atkSpeed >= atkcooldown)
        {
            m_animator.SetBool("IsAtking", true);
            atkSpeed = 0f;
            Animate_atk();

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                distance = hit.distance;
                Debug.Log(distance);
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
        //Die();

        if (currentHealth > 0 && !isDead)
        {
            //Debug.Log(currentHealth);
            m_animator.SetTrigger("IsHurt");
            currentHealth -= dmg;
            //isDead = currentHealth <= 0;
        }

        //m_animator.SetBool("IsHurt", false);
        m_animator.SetTrigger("Rest");
        Die();
    }

    public void Die() ///Animations de mort
    {
        if (currentHealth <= 0 && !isDead)
        {
            currentHealth = 0f;
            MoveControlsSolo moves = GetComponent<MoveControlsSolo>();
            CameraControllerSolo camCtrl = GetComponent<CameraControllerSolo>();
            CQCCombat combatscript = GetComponent<CQCCombat>();

            isDead = true;
            m_animator.SetTrigger("Dead");

            moves.enabled = false;
            camCtrl.enabled = false;
            combatscript.enabled = false;
        }
    }

    void Animate_atk() ///Animations d'attaque
    {
        //m_animator.SetFloat(hashAtkSpeed, atkcooldown);

        if (Input.GetButtonDown("Fire1") && slashNb == 0) //lance la première attaque
        {
            //m_animator.SetBool("IsAtking", true);
            m_animator.SetTrigger("Attack 1");
        }
        else
            //m_animator.SetBool("IsAtking", false);
            m_animator.SetTrigger("Attack 2");
        slashNb = (slashNb + 1) % 2;
    }
}
