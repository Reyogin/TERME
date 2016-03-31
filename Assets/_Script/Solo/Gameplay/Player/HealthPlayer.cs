using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthPlayer : PlayerClass {
    //public int startingHealth = 100;
    //public int currentHealth;
    public Slider healthSlider;
    public Image m_fillImage;
    public Color m_fullHealthColor = Color.green;
    public Color m_ZeroHealthColor = Color.red;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    MoveControlsSolo movecontrol;
    CameraControllerSolo cameracontrol;
    Animator m_animator;
    bool isDead;
    bool isDamaged;
    


	// Use this for initialization
	void Start ()
    {
        this.maxHealth = 100;
        this.currHealth = maxHealth;
        movecontrol = GetComponent<MoveControlsSolo>();
        cameracontrol = GetComponent<CameraControllerSolo>();
        m_animator = GetComponent<Animator>();

        SetHealthUI();
	}
	
	// Update is called once per frame
	void Update ()
    {
        isDamaged = Input.GetKeyDown(KeyCode.H);

        if (isDamaged && !isDead)
        {
            damageImage.color = flashColor;
            TakeDamage(10);
        }
        else
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);

        isDamaged = false;
	}

    public void TakeDamage (int amount)
    {
        isDamaged = true;

        if (Input.GetKeyDown(KeyCode.H))
        {
            currHealth -= amount;
            SetHealthUI();
        }

        if (currHealth <= 0 && !isDead)
        {
            isDead = true;
            movecontrol.enabled = false;
            cameracontrol.enabled = false;
            m_animator.enabled = false;
        }
    }

    public void SetHealthUI()
    {
        // Set the slider's value appropriately.
        healthSlider.value = currHealth;

        if (currHealth <= maxHealth / 2)
            // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
            m_fillImage.color = Color.yellow;

        if (currHealth <= maxHealth/5)
            m_fillImage.color = Color.red;
    }
}
