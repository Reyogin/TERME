using UnityEngine;
using System.Collections;


public class Weapon : MonoBehaviour {
    private int _maxDamage;
    private float _varDamage;
    private float _maxDistance;
    private int _durability;
    private System.Random rnd;


    //Constructeur par defaut
    public Weapon()
    {
        _maxDamage = 0;
        _maxDistance = 0;
        _varDamage = 0;
        _durability = 50;
        rnd = new System.Random();
    }

    public Weapon(int mDmg , float varD , float maxD , int dura)
    {
        _maxDamage = mDmg;
        _maxDistance = maxD;
        _varDamage = varD;
        _durability = dura;

    }

    //Setter and getter
    public int MaxDamage
    {
        get { return _maxDamage; }
        set { _maxDamage = value; }
    }

    public float DamageVariance
    {
        get { return _varDamage; }
        set { _varDamage = value; }
    }

    public float MaxDistance
    {
        get { return _maxDistance; }
        set { _maxDistance = value; }
    }

    public int degatsEffectue()
    {
        _durability --;
        //valeur ajoutee
        int valAdd = rnd.Next(0, (int)_varDamage);
        return MaxDamage + valAdd;


    }
    public bool can_attack()
    {
        return true;
    }

}



