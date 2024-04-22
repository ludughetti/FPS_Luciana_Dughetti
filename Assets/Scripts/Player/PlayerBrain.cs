using UnityEngine;

public class PlayerBrain : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private PlayerController playerMovement;
    [SerializeField] private CameraController cameraController;

    private void OnEnable()
    {
        inputReader.OnMovementInput += HandleMovementInput;
        inputReader.OnCameraInput += HandleCameraInput;
    }

    private void OnDisable()
    {
        inputReader.OnMovementInput -= HandleMovementInput;
        inputReader.OnCameraInput -= HandleCameraInput;
    }

    private void HandleMovementInput(Vector2 input)
    {
        playerMovement.SetMovement(new Vector3(input.x, 0f, input.y));
    }

    private void HandleCameraInput(Vector2 input)
    {
        cameraController.SetMouseInput(input);
    }
}
