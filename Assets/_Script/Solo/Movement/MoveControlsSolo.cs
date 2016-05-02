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

    private readonly int m_HashHorizontalPara = Animator.StringToHash("Horizontal");
    private readonly int m_HashVerticalPara = Animator.StringToHash("Vertical");

    //private bool isGrounded;
    //private bool input;
    private float walkspeed = 0.8f;
    private float runspeed = 1.6f;
    Animator m_animator;
    float speed;


    // Use this for initialization
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        //rigidbody = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();
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
        bool leftshit = Input.GetKey(KeyCode.LeftShift);
        bool input = Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0; //|| Input.GetAxis("Jump") >= Mathf.Abs(1);
        bool jump = Input.GetKeyDown(KeyCode.Space);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 input2 = new Vector2(horizontal, vertical);

        m_animator.SetFloat(m_HashHorizontalPara, input2.x, m_Damping, Time.deltaTime);
        m_animator.SetFloat(m_HashVerticalPara, input2.y, m_Damping, Time.deltaTime);

        isRunning = leftshit && input;
        if (isRunning)
            m_animator.SetBool("IsRunning", true);
        else
            m_animator.SetBool("IsRunning", false);

        if (!jump)
            m_animator.SetBool("IsGrounded", true);
        else
            m_animator.SetBool("IsGrounded", false);

    }

    void jump()
    {

        bool isJumping = Input.GetKeyDown(KeyCode.Space);

        if (isJumping)
        {
            transform.Translate(0, Input.GetAxis("Jump") * Time.deltaTime * jumpCoeff, 0);
        }
    }

}
