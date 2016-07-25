using UnityEngine;
using System.Collections;

public class Gun_script : Weapon
{


    public Gun_script() : base(35, 10, 50, 50 ,10)
    {
        base.imageName ="Image/weaponssprites/Gun";
    }

    public Gun_script(float durabiliteActuelle) : base(35, 10, durabiliteActuelle, 50, 10)
    {
        base.imageName = "Image/weaponssprites/Gun";
    }
    public bool can_attack()
    {
        return durabilite > 0;
    }
}
