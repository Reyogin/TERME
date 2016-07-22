using UnityEngine;
using System.Collections;

public class Fist_script : Weapon {


    public Fist_script() : base(10,5,1,50,50)
    {
        // a mettre les bonne caracteristiques suivant l'arme
}
    public bool can_attack()
    {
        return true;
    }
}
