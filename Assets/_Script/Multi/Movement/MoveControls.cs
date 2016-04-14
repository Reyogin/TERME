using UnityEngine;
using UnityEngine.Networking;
using System.Collections;


public class MoveControls : NetworkBehaviour
{
    private Transform playerTransform;
    //private Rigidbody rigidbody;
    private float coeffMove = 3.0f;
    private float jumpCoeff = 5.0f;
    private float m_Damping = 0.35f;
    private bool isRunning;

    private readonly int m_HashHorizontalPara = Animator.StringToHash("Horizontal");
    private readonly int m_HashVerticalPara = Animator.StringToHash("Vertical");
    //private bool isGrounded;
    //private bool input;
    [SerializeField]
    private float walkspeed;
    [SerializeField]
    private float runspeed;
    [SerializeField]
    float m_GroundCheckDistance = 0f;
    Animator m_animator;
    private float speed;



    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
        {
            playerTransform = GetComponent<Transform>();
            //rigidbody = GetComponent<Rigidbody>();
            m_animator = GetComponent<Animator>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            UpdateAnimator();
            Move(out speed);
        }
    }

    void Move(out float speed)
    {
        speed = this.speed;
        if (base.isLocalPlayer)
        {
            bool leftshift = Input.GetKey(KeyCode.LeftShift);
            speed = leftshift ? runspeed : walkspeed;
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 move = new Vector2(horizontal, vertical).normalized;

            transform.Translate(move.x * Time.deltaTime * coeffMove * speed, Input.GetAxis("Jump") * Time.deltaTime * jumpCoeff, move.y * coeffMove * speed * Time.deltaTime);
            jump();
        }
    }

    void UpdateAnimator()
    {
        if (!isLocalPlayer)
            return;

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
            //rigidbody.drag = 0.1f * Time.deltaTime;

        }

    }
    /*void CheckGround()
    {
        RaycastHit hitInfo;
        Ray isgrounded = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(isgrounded, out hitInfo, m_GroundCheckDistance))
        {
            if (hitInfo.collider.tag == "Plane")
                isGrounded = true;
            else
                isGrounded = false;
        }
    }*/
}
