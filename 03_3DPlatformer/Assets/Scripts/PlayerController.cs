using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 10.0f;
    [SerializeField]
    private float turnSpeed = 1.0f;
    [SerializeField]
    private float aimSpeed = 0.5f;
    [SerializeField]
    private float jumpSpeed = 10.0f;
    [SerializeField]
    private GroundCheck groundCheck = null;
    [SerializeField]
    private Animator animator = null;

    [SerializeField]
    private Transform cameraTarget = null;
    [SerializeField]
    private bool invertY = false;
    [SerializeField]
    private float maxPitchAngle = 70.0f;
    [SerializeField]
    private float minPitchAngle = -70.0f;

    private Rigidbody rigidbody = null;
    private PlayerInput playerInput = null;
    private InputAction moveInput = null;
    private InputAction lookInput = null;
    private InputAction jumpInput = null;

    private Vector3 moveVelocity = Vector3.zero;
    private Vector3 turnVelocity = Vector3.zero;
    private float pitchRotation = 0.0f;
    private bool isJumping = false;
    private bool isFalling = false;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerInput = new PlayerInput();
        moveInput = playerInput.Player.Move;
        lookInput = playerInput.Player.Look;
        jumpInput = playerInput.Player.Jump;
        jumpInput.performed += OnJump;
    }

    private void OnEnable()
    {
        moveInput.Enable();
        lookInput.Enable();
        jumpInput.Enable();

        // hides cursor in game
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        moveInput.Disable();
        lookInput.Disable();
        jumpInput.Disable();

        // unhides cursor in game
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = moveInput.ReadValue<Vector2>();
        Vector2 look = lookInput.ReadValue<Vector2>();

        // wasd move in direction of facing
        Vector3 fwd = transform.forward;
        Vector3 right = transform.right;
        fwd.y = 0.0f;
        right.y = 0.0f;
        moveVelocity = ((fwd * move.y) + (right * move.x)) * moveSpeed;

        //look input from the mouse
        turnVelocity.y = look.x * turnSpeed;

        if(invertY)
        {
            look.y *= -1;
        }

        pitchRotation = Mathf.Clamp(pitchRotation + look.y * aimSpeed * Time.deltaTime, minPitchAngle, maxPitchAngle);

        if (!groundCheck.IsGrounded && rigidbody.linearVelocity.y < 0.1f)
        {
            isFalling = false;
            isJumping = false;
        }
        else if(rigidbody.linearVelocity.y < -0.1f)
        {
            isFalling = true;
            isJumping = false;
        }

        animator.SetFloat("FwdSpeed", move.y);
        animator.SetFloat("SideSpeed", move.x);
        animator.SetBool("IsJumping", isJumping);
        animator.SetBool("IsFalling", isFalling);

    }

    private void FixedUpdate()
    {
        moveVelocity.y = rigidbody.linearVelocity.y;
        rigidbody.linearVelocity = moveVelocity;
        rigidbody.angularVelocity = turnVelocity;
    }

    private void LateUpdate()
    {
        cameraTarget.localRotation = Quaternion.Euler(pitchRotation, 0.0f, 0.0f);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (groundCheck.IsGrounded && rigidbody.linearVelocity.y <= 0.1f)
        {
            Vector3 jumpVelocity = rigidbody.linearVelocity;
            jumpVelocity.y = jumpSpeed;
            rigidbody.linearVelocity = jumpVelocity;
            //Debug.Log("I jumped!");

            isJumping = true;
            isFalling = false;
        }
        else
        {
            //Debug.Log("I didnt jump.");
        }
    }
}
