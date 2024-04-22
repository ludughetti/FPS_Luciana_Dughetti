using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform orientation;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float movementSpeed = 10f;

    private Vector3 _moveDirection;

    private void Update()
    {
        MovePlayer();
    }

    public void SetMovement(Vector3 input)
    {
        _moveDirection = input;
    }

    private void MovePlayer()
    {
        Vector3 movement = orientation.right * _moveDirection.x + orientation.forward * _moveDirection.z;

        characterController.Move(movement * Time.deltaTime * movementSpeed);
    }
}
