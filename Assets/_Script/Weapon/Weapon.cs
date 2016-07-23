using UnityEngine;
using System.Collections;



public class Weapon : MonoBehaviour
{
    private int _maxDamage;
    private float _varDamage;
    private float _maxDistance;
    private int _durability;
    private int _duraMax;
    private System.Random rnd;


    //Constructeur par defaut
    public Weapon()
    {
        _maxDamage = 0;
        _maxDistance = 0;
        _varDamage = 0;
        _durability = 50;
        _duraMax = 50;
        rnd = new System.Random();
    }

    public Weapon(int mDmg, float varD, float maxD, int dura, int duraM)
    {
        _maxDamage = mDmg;
        _maxDistance = maxD;
        _varDamage = varD;
        _durability = dura;
        _duraMax = duraM;

    }

 
    //Setter and getter
    public int MaxDamage
    {
        get { return _maxDamage; }
        set { _maxDamage = value; }
    }

    public int durabilite
    {
        get { return _durability; }
        set { _durability = value; }
    }
    public int MaxDurability
    {
        get { return _duraMax; }
        set { _duraMax = value; }
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
        _durability--;
        //valeur ajoutee
        int valAdd = rnd.Next(0, (int)_varDamage);
        return MaxDamage + valAdd;


    }
    public bool can_attack()
    {
        return true;
    }

}



