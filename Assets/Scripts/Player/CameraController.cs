using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float sensibilityX = 5f;
    [SerializeField] private float sensibilityY = 5f;
    [SerializeField] private Transform orientation;

    private float _inputX = 0f;
    private float _inputY = 0f;
    private float _rotationX = 0f;
    private float _rotationY = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        float mouseX = _inputX * Time.deltaTime * sensibilityX;
        float mouseY = _inputY * Time.deltaTime * sensibilityY;

        _rotationY += mouseX;

        _rotationX -= mouseY;
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);

        transform.rotation = Quaternion.Euler(_rotationX, _rotationY, 0f);
        orientation.rotation = Quaternion.Euler(0f, _rotationY, 0f);
    }

    public void SetMouseInput(Vector2 input)
    {
        _inputX = input.x;
        _inputY = input.y;
    }
}
