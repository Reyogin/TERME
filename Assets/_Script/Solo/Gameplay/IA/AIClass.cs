using UnityEngine;
using System.Collections;

public class AIClass : MonoBehaviour
{
    private float currHp;
    private float maxHp;
    private float atkSpd;
    private float atkRange;
    private float atkDmg;
    private bool aggro;

	// Use this for initialization
	void Start ()
    {
        /*this.maxHp = 100f;
        this.currHp = maxHp;*/
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
    #endregion
}
