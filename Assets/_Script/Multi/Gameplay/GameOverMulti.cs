using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GameOverMulti : NetworkBehaviour
{

    private PlayerClass Player;
    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
        {
            Player = GetComponent<PlayerClass>();
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            if (Player.currentHealth <= 0)
            {
                GetComponent<Transform>().FindChild("Game Over").gameObject.SetActive(true);
            }
            else
                GetComponent<Transform>().FindChild("Game Over").gameObject.SetActive(false);

        }

    }
}
