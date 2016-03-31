using UnityEngine;
using System.Collections;

public class Change_Scene : MonoBehaviour {

	
	public void ChangeToScene (string sceneToChangeTo) {
        Application.LoadLevel(sceneToChangeTo);
	}
}
