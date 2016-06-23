using UnityEngine;
using System.Collections;

public class WeaponInHand : MonoBehaviour
{

    public Transform parent;
    private Transform weapon;
    // Use this for initialization
    void Start()
    {
        weapon = GetComponent<Transform>();
        weapon.parent = this.parent;
    }

}
