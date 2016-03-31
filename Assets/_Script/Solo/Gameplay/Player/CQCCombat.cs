using UnityEngine;
using System.Collections;

public class CQCCombat : PlayerClass
{
    public float distance;
    public float damage = 30f;
    public float range = 2f;

    // Use this for initialization
    void Start()
    {
        this.guardPoints = 100;
        this.currGP = guardPoints;
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

        if (guard && currGP > 0)
            return true;
        else
            return false;
    }
}
