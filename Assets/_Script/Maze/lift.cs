using UnityEngine;
using System.Collections;

public class lift : MonoBehaviour
{

    private bool pressedButton = false;
    private bool isElevatorUp = false;
    [SerializeField]
    GameObject target;

    void OnMouseOver()
    {
        pressedButton = true;
    }

    void OnMouseExit()
    {
        pressedButton = false;
    }

    void OnMouseDown()
    {
        if (!pressedButton)
            return;

        isElevatorUp = !isElevatorUp;
        target.GetComponent<Animator>().SetBool("isUp", isElevatorUp);
    }
}
