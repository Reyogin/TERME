using UnityEngine;
using System.Collections;

public class Sword_script : Weapon {

    public Sword_script() : base(25,2,100,100,4)
    {
    }
    public bool can_attack()
    {
        return durabilite > 0;
    }
}
