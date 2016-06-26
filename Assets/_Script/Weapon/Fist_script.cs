using UnityEngine;
using System.Collections;

public class Fist_script : Weapon
{


    public Fist_script() : base(10, 1, Mathf.Infinity, Mathf.Infinity, 3)
    {
        base.imageName = "Image/weaponssprites/Fist";
        this.w_name = "Fist";
    }
}
