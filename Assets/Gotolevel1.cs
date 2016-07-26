using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Gotolevel1 : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            SceneManager.LoadScene("Level 2");
    }
}
