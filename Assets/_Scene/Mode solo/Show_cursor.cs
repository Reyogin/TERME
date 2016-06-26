using UnityEngine;
using System.Collections;

public class Show_cursor : MonoBehaviour {

    public bool show;
	// Use this for initialization
	void Start () {
        Cursor.visible = show;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
