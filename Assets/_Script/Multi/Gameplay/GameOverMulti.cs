using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GameOverMulti : NetworkBehaviour
{

    private PlayerClass Player;
    public GameObject gameOver;
    public GameObject reticule;
    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
        {
            Player = GetComponent<GUI_HealthPlayer>();
        }


    }

    // Update is called once per frame
    void Update()
    { /*}
        if (isLocalPlayer)
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

        }*/

    }
}
