using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public event Action<Vector2> OnMovementInput = delegate { };
    public event Action<Vector2> OnCameraInput = delegate { };
    public event Action OnJumpInput = delegate { };
    public event Action OnShootInput = delegate { };

    public void HandleMovementInput(InputAction.CallbackContext context)
    {
        OnMovementInput.Invoke(context.ReadValue<Vector2>());
    }

    public void HandleCameraInput(InputAction.CallbackContext context)
    {
        OnCameraInput.Invoke(context.ReadValue<Vector2>());
    }

    public void HandleJumpInput(InputAction.CallbackContext context)
    {
        OnJumpInput.Invoke();
    }

    public void HandleShootInput(InputAction.CallbackContext context)
    {
        OnShootInput.Invoke();
    }
}