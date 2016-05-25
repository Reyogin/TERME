using UnityEngine;
using System.Collections;

public class Fist_script : MonoBehaviour {

    private int _maxDamage;
    private float _varDamage;
    private float _maxDistance;
    private int _durability;
    private WeaponType _weatype;


    public Fist_script()
    {
        // a mettre les bonne caracteristiques suivant l'arme
        _maxDamage = 0;
        _maxDistance = 0;
        _varDamage = 0;
        _durability = 50;
    }
    public Fist_script(int mDmg, float varD, float maxD, int dura, WeaponType weatype)
    {
        _maxDamage = mDmg;
        _maxDistance = maxD;
        _varDamage = varD;
        _durability = dura;
        _weatype = weatype;
    }
}
