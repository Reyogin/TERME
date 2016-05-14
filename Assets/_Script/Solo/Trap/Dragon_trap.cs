using UnityEngine;
using System.Collections;

public class Dragon_trap : MonoBehaviour
{

    public ParticleSystem part;
    private bool active;
    void Start()
    {
        Fire();

    }
    void OnParticleCollision(GameObject other)
    {
        if (other.transform.tag == "Player")
        {

        }
    }

    IEnumerator Fire()
    {
        while (true)
        {
            part.enableEmission = active;
            yield return new WaitForSeconds(5);
            active = !active;
        }

    }
}
