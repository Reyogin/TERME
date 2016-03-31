using UnityEngine;
using System.Collections;

public class musicplay : MonoBehaviour
{
    GameObject sound;

    void Awake()
    {
        GameObject sound = GameObject.Find("Music");

        if (sound)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}

