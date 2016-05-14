using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class toggle_sound : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void currentvalue(bool value)
    {

        GameObject soundObject = GameObject.Find("button");
        AudioSource audioSource = soundObject.GetComponent<AudioSource>();

        if (value)
        {
            audioSource.Play();
        }
        else
        {

            audioSource.Pause();
        }


    }
}
