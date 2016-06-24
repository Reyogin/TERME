using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class AIClass : MonoBehaviour
{
    private float currHp;
    private float maxHp;
    private float atkSpd;
    private float atkRange;
    private float atkDmg;
    private float patrolSpd;
    private float chaseSpd;
    private bool aggro;

	// Use this for initialization
	protected virtual void Start ()
    {
        max_hp = 100;
        curr_hp = max_hp;
        atk_range = 2;
        atk_spd = 2;
        atk_dmg = 10;
        patrol_spd = 2;
        chase_spd = 4.4f;
        aggro = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    #region Getters/setters
    public float curr_hp
    {
        get { return this.currHp; }
        set { this.currHp = value; }
    }

    public float max_hp
    {
        get { return this.maxHp; }
        set { this.maxHp = value; }
    }

    public bool aggro_state
    {
        get { return this.aggro; }
        set { this.aggro = value; }
    }

    public float atk_spd
    {
        get { return this.atkSpd; }
        set { this.atkSpd = value; }
    }

    public float atk_range
    {
        get { return this.atkRange; }
        set { this.atkRange = value; }
    }

    public float atk_dmg
    {
        get { return this.atkDmg; }
        set { this.atkDmg = value; }
    }

    public float patrol_spd
    {
        get { return this.patrolSpd; }
        set { this.patrolSpd = value; }
    }

    public float chase_spd
    {
        get { return this.chaseSpd; }
        set { this.chaseSpd = value; }
    }
    #endregion
}
