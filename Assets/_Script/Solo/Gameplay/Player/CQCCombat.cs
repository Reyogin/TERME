using UnityEngine;
using System.Collections;

public class CQCCombat : MonoBehaviour
{
    public float distance;
    public float damage = 30f;
    public float range = 15f;

    // Use this for initialization
    void Start()
    {

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

            Debug.DrawRay(GetComponentInChildren<Camera>().transform.position, Vector3.back * 15);

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                distance = hit.distance;
                if (distance <= range)
                    hit.transform.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
