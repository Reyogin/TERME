using UnityEngine;
using System.Collections;

public class Knife_script : Weapon
{

    private int _maxDamage;
    private float _varDamage;
    private float _maxDistance;
    private int _durability;
    private WeaponType _weatype;


    public Knife_script()
    {
        // a mettre les bonne caracteristiques suivant l'arme
        _maxDamage = 0;
        _maxDistance = 0;
        _varDamage = 0;
        _durability = 50;
    }
    public Knife_script(int mDmg, float varD, float maxD, int dura, WeaponType weatype)
    {
        _maxDamage = mDmg;
        _maxDistance = maxD;
        _varDamage = varD;
        _durability = dura;
        _weatype = weatype;
    }

    public bool can_attack()
    {
        return _durability > 0;
    }
}

