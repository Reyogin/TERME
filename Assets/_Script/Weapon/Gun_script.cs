using UnityEngine;
using System.Collections;

public class Gun_script : MonoBehaviour {

    private int _maxDamage;
    private float _varDamage;
    private float _maxDistance;
    private int _durability;



    public Gun_script()
    {
        // a mettre les bonne caracteristiques suivant l'arme
        _maxDamage = 35;
        _maxDistance = 10;
        _varDamage = 20;
        _durability = 50;
    }
    public Gun_script(int mDmg, float varD, float maxD, int dura)
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
