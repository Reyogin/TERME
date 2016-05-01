using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    public GameObject EscapePann;
    public bool isPause;
    public GameObject reticule;
	// Use this for initialization
	void Start () {
        isPause = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isPause)
        {
            PauseGame(true);
            Cursor.visible = true;
            reticule.SetActive(false);
        }
        else
        {
            PauseGame(isPause);
            Cursor.visible = false;

            reticule.SetActive(true);
        }

        if(Input.GetButtonDown("Cancel"))
        {
            SwitchPause();
        }

	}
    void PauseGame(bool state)
    {
        if(state)
        {
            Time.timeScale = 0.0f; //pause
        }
        else
        {
            Time.timeScale = 1.0f;//unpause
        }
        EscapePann.SetActive(state);
    }

    public void SwitchPause()
    {
        isPause = !isPause;
    }
}
