using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveAndSprint : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction sprintAction;

    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float sprintSpeed = 10f;

    private Rigidbody rb;
    private bool isSprinting = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        moveAction = playerInput.actions.FindAction("Move");
        sprintAction = playerInput.actions.FindAction("Sprint");

        sprintAction.started += ctx => isSprinting = true;
        sprintAction.canceled += ctx => isSprinting = false;
    }

    void FixedUpdate()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        float currentSpeed = isSprinting ? sprintSpeed : walkSpeed;

        Vector3 move = new Vector3(input.x, 0, input.y) * currentSpeed;
        Vector3 velocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
        rb.linearVelocity = velocity;
    }

    void OnDestroy()
    {
        sprintAction.started -= ctx => isSprinting = true;
        sprintAction.canceled -= ctx => isSprinting = false;
    }
}
