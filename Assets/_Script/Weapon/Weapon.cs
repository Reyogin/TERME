using UnityEngine;
using System.Collections;



public class Weapon : MonoBehaviour
{
    private int _maxDamage;
    private float _maxDistance;
    private float _durability;
    private float _duraMax;
    private float _vitesseATQ;



    //Constructeur par defaut
    /*public Weapon()
    {
        /*_maxDamage = 0;
        _maxDistance = 0;
        _varDamage = 0;
        _durability = 50;
        _duraMax = 50;
        //rnd = new System.Random();
    */

    public Weapon(int mDmg, float maxD, float dura, float duraM , float vitesse)
    {
        _maxDamage = mDmg;
        _maxDistance = maxD;
        _durability = dura;
        _duraMax = duraM;
        _vitesseATQ = vitesse;

    }
     public Weapon(float durabiliteActuelle)
    {
        _durability = durabiliteActuelle;
    }

 
    //Setter and getter
    public int MaxDamage
    {
        get { return _maxDamage; }
        set { _maxDamage = value; }
    }

    public float durabilite
    {
        get { return _durability; }
        set { _durability = value; }
    }
    public float MaxDurability
    {
        get { return _duraMax; }
        set { _duraMax = value; }
    }


    public float MaxDistance
    {
        get { return _maxDistance; }
        set { _maxDistance = value; }
    }
    public float Vitesse
    {
        get { return _vitesseATQ; }
        set { _vitesseATQ = value; }
    }

    public int degatsEffectue()
    {
        _durability--;
        return MaxDamage ;


    }
    public bool can_attack()
    {
        return true;
    }

}



