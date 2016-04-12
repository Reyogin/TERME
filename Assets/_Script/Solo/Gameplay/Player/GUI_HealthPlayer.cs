using UnityEngine;
using System.Collections;

public class GUI_HealthPlayer : PlayerClass {

    public Texture image;
    private float hsliderValue = 0f;

	// Use this for initialization
	void Start ()
    {
        this.maxHealth = 100;
        this.currHealth = maxHealth;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(30, Screen.height - 250, 400, 400), image, ScaleMode.ScaleToFit);

    }
}
