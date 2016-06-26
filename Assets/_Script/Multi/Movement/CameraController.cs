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
        if (!isLocalPlayer)
        {
            foreach (Camera came in gameObject.transform.GetComponentsInChildren<Camera>())
                came.gameObject.SetActive(false);

            //desactive les canvas
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
            gameObject.transform.GetChild(5).gameObject.SetActive(false);
            gameObject.transform.GetChild(6).gameObject.SetActive(false);
            return;
        }
        playerTransform = gameObject.GetComponent<SelectionMult_Player>().PlayerPrefab.GetComponent<Transform>();
        this.cam = gameObject.GetComponent<SelectionMult_Player>().PlayerPrefab.GetComponentInChildren<Camera>();
        cam.transform.localEulerAngles = v3rotate;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
            GetInput();
    }

    void GetInput()
    {
        if (isLocalPlayer)
        {
            playerTransform.Rotate(0.0f, Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime, 0.0f);
            v3rotate.x -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            v3rotate.x = Mathf.Clamp(v3rotate.x, minx, maxx);
            this.cam.transform.localEulerAngles = v3rotate;
        }
    }
}
