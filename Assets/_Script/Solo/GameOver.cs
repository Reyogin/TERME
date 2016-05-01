using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{
    private PlayerClass Player;
    // Use this for initialization
    public GameObject reticule;
    public GameObject gameOver;
    void Start()
    {
        Player = GetComponent<GUI_HealthPlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.currentHealth <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            reticule.SetActive(false);
        }
        else
        {
            gameOver.SetActive(false);
        }


    }
}
