using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class LocomotionSMB : StateMachineBehaviour
{
    Animator m_animator;
    public float m_Damping = 0.35f;
    bool m_IsJumping;
    bool m_IsRunning;/*
    public float coeffMove = 3.0f;
    private float walkspeed = 1.0f;
    private float runspeed = 10.0f;//doesn't seem to work
    private bool isrunning;
    float speed;*/

    private readonly int m_HashHorizontalPara = Animator.StringToHash("Horizontal");
    private readonly int m_HashVerticalPara = Animator.StringToHash("Vertical");

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /*isrunning = Input.GetKey(KeyCode.LeftShift);

        speed = isrunning ? runspeed : walkspeed;*/

        ///Break cette fonction pour tester ce qui ne va pas

        float horizontal = Input.GetAxis("Horizontal")/* * speed * coeffMove*/;
        float vertical = Input.GetAxis("Vertical")/* * speed * coeffMove*/;

        Vector2 input = new Vector2(horizontal, vertical);//.normalized;

        animator.SetFloat(m_HashHorizontalPara, input.x, m_Damping, Time.deltaTime);
        animator.SetFloat(m_HashVerticalPara, input.y, m_Damping, Time.deltaTime);


    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
