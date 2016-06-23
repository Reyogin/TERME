using UnityEngine;
using System.Collections;

public class Fist_script : MonoBehaviour {

    private int _maxDamage;
    private float _varDamage;
    private float _maxDistance;
    private int _durability;


    public Fist_script()
    {
        // a mettre les bonne caracteristiques suivant l'arme
        _maxDamage = 10;
        _maxDistance = 1;
        _varDamage = 5;
        _durability = 50;
    }
    public Fist_script(int mDmg, float varD, float maxD, int dura)
    {
        _maxDamage = mDmg;
        _maxDistance = maxD;
        _varDamage = varD;
        _durability = dura;
    }
    public bool can_attack()
    {
        return true;
    }
}
