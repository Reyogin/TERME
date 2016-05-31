using UnityEngine;
using System.Collections;

public class Boomstick : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletspawn;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
            Shoot();
    }

    void Shoot()
    {
        Instantiate(bullet, bulletspawn.position, bulletspawn.rotation);
    }
}
