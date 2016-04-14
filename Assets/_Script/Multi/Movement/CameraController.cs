using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CameraController : NetworkBehaviour
{
    private Transform playerTransform;
    private Camera cam;
    private float rotationSpeed = 150.0f;

    private float minx = -70.0f;
    private float maxx = 55.0f;
    private Vector3 v3rotate = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        this.cam = gameObject.GetComponentInChildren<Camera>();
        cam.transform.localEulerAngles = v3rotate;

        if (!isLocalPlayer)
        {
            this.cam.enabled = false;//  SetActive(false);
            return;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
            GetInput();
    }

    void GetInput()
    {
        if(isLocalPlayer)
        {
            transform.Rotate(0.0f, Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime, 0.0f);
            v3rotate.x -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            v3rotate.x = Mathf.Clamp(v3rotate.x, minx, maxx);
            this.cam.transform.localEulerAngles = v3rotate;
        }
    }
}
