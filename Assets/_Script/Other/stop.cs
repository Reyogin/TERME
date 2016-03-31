using UnityEngine;
using System.Collections;

public class stop : MonoBehaviour
{
    void Awake()
    {
        GameObject gameMusic = GameObject.Find("Music");
        if (gameMusic)
        {
            Destroy(gameMusic);
        }
    }
}

