using UnityEngine;
using System.Collections;

public class AIScript_master : MonoBehaviour
{
    private Transform target;
    Animator animator;
    NavMeshAgent nav;
    float timer;
    private float timebetweenatks = 2.0f;
    private float range = 2f;
    private float distance;
    private float damage = 10f;
    // Use this for initialization
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
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
        Vector3 targetDir = target.position - transform.position;
        Vector3 forward = transform.forward;

        float distance = Vector3.Distance(transform.position, target.position);
        float angle = Vector3.Angle(targetDir, forward);

        if (angle < 45f)
        {
            if (distance <= 25f)
            {
                nav.SetDestination(target.position);
                animator.SetBool("Sees Enemy", true);
            }
            else
                animator.SetBool("Sees Enemy", false);
        }

        if (target.GetComponent<GUI_HealthPlayer>().currentHealth <= 0)
        {
            nav.Stop();
            animator.SetBool("Sees Enemy", false);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
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
            if (distance <= range && timer >= timebetweenatks)
            {
                timer = 0f;
                animator.SetTrigger("Atk");
                target.transform.SendMessage("TakingPunishment", damage);
            }
            animator.SetTrigger("Rest");

            if (target.GetComponent<GUI_HealthPlayer>().currentHealth <= 0)
            {
                animator.SetBool("Sees Enemy", false);
                animator.SetTrigger("Rest");
            }
        }
    }
}

