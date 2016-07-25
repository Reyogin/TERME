using UnityEngine;
using System.Collections;

public class Knife_script : Weapon
{

    public Knife_script() : base(15,1,100,100,1)
    {
    }



    public bool can_attack()
    {
        return  durabilite > 0;
    }
}

