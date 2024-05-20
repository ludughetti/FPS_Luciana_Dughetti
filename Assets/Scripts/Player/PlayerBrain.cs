using UnityEngine;

public class PlayerBrain : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private PlayerController playerMovement;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private PlayerCombat playerCombat;
    [SerializeField] private GameController gameController;
    [SerializeField] private CharacterHealth playerHealth;

    private void OnEnable()
    {
        inputReader.OnMovementInput += HandleMovementInput;
        inputReader.OnCameraInput += HandleCameraInput;
        inputReader.OnJumpInput += HandleJumpInput;
        inputReader.OnShootInput += HandleShootInput;
        playerHealth.OnDeath += TriggerEndgameOnDeath;
    }

    private void OnDisable()
    {
        inputReader.OnMovementInput -= HandleMovementInput;
        inputReader.OnCameraInput -= HandleCameraInput;
        inputReader.OnJumpInput -= HandleJumpInput;
        inputReader.OnShootInput -= HandleShootInput;
        playerHealth.OnDeath -= TriggerEndgameOnDeath;
    }

    private void HandleMovementInput(Vector2 input)
    {
        playerMovement.SetMovement(new Vector3(input.x, 0f, input.y));
    }

    private void HandleCameraInput(Vector2 input)
    {
        cameraController.SetMouseInput(input);
    }

    private void HandleJumpInput()
    {
        playerMovement.Jump();
    }

    private void HandleShootInput()
    {
        playerCombat.Attack();
    }

    private void TriggerEndgameOnDeath()
    {
        gameController.TriggerEndgameScreen(false);
    }
}
