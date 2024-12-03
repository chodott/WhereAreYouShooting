using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MoveController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private CharacterController characterController;

    private Vector3 moveDirection;
    private Vector2 moveInput;
    private Vector2 rotateInput;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        moveDirection = transform.right * moveInput.x + transform.forward * moveInput.y;
        moveDirection.Normalize();
        characterController.Move(moveDirection);

        transform.Rotate(Vector3.up, rotateInput.x);
    }

    public void OnMove(InputValue input) => moveInput = input.Get<Vector2>();
    public void OnCameraRotate(InputValue input) => rotateInput = input.Get<Vector2>();
}
