using UnityEngine;
using System.Collections;

public class Knife_script : Weapon
{

    private int _maxDamage;
    private float _varDamage;
    private float _maxDistance;
    private int _durability;



    public Knife_script()
    {
        // a mettre les bonne caracteristiques suivant l'arme
        _maxDamage = 15;
        _maxDistance = 1;
        _varDamage = 10;
        _durability = 100;
    }
    public Knife_script(int mDmg, float varD, float maxD, int dura)
    {
        _maxDamage = mDmg;
        _maxDistance = maxD;
        _varDamage = varD;
        _durability = dura;
    }

    public bool can_attack()
    {
        return _durability > 0;
    }
}

