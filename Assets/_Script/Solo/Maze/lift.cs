using UnityEngine;
using System.Collections;

public class lift : MonoBehaviour
{

    private bool pressedButton = false;
    private bool isElevatorUp = false;
    private float liftSpeed = 3f;
    [SerializeField]
    GameObject target;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Nez")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject Player = other.transform.parent.parent.gameObject;
                Player.transform.position = new Vector3((float)1.062, (float)28.993, (float)-11.363);
                //position TP= (1.062, 28.993, -11.363);
                /*
                while (!isElevatorUp)
                {
                    while (target.transform.position.y > 27.5)
                    {
                        Debug.Log("la plateforme va monter");
                        target.transform.Translate(Vector3.up * liftSpeed * Time.deltaTime);
                    }

                }
                /else
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
}

