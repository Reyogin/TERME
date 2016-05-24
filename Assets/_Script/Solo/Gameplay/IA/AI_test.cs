using UnityEngine;
using System.Collections;

public class AI_test : MonoBehaviour
{
    private GameObject target;
    Animator animator;
    NavMeshAgent nav;
    float timer;
    private float timebetweenatks = 2.0f;
    private float range = 2f;
    //private float distance;
    private float damage = 10f;
    // Use this for initialization
    void Start()
    {
        this.nav = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        animator.SetBool("Idle", true);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        MoveTowards();
        Attack();
    }

    void MoveTowards()
    {
        Vector3 targetDir = target.transform.position - transform.position;
        Vector3 forward = transform.forward;

        float distance = Vector3.Distance(transform.position, target.transform.position);
        float angle = Vector3.Angle(targetDir, forward);

        if (angle < 45f)
        {
            if (distance <= 25f)
            {
                Debug.Log("see player");
                nav.SetDestination(target.transform.position);
                animator.SetBool("Sees Enemy", true);
                animator.SetBool("Idle", false);
            }
            else
            {
                Debug.Log("don't see player");
                animator.SetBool("Sees Enemy", false);
                animator.SetBool("Idle", true);
            }
        }

        if (target.GetComponent<GUI_HealthPlayer>().currentHealth <= 0)
        {
            nav.Stop();
            animator.SetBool("Sees Enemy", false);
            animator.SetBool("Idle", true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.transform == target)
        {
            nav.SetDestination(target.transform.position);
            animator.SetBool("Sees Enemy", true);
            animator.SetBool("Idle", false);
        }
        else
        {
            nav.Stop();
            animator.SetBool("Sees Enemy", false);
            animator.SetBool("Idle", true);
        }
    }

    void Attack()
    {
        Vector3 targetDir = target.transform.position - transform.position;
        Vector3 forward = transform.forward;

        float distance = Vector3.Distance(transform.position, target.transform.position);
        float angle = Vector3.Angle(targetDir, forward);

        if (angle < 45f)
        {
            if (distance <= range && timer >= timebetweenatks)
            {
                animator.SetTrigger("Atk");
                target.transform.SendMessage("TakingPunishment", damage);
                timer = 0f;
                //animator.SetBool("Sees Enemy", false);
            }
            /*else
                animator.SetBool("Atk", false);*/
            animator.SetTrigger("Rest");
        }

        if (target.GetComponent<GUI_HealthPlayer>().currentHealth <= 0)
        {
            animator.SetBool("Sees Enemy", false);
            animator.SetBool("Idle", true);
            //animator.SetBool("Atk", false);
        }
    }
}

