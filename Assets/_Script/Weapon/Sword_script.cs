using UnityEngine;
using System.Collections;

public class Sword_script : Weapon {

    public Sword_script() : base(25,2,100,100,4)
    {
        base.imageName = "Image/weaponssprites/Sword";
    }

    public Sword_script(float durabiliteActuelle) : base(25, 2, durabiliteActuelle, 100, 4)
    {
        base.imageName = "Image/weaponssprites/Sword";
    }
    public bool can_attack()
    {
        return durabilite > 0;
    }
}
