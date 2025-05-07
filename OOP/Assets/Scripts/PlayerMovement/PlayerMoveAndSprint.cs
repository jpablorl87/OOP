using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveAndSprint : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction sprintAction;
    private InputAction lookAction;

    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float rotateSpeed = 5f;
    [SerializeField] float sprintSpeed = 10f;

    private Rigidbody rb;
    private bool isSprinting = false;
    [SerializeField] private Transform cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        moveAction = playerInput.actions.FindAction("Move");
        sprintAction = playerInput.actions.FindAction("Sprint");
        lookAction = playerInput.actions.FindAction("Look");

        sprintAction.started += ctx => isSprinting = true;
        sprintAction.canceled += ctx => isSprinting = false;
    }

    void FixedUpdate()
    {
        Vector2 inputM = moveAction.ReadValue<Vector2>();
        Vector2 inputR = lookAction.ReadValue<Vector2>();

        float currentSpeed = isSprinting ? sprintSpeed : walkSpeed;

        Vector3 move = new Vector3(inputM.x, 0, inputM.y) * currentSpeed;

        /*Vector3 velocity = new Vector3(move.x, rb.linearVelocity.y, move.z);

        rb.linearVelocity = velocity;*/
        rb.MovePosition(rb.position + transform.forward * inputM.y * currentSpeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + transform.right * inputM.x * currentSpeed * Time.fixedDeltaTime);

        float rotationAmount = (inputR.x + cam.transform.rotation.y) * rotateSpeed * Time.fixedDeltaTime;
        Quaternion deltaR = Quaternion.Euler(0, rotationAmount, 0);
        rb.MoveRotation(rb.rotation * deltaR);
    }

    void OnDestroy()
    {
        sprintAction.started -= ctx => isSprinting = true;
        sprintAction.canceled -= ctx => isSprinting = false;
    }
}
