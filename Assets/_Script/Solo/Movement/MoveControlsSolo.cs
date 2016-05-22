using UnityEngine;
using System.Collections;


public class MoveControlsSolo : MonoBehaviour
{
    private Transform playerTransform;
    //private Rigidbody rigidbody;
    private float coeffMove = 3.0f;
    private float jumpCoeff = 40.0f;
    private float m_Damping = 0.35f;
    private bool isRunning;
    private float isGroundedRaylength = 0.1f;
    //private LayerMask layerMaskforGrounded;

    private readonly int m_HashHorizontalPara = Animator.StringToHash("Horizontal");
    private readonly int m_HashVerticalPara = Animator.StringToHash("Vertical");

    //private bool isGrounded;
    private bool input;
    private float walkspeed = 0.8f;
    private float runspeed = 1.6f;
    Animator m_animator;
    float speed;


    // Use this for initialization
    void Start()
    {
        //layerMaskforGrounded = LayerMask.NameToLayer("Environnement");
        playerTransform = GetComponent<Transform>();
        //rigidbody = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();
        //input = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimator();
        Move(out speed);
    }

    void Move(out float speed)
    {
        speed = this.speed;
        bool leftshift = Input.GetKey(KeyCode.LeftShift);
        speed = leftshift ? runspeed : walkspeed;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical).normalized;

        transform.Translate(move.x * Time.deltaTime * coeffMove * speed, /*Input.GetAxis("Jump") * Time.deltaTime * jumpCoeff*/0, move.y * coeffMove * speed * Time.deltaTime);
        jump();

    }

    void UpdateAnimator()
    {
        ///Gère les sauts
        if (Input.GetKey(KeyCode.Space) )//|| !IsGrounded)
            m_animator.SetBool("IsGrounded", false);
        else
            m_animator.SetBool("IsGrounded", true);

        ///Gestion des Inputs (walking/Running)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 moves = new Vector2(horizontal, vertical);
        input = Mathf.Abs(horizontal) > 0 || Mathf.Abs(vertical) > 0;// || Input.GetKeyDown(KeyCode.Space);

        if (!input)
            m_animator.SetBool("Idle", true);
        else
        {
            m_animator.SetBool("Idle", false);
            if (Input.GetKey(KeyCode.LeftShift))
                m_animator.SetBool("Run", true);
            else
                m_animator.SetBool("Run", false);
            m_animator.SetFloat(m_HashHorizontalPara, moves.x, m_Damping, Time.deltaTime);
            m_animator.SetFloat(m_HashVerticalPara, moves.y, m_Damping, Time.deltaTime);
        }
    }

    void jump()
    {

        bool isJumping = Input.GetKeyDown(KeyCode.Space);

        if (isJumping)
            transform.Translate(0, Input.GetAxis("Jump") * Time.deltaTime * jumpCoeff, 0);
    }
}
