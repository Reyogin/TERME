using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IAHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public float currentHealth;
    private float calc_health;
    public Image healthbar;
    bool isDead;


    // Use this for initialization
    void Start()
    {
        currentHealth = startingHealth;
        healthbar = transform.FindChild("EnemyCanvas").FindChild("HealthBG").FindChild("Health").GetComponent<Image>();
        isDead = currentHealth <= 0;
    }

    // Update is called once per frame
    void Update()
    {
        TakeDamage(10);
    }

    void TakeDamage(int amount)
    {
        bool isDamaged = Input.GetKeyUp(KeyCode.C);

        if (isDamaged && !isDead)
        {
            currentHealth -= amount;

            if (currentHealth <= 0)
            {
                isDead = true;
                GameObject.Destroy(this.gameObject);
            }

            calc_health = currentHealth / startingHealth;
            SetHealthBar(calc_health);
        }
    }

    public void SetHealthBar(float health)
    {
        if (health <= 0.5)
            healthbar.color = Color.yellow;
        if (health <= 0.2)
            healthbar.color = Color.red;
        healthbar.transform.localScale = new Vector3(health, healthbar.transform.localScale.y, healthbar.transform.localScale.z);
    }

    public void ApplyDamage(int damage)
    {
        currentHealth -= damage;
        calc_health = currentHealth / startingHealth;
        SetHealthBar(calc_health);
        if (currentHealth <= 0)
        {
            isDead = true;
            GameObject.Destroy(this.gameObject);
        }
    }
}
