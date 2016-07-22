using UnityEngine;
using System.Collections;

public class Gun_script : Weapon
{


    public Gun_script() : base(15, 20, 10, 50, 50)
    {
    }


    public bool can_attack()
    {
        return durabilite > 0;
    }
}
