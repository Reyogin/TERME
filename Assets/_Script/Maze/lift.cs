using UnityEngine;
using System.Collections;

public class lift : MonoBehaviour
{

    private bool pressedButton = false;
    private bool isElevatorUp = false;
    [SerializeField]
    GameObject target;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Nez")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                while (!isElevatorUp)
                    if (target.transform.position.y > 27.5)
                        isElevatorUp = true;
                    else
                        target.transform.TransformVector(Vector3.up);

            }
            /*else
            {
                pressedButton = false;
                isElevatorUp = false;
            }

            target.GetComponent<Animator>().SetBool("isUp", isElevatorUp);*/



        }

    }
    /* void OnMouseOver()
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
     }*/
}
