using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Combat_multi : PlayerClassMulti
{
    Weapon weapon;
    #region Combat Stats
    private float distance;
    private float damage;// = 10f;
    private float range;// = 1f;
    protected Animator m_animator;
    bool isDead;
    private float atkcooldown;// = 0.4f;
    private float atkSpeed;
    private int slashNb = 0;
    #endregion

    #region Combat status
    public float leavecombat;
    private bool inguard;
    private float isbehind;
    private bool CaC;
    private bool kungfu;
    private bool shoot;
    #endregion

    #region For HUD
    //permet de dessiner les rectangles
    private static Texture2D _staticRectTexture;
    private static GUIStyle _staticRectStyle;
    //Image du hud de vie
    private Texture image;
    #endregion

    #region Necessary for boomstick
    //Drag in the Bullet Emitter from the Component Inspector.
    public GameObject Bullet_Emitter;
    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Bullet;
    //Enter the Speed of the Bullet from the Component Inspector.
    private readonly float Bullet_Forward_Force = 40f;
    //Audio du coup de feu
    AudioClip bang;
    #endregion

    // Use this for initialization
    protected override void Start()
    {
        if (!isLocalPlayer)
            return;
        base.Start();
        m_animator = this.gameObject.GetComponent<SelectionMult_Player>().PlayerPrefab.GetComponent<Animator>();
        isDead = currentHealth <= 0;
        this.image = Resources.Load<Texture>("Image/hud_healthbar");
        bang = Resources.Load<AudioClip>("Sound/MusketFire");
        weapon = GetComponent<WeaponSwitchMulti>().listeArme[GetComponent<WeaponSwitchMulti>().currentweapon];
        damage = weapon.MaxDamage;
        range = weapon.MaxDistance;
        atkcooldown = weapon.Vitesse;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Cac : " + CaC);
        Debug.Log("kungfu : " + kungfu);
        Debug.Log("Shoot : " + shoot);

        if (!isLocalPlayer)
            return;
        weapon = GetComponent<WeaponSwitchMulti>().listeArme[GetComponent<WeaponSwitchMulti>().currentweapon];
        if (weapon.w_name == "Boomstick")
        {
            shoot = true;
            CaC = false;
            kungfu = false;
        }
        else
        {
            shoot = false;
            CaC = true;
            if (weapon.w_name == "Fist")
                kungfu = true;
            else
                kungfu = false;
        }
        atkSpeed += Time.deltaTime;
        leavecombat += Time.deltaTime;
        if (atkSpeed > (atkcooldown + 0.2f))
            m_animator.SetBool("IsAtking", false);
        inCombat();
        Attack();
        Animate_guard();
        regenGP(inCombat());
    }

    /// <summary>
    /// In theory, should work if cast against player now
    /// </summary>
    // TODO : Look into changing for animation, etc...
    void Attack()
    {
        bool attack = Input.GetButtonDown("Fire1") || Input.GetButtonDown("XBox_X");
        if (attack && currentHealth > 0 && atkSpeed >= atkcooldown && weapon.can_attack())
        {
            if (CaC)
            {
                combatStatus = true;
                leavecombat = 0f;
                m_animator.SetBool("IsAtking", true);
                atkSpeed = 0f;
                Animate_atk();

                RaycastHit hit;

                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
                {
                    distance = hit.distance;
                    Debug.Log(distance);
                    if (distance <= range)
                        hit.transform.SendMessage("TakingPunishment", damage, SendMessageOptions.DontRequireReceiver);
                }
            }
            else
                Invoke("instantiateBullet", 0.2f);
        }
    }

    void Animate_guard()
    {
        if (Input.GetButton("Fire2") || Input.GetButton("XBox_A"))
            m_animator.SetBool("Block", true);
        else
            m_animator.SetBool("Block", false);
    }

    void Animate_atk() ///Animations d'attaque
    {
        //m_animator.SetFloat(hashAtkSpeed, atkcooldown);
        bool attack = Input.GetButtonDown("Fire1") || Input.GetButtonDown("XBox_X");
        if (CaC)
        {
            if (kungfu)
                m_animator.SetTrigger("Sparta");
            else
            {
                if (/*attack && */slashNb == 0) //lance la première attaque
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
        else
            m_animator.SetTrigger("Shoot");
    }
    #region CQC
    public bool Guard()
    {
        bool guard = Input.GetButton("Fire2") || Input.GetButton("XBox_A");
        if (guard)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                isbehind = Vector3.Dot(transform.TransformDirection(Vector3.forward).normalized, hit.transform.TransformVector(Vector3.forward).normalized);
                Debug.Log("isbehind value = " + isbehind);
                ///isbehind = produit scalaire entre l'avant du perso et le point d'impact
                /// devrait renvoyer une valeur comprise entre -1 et 1
                /// ]0,1] => le personnage est derrière = pas de garde possible
                /// 0 => le personnage est à la perpendiculaire = pas de garde possible
                /// [-1,0[ => le personnage se trouve à l'avant de l'autre et peut donc parrer les coups
            }
            else
                isbehind = Mathf.NegativeInfinity;
        }
        return inguard = (guard && currentGP > 0 && isbehind < 0);
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
            Combat combatscript = GetComponent<Combat>();

            isDead = true;
            m_animator.SetTrigger("Dead");

            moves.enabled = false;
            camCtrl.enabled = false;
            combatscript.enabled = false;
        }
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
    #endregion

    #region OnGUI
    ///<summary>
    /// OnGUI Part => gère la partie affichage (normalement)
    /// </summary>
    void OnGUI()
    {
        float hppercent = currentHealth / getmaxHealth;
        float gppercent = currentGP / getGP;
        GUIDrawHP(hppercent);
        GUIDrawGP(gppercent);
        GUI.DrawTexture(new Rect(30, Screen.height - 250, 400, 400), image, ScaleMode.ScaleToFit);
    }

    // Note that this function is only meant to be called from OnGUI() functions.
    /// <summary>
    /// Draws Rectangles on GUI
    /// </summary>
    /// <param name="position"> = position on the screen</param>
    /// <param name="color"> Color of the rectangle drawn</param>
    public static void GUIDrawRect(Rect position, Color color)
    {
        if (_staticRectTexture == null)
            _staticRectTexture = new Texture2D(1, 1);

        if (_staticRectStyle == null)
            _staticRectStyle = new GUIStyle();

        _staticRectTexture.SetPixel(0, 0, color);
        _staticRectTexture.Apply();

        _staticRectStyle.normal.background = _staticRectTexture;

        GUI.Box(position, GUIContent.none, _staticRectStyle);
    }

    public static void GUIDrawHP(float percent)
    {
        if (percent > 0.5f)
            GUIDrawRect(new Rect(162, Screen.height - 70, 228 * percent, 8), new Color(61 / 255f, 161 / 255f, 74 / 255f, 1));
        else if (percent > 0.2f)
            GUIDrawRect(new Rect(162, Screen.height - 70, 228 * percent, 8), Color.yellow);
        else
            GUIDrawRect(new Rect(162, Screen.height - 70, 228 * percent, 8), Color.red);
    }

    public static void GUIDrawGP(float percent)
    {
        GUIDrawRect(new Rect(140, Screen.height - 55, 110 * percent, 5), Color.cyan);
    }
    #endregion

    #region BOOMSTICK
    ///<summary>
    /// Instancie la balle
    /// </summary>
    void instantiateBullet()
    {
        //The Bullet instantiation happens here.
        GameObject Temporary_Bullet_Handler;
        Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

        //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
        //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
        //Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

        //Retrieve the Rigidbody component from the instantiated Bullet and control it.
        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

        //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
        Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

        //BANG!
        AudioSource.PlayClipAtPoint(bang, Bullet_Emitter.transform.position);

        //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
        Destroy(Temporary_Bullet_Handler, 3.0f);
    }
    #endregion
}
