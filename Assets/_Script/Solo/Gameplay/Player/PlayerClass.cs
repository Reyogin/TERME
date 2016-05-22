using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerClass : MonoBehaviour
{
    private float maxHealth;
    private float currHealth;
    private float guardPoints;
    private float currGP;
    private bool inCombat;

	// Use this for initialization
	protected virtual void Start ()
    {
        maxHealth = 100f;
        currHealth = maxHealth;
        guardPoints = 100f;
        currGP = guardPoints;
        inCombat = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    #region Getters/Setters
    public float currentHealth
    {
        get { return currHealth; }
        set { this.currHealth = value; }
    }

    public float getmaxHealth
    {
        get { return maxHealth; }
        set { this.maxHealth = value; }
    }

    public float getGP
    {
        get { return guardPoints; }
        set { this.guardPoints = value; }

    }

    public float currentGP
    {
        get { return currGP; }
        set { this.currGP = value; }
    }

    public bool combatStatus
    {
        get { return this.inCombat; }
        set { this.inCombat = value; }
    }
    #endregion
}
