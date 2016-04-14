using UnityEngine;
using System.Collections;

public class CQCCombat : PlayerClass
{
    private float distance;
    private float damage = 30f;
    private float range = 2f;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
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
                       
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                distance = hit.distance;
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
}
