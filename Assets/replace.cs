using UnityEngine;
using System.Collections;

public class replace : MonoBehaviour {


    public GameObject one;
    public GameObject two;
    public GameObject three;
    static int character;

    // Use this for initialization
    void Start () {

        character = PlayerPrefs.GetInt("selectCharacter");
        //Network.Destroy(gameObject);
       // if (character == 1)
         //   Instantiate(one, this.transform.position, Quaternion.identity);
        
	}
   /* void CmdReplaceMe(GameObject newPlayerObject)
    {
        NetworkServer.Spawn(newPlayerObject);
        NetworkServer.ReplacePlayerForConnection(connectionToClient, newPlayerObject, playerControllerId);
    }*/
        // Update is called once per frame
        void Update () {
        Debug.Log(character);
    }
}
