using UnityEngine;
using System.Collections;

public class Knife_script : Weapon
{

    public Knife_script() : base(15,1,100,100,1)
    {
        base.imageName = "Image/weaponssprites/Knife";
        this.w_name = "Knife";
    }


    public Knife_script(float durabiliteActuelle) : base(15, 1, durabiliteActuelle, 100, 1)
    {
        base.imageName = "Image/weaponssprites/Knife";
    }

    public override bool can_attack()
    {
        return  durabilite > 0;
    }
}

