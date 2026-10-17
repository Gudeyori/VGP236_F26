using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GroundCheck groundCheck = null;

    [SerializeField]
    private float moveSpeed = 5.0f;

    [SerializeField]
    private float jumpSpeed = 10.0f;

    [SerializeField]
    private Rigidbody2D rigidBody = null;
    private float desiredSpeed = 0.0f;

    private Vector3 lastSafePosition = Vector3.zero;

    // player input hookups
    private PlayerInput playerInput = null;
    private InputAction moveAction = null;
    private InputAction jumpAction = null;

    private void Awake()
    {
        playerInput = new PlayerInput();
        moveAction = playerInput.Player.Move;
        jumpAction = playerInput.Player.Jump;
        jumpAction.performed += OnJump;
        lastSafePosition = transform.position;
    }

    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        desiredSpeed = moveAction.ReadValue<Vector2>().x * moveSpeed;

        if (groundCheck.IsGrounded())
        {
            lastSafePosition = transform.position;
        }
    }

    private void FixedUpdate()
    {
        rigidBody.linearVelocityX = desiredSpeed;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (groundCheck.IsGrounded() && rigidBody.linearVelocityY < 0.1f)
        {
            rigidBody.linearVelocityY = jumpSpeed;
        }
    }

    public void RespawnPlayer()
    {
        transform.position = lastSafePosition;
        rigidBody.linearVelocity = Vector2.zero;
    }
}
