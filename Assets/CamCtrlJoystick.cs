using UnityEngine;
using System.Collections;


public class CamCtrlJoystick : MonoBehaviour
{
    private Transform playerTransform;
    private GameObject cam;
    private float rotationSpeed = 50.0f;

    private float minx = -70.0f;
    private float maxx = 55.0f;
    private Vector3 v3rotate = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        this.cam = gameObject.GetComponentInChildren<Camera>().gameObject;
        cam.transform.localEulerAngles = v3rotate;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetAxis("RightJoystickY"));
        GetInput();
    }

    void GetInput()
    {
        transform.Rotate(0.0f, Input.GetAxis("RightJoystickX") * rotationSpeed * Time.deltaTime, 0.0f);
        v3rotate.x = Input.GetAxis("RightJoystickY") * rotationSpeed * Time.deltaTime;
        v3rotate.x = Mathf.Clamp(v3rotate.x, minx, maxx);
        this.cam.transform.Rotate(v3rotate);
    }
}