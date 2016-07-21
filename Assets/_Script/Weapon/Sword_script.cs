using UnityEngine;
using System.Collections;

public class Sword_script : MonoBehaviour {

    private int _maxDamage;
    private float _varDamage;
    private float _maxDistance;
    private int _durability;
    private int _duraMax;



    public Sword_script()
    {
        // a mettre les bonne caracteristiques suivant l'arme
        _maxDamage = 25;
        _maxDistance = 2;
        _varDamage = 15;
        _durability = 100;
        _duraMax = 100;
    }
    public Sword_script(int mDmg, float varD, float maxD, int dura , int duraM)
    {
        _maxDamage = mDmg;
        _maxDistance = maxD;
        _varDamage = varD;
        _durability = dura;
        _duraMax = duraM;
    }
    public bool can_attack()
    {
        return _durability > 0;
    }
}
