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
    public float leavecombat;
    private bool inguard;
    private float isbehind;
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
        //Die();
        //regenGP(combatStatus);
        atkSpeed += Time.deltaTime;
        leavecombat += Time.deltaTime;
        if (atkSpeed > (atkcooldown + 0.2f))
            m_animator.SetBool("IsAtking", false);
        inCombat();
        Attack();
    }

    /// <summary>
    /// In theory, should work if cast against player now
    /// </summary>
    void Attack()
    {
        bool attack = Input.GetButtonDown("Fire1");
        if (attack && currentHealth > 0 && atkSpeed >= atkcooldown)
        {
            combatStatus = true;
            leavecombat = 0f;
            m_animator.SetBool("IsAtking", true);
            atkSpeed = 0f;
            Animate_atk();

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                isbehind = Vector3.Dot(transform.TransformDirection(Vector3.forward).normalized, hit.transform.TransformVector(Vector3.forward).normalized);
                Debug.Log("isbehind value = " + isbehind);
                ///isbehind = produit scalaire entre l'avant du perso et le point d'impact
                /// devrait renvoyer une valeur comprise entre -1 et 1
                /// [-1,0[ => le personnage est derrière = pas de garde possible
                /// 0 => le personnage est à la perpendiculaire = pas de garde possible
                /// [0,1] => le personnage se trouve à l'avant de l'autre et peut donc parrer les coups
                distance = hit.distance;
                Debug.Log(distance);
                if (distance <= range)
                    hit.transform.SendMessage("TakingPunishment", damage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    public bool Guard()
    {
        bool guard = Input.GetButton("Fire2");

        return inguard = (guard && currentGP > 0 && isbehind > 0);
    }

    public void TakingPunishment(float dmg) ///Refresh HP Values + Hurting Animations
    {
        combatStatus = true;
        leavecombat = 0f;
        if (Guard())
            currentGP -= dmg;
        else
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

    /// <summary>
    /// Supposedly defines whether or not the character is in combat
    /// If not, should trigger GP regeneration
    /// Doesn't seem to work in GUIHealthPlayer
    /// </summary>
    /// <returns></returns>
    public bool inCombat() 
    {
        if (leavecombat >= 8f)
            combatStatus = false;
        return combatStatus;
    }

    /// <summary>
    /// should trigger GP regeneration
    /// Doesn't seem to work atm
    /// </summary>
    /// <param name="status"> status is to be changed with combat status</param>
    public void regenGP(bool status)
    {
        if (!status && currentGP < getGP)
            currentGP += 5 * Time.deltaTime;
    }
}
