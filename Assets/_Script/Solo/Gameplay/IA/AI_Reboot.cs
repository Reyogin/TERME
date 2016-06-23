using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AI_Reboot : AIClass
{
    public Image healthbar;
    Animator animator;
    bool isDead;
    private Transform target;
    NavMeshAgent nav;
    float timer;

    // Use this for initialization
    void Start ()
    {
        max_hp = 100;
        curr_hp = max_hp;
        atk_range = 2;
        atk_spd = 2;
        atk_dmg = 10;
        patrol_spd = 2;
        chase_spd = 4.4f;
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        isDead = curr_hp <= 0;
        healthbar = transform.FindChild("EnemyCanvas").FindChild("HealthBG").FindChild("Health").GetComponent<Image>();
        animator.SetBool("Idle", true);
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        MoveTowards();
        Attack();
        Debug.Log(curr_hp);
    }

    public void SetHealthBar(float health)
    {
        if (health <= 0.5)
            healthbar.color = Color.yellow;
        if (health <= 0.2)
            healthbar.color = Color.red;
        healthbar.transform.localScale = new Vector3(health, healthbar.transform.localScale.y, healthbar.transform.localScale.z);
    }

    public void TakingPunishment(int damage)
    {
        animator.SetTrigger("Ishurt");
        curr_hp -= damage;
        float calc_health = curr_hp / max_hp;
        SetHealthBar(calc_health);
        isDead = curr_hp <= 0;
        if (isDead)
        {
            nav.Stop();
            curr_hp = 0f;
            SetHealthBar(0);
            animator.SetTrigger("Dead");
            GameObject.Destroy(this.gameObject, 2.5f);
        }
        nav.speed = chase_spd;
        nav.SetDestination(target.position);
        animator.SetBool("Sees Enemy", true);
        //animator.SetTrigger("Rest");
    }

    void MoveTowards()
    {
        Vector3 targetDir = target.position - transform.position;
        Vector3 forward = transform.forward;

        float distance = Vector3.Distance(transform.position, target.position);
        float angle = Vector3.Angle(targetDir, forward);

        if (angle < 45f)
        {
            if (distance <= 25f)
            {
                nav.speed = chase_spd;
                nav.SetDestination(target.position);
                animator.SetBool("Sees Enemy", true);
            }
            else
                animator.SetBool("Sees Enemy", false);
        }

        if (target.GetComponent<Combat>().currentHealth <= 0)
        {
            nav.Stop();
            animator.SetBool("Sees Enemy", false);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            nav.speed = chase_spd;
            nav.SetDestination(target.position);
            animator.SetBool("Sees Enemy", true);
        }
        else
            animator.SetBool("Sees Enemy", false);
    }

    void Attack()
    {
        Vector3 targetDir = target.position - transform.position;
        Vector3 forward = transform.forward;

        float distance = Vector3.Distance(transform.position, target.position);
        float angle = Vector3.Angle(targetDir, forward);

        if (angle < 45f)
        {
            if (distance <= atk_range && timer >= atk_spd)
            {
                timer = 0f;
                animator.SetTrigger("Atk");
                target.transform.SendMessage("TakingPunishment", atk_dmg);
            }
            animator.SetTrigger("Rest");

            if (target.GetComponent<Combat>().currentHealth <= 0)
            {
                animator.SetBool("Sees Enemy", false);
                animator.SetTrigger("Rest");
            }
        }
    }
}
