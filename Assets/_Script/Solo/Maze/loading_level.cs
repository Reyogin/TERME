using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loading_level : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter()
    {
        SceneManager.LoadScene("Level 2");
        //Application.LoadLevel("Level 2");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
