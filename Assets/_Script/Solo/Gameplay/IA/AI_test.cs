using UnityEngine;
using System.Collections;

public class AI_test : MonoBehaviour
{
    public Transform target;
    NavMeshAgent nav;
    // Use this for initialization
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowards();
    }

    void MoveTowards()
    {
        Vector3 targetDir = target.position - transform.position;
        Vector3 forward = transform.forward;

        float distance = Vector3.Distance(transform.position, target.position);
        float angle = Vector3.Angle(targetDir, forward);

        if (angle < 45f)
            if (distance <= 25f)
            {
                nav.SetDestination(target.position);
            }
    }
}
