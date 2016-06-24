using UnityEngine;
using System.Collections;

public class ControllerSelector : MonoBehaviour
{
    CameraControllerSolo keyboard_mouseScript;
    CamCtrlJoystick joystickScript;

    // Use this for initialization
    void Start()
    {
        keyboard_mouseScript = GetComponent<CameraControllerSolo>();
        joystickScript = GetComponent<CamCtrlJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        Select();
    }

    void Select()
    {
        if (Mathf.Abs(Input.GetAxis("Mouse X")) > 0 || Mathf.Abs(Input.GetAxis("Mouse Y")) > 0)
        {
            keyboard_mouseScript.enabled = true;
            joystickScript.enabled = false;
        }
        if (Mathf.Abs(Input.GetAxis("RightJoystickX")) > 0 || Mathf.Abs(Input.GetAxis("RightJoystickY")) > 0)
        {
            keyboard_mouseScript.enabled = false;
            joystickScript.enabled = true;
        }
    }
}
