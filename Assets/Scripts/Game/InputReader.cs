using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public event Action<Vector2> OnMovementInput = delegate { };
    public event Action<Vector2> OnCameraInput = delegate { };
    public event Action OnJumpInput = delegate { };
    public event Action OnShootInput = delegate { };
    public event Action OnPauseInput = delegate { };
    public event Action OnVolumeUpInput = delegate { };
    public event Action OnVolumeDownInput = delegate { };

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
        if (context.started)
            OnJumpInput.Invoke();
    }

    public void HandleShootInput(InputAction.CallbackContext context)
    {
        if(context.started)
            OnShootInput.Invoke();
    }

    public void HandlePauseInput(InputAction.CallbackContext context)
    {
        if (context.started)
            OnPauseInput.Invoke();
    }

    public void HandleVolumeUpInput(InputAction.CallbackContext context)
    {
        Debug.Log("Volume up");
        if (context.started)
            OnVolumeUpInput.Invoke();
    }

    public void HandleVolumeDownInput(InputAction.CallbackContext context)
    {
        Debug.Log("Volume down");
        if (context.started)
            OnVolumeDownInput.Invoke();
    }
}