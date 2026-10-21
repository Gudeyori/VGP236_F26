using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Canvas playerInfo = null;

    [SerializeField]
    private Animator animator = null;

    [SerializeField]
    private GroundCheck groundCheck = null;

    [SerializeField]
    private float moveSpeed = 5.0f;

    [SerializeField]
    private float jumpSpeed = 10.0f;

    [SerializeField]
    private Rigidbody2D rigidBody = null;
    private float desiredSpeed = 0.0f;
    private float direction = 1.0f;
    private bool isJumping = false;
    private bool isFalling = false;

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
        animator.SetFloat("Direction", direction);
        animator.SetFloat("Speed", 0.0f);
        playerInfo.worldCamera = Camera.main;
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
            if(rigidBody.linearVelocityY < 0.1f)
            {
                isFalling = false;
            }
        }
        else if(rigidBody.linearVelocityY < 0.0f)
        {
            isFalling = true;
            isJumping = false;
        }

        if (desiredSpeed < 0.0f)
        {
            direction = -1.0f;
        }
        else if (desiredSpeed > 0.0f)
        {
            direction = 1.0f;
        }

        float currentSpeed = rigidBody.linearVelocityX;
        animator.SetFloat("Direction", direction);
        animator.SetFloat("Speed", Mathf.Abs(currentSpeed));
        animator.SetBool("IsJumping", isJumping);
        animator.SetBool("IsFalling", isFalling);
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
            isJumping = true;
        }
    }

    public void RespawnPlayer()
    {
        Vector3 spawnPosition;
        if(!CheckPointManager.Instance.TryGetLastCheckpointPosition(out spawnPosition))
        {
            spawnPosition = lastSafePosition;
        }
        transform.position = spawnPosition;
        rigidBody.linearVelocity = Vector2.zero;
    }
}
