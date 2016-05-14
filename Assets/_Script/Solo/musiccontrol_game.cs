using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class musiccontrol_game : MonoBehaviour {


    // Use this for initialization

    public Slider slider; 

    void Start()
    {
        GameObject soundObject = GameObject.Find("destroy");
        AudioSource audioSource = soundObject.GetComponent<AudioSource>();
        slider = GameObject.Find("Music_slider").GetComponent<Slider>();
        slider.value = audioSource.volume;
    }

    // Use this for initialization
     
    public void SetVolume(float value)
    {
        GameObject soundObject = GameObject.Find("destroy");
        AudioSource audioSource = soundObject.GetComponent<AudioSource>();
        audioSource.volume = value;
    }
}



