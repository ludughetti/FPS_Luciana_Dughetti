using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform orientation;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpHeight = 10f;
    [SerializeField] private float gravity = -15.0f;
    [SerializeField] private float terminalVelocity = 53.0f;

    private Vector3 _moveDirection;
    private bool _isGrounded = false;
    private float _verticalVelocity = 0f;

    private void Update()
    {
        ApplyPhysics();
        IsGrounded();

        MovePlayer();
    }

    public void SetMovement(Vector3 input)
    {
        _moveDirection = input;
    }

    private void MovePlayer()
    {
        Vector3 movement = orientation.right * _moveDirection.x + orientation.forward * _moveDirection.z;

        characterController.Move(movement.normalized * (movementSpeed * Time.deltaTime)
            + new Vector3(0f, _verticalVelocity, 0f) * Time.deltaTime);
    }

    public void Jump()
    {
        Debug.Log("Jump executed");
        if (_isGrounded)
            _verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    private void IsGrounded()
    {
        _isGrounded = Physics.CheckSphere(transform.position, groundCheckRadius, groundMask);
    }

    private void ApplyPhysics()
    {
        // Apply gravity if player is in the air
        if (!_isGrounded && _verticalVelocity < terminalVelocity) 
            _verticalVelocity += gravity * Time.deltaTime;
    }
}
