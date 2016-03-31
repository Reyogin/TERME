using UnityEngine;
using System.Collections;

public class playplaymusic : MonoBehaviour {
    
        void Awake()
    {
            GameObject sound = GameObject.Find("Music");

            if (sound == this.gameObject)
            {
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        
    }
}
