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
	void Start ()
    {
        /*this.maxHp = 100f;
        this.currHp = maxHp;
        this.patrolSpd = 1;
        this.chaseSpd = 2.5f;*/
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
