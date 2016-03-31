using UnityEngine;
using UnityEngine.Networking;
using System.Collections;


public class MoveControls : NetworkBehaviour
{
    private Transform playerTransform;
    private Rigidbody rigidbody;
    public float coeffMove = 3.0f;
    public float jumpCoeff = 5.0f;
    private bool isRunning;
    //private bool isGrounded;
    //private bool input;
    [SerializeField]
    private float walkspeed;
    [SerializeField]
    private float runspeed;
    [SerializeField]
    float m_GroundCheckDistance = 0f;
    Animator m_animator;
    float speed;


    // Use this for initialization
    void Start()
    {
        if (base.isLocalPlayer)
        {
            playerTransform = GetComponent<Transform>();
            rigidbody = GetComponent<Rigidbody>();
            m_animator = GetComponent<Animator>();


        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            UpdateAnimator();
            GetInput(out speed);
        }
    }

    void GetInput(out float speed)
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
        if (base.isLocalPlayer)
        {
            bool leftshit = Input.GetKey(KeyCode.LeftShift);
            bool input = Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0; //|| Input.GetAxis("Jump") >= Mathf.Abs(1);
            bool jump = Input.GetKeyDown(KeyCode.Space);

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
    }

    void jump()
    {
        if (base.isLocalPlayer)
        {
            bool isJumping = Input.GetKeyDown(KeyCode.Space);

            if (isJumping)
            {
                transform.Translate(0, Input.GetAxis("Jump") * Time.deltaTime * jumpCoeff, 0);
                //rigidbody.drag = 0.1f * Time.deltaTime;

            }
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
