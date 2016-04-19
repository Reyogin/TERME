using UnityEngine;
using System.Collections;

public class AI_test : MonoBehaviour
{
    private Transform target;
    Animator animator;
    NavMeshAgent nav;
    float timer;
    private float timebetweenatks = 1.0f;
    private float range = 2f;
    private float distance;
    private float damage = 40f;
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
        MoveTowards();
        //Attack();
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
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            distance = hit.distance;

            if (distance <= range)
                hit.transform.SendMessage("TakingPunishment", damage, SendMessageOptions.DontRequireReceiver);
        }
    }
}

