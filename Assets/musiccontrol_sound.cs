using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class musiccontrol_sound : MonoBehaviour
{


    // Use this for initialization

    public Slider slider;

    void Start()
    {
        GameObject soundObject = GameObject.Find("button");
        AudioSource audioSource = soundObject.GetComponent<AudioSource>();
        slider = GameObject.Find("Slider_sound").GetComponent<Slider>();
        slider.value = audioSource.volume;
    }

    // Use this for initialization

    public void SetVolume(float value)
    {
        GameObject soundObject = GameObject.Find("button");
        AudioSource audioSource = soundObject.GetComponent<AudioSource>();
        audioSource.volume = value;
    }
}



