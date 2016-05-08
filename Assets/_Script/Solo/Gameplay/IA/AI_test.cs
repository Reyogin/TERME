using UnityEngine;
using System.Collections;

public class AI_test : MonoBehaviour
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
                animator.SetBool("Idle", false);
            }
            else
            {
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
        if (other.gameObject.tag == "Player")
        {
            nav.SetDestination(target.position);
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
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            distance = hit.distance;

            if (distance <= range && timer >= timebetweenatks)
            {
                animator.SetTrigger("Atk");
                hit.transform.SendMessage("TakingPunishment", damage, SendMessageOptions.DontRequireReceiver);
                timer = 0f;
                //animator.SetBool("Sees Enemy", false);
            }
            /*else
                animator.SetBool("Atk", false);*/
            animator.SetTrigger("Atk");
        }

        if (target.GetComponent<GUI_HealthPlayer>().currentHealth <= 0)
        {
            animator.SetBool("Sees Enemy", false);
            animator.SetBool("Idle", true);
            //animator.SetBool("Atk", false);
        }
    }
}

