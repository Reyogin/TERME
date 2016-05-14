using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class all : MonoBehaviour
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
        
        if (value)
        {
            AudioListener.pause = false;
        }
        else
        {

            AudioListener.pause = true;
        }


    }
}
