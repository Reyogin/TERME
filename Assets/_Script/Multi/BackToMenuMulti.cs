using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class BackToMenuMulti : NetworkBehaviour
{

    // Use this for initialization

    public void ChanteToMenuMulti()
    {

            Network.Disconnect();
            Application.LoadLevel("Mode menu");

    }

}
