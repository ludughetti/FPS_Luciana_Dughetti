using UnityEngine;
using Input = UnityEngine.Input;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
	[SerializeField]
	Transform look;

	[Header("Player Movement")]
	[Tooltip("Move speed of the character in m/s")]
    [SerializeField]
    float moveSpeed = 4.0f;
	[Tooltip("Sprint speed of the character in m/s")]
    [SerializeField]
    float sprintSpeed = 6.0f;
	[Tooltip("Rotation speed of the character")]
    [SerializeField]
    float rotationSpeed = 1.0f;

	[Space(10)]
	[Tooltip("The height the player can jump")]
    [SerializeField] 
	float jumpHeight = 1.2f;
	[Tooltip("The character uses its own gravity value. The engine default is -9.81f")]
    [SerializeField] 
	float gravity = -15.0f;
    [SerializeField]
    float terminalVelocity = 53.0f;

	[Header("Player Grounded")]
	[Tooltip("If the character is grounded or not. Not part of the CharacterController built in grounded check")]
    [SerializeField]
    bool grounded = true;
	[Tooltip("Offset to mark feet position")]
    [SerializeField] 
	float groundedOffset = 0.85f;
	[Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
	[SerializeField]
	float groundedRadius = 0.5f;
	[Tooltip("What layers the character uses as ground")]
    [SerializeField] 
	LayerMask groundLayers;

	[Header("Camera Limits")]
    [SerializeField] 
	float minCameraAngle = -90F;
    [SerializeField] 
	float maxCameraAngle = 90F;

	private CharacterController _controller;

	private Quaternion _characterTargetRot;
	private Quaternion _cameraTargetRot;

	private float _verticalVelocity;

	private bool _sprint;
	private bool _jump;

	void Start()
	{
		_controller = GetComponent<CharacterController>();
		_characterTargetRot = transform.localRotation;
		_cameraTargetRot = look.localRotation;
	}
	void Update()
    {
        _jump = Input.GetKeyDown(KeyCode.Space);
        _sprint = Input.GetKey(KeyCode.LeftShift);
        GroundedCheck();
		JumpAndGravity();
		Move();
		LookRotation();
    }

	void GroundedCheck()
	{
		Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - groundedOffset, transform.position.z);
		grounded = Physics.CheckSphere(spherePosition, groundedRadius, groundLayers, QueryTriggerInteraction.Ignore);
	}

	void JumpAndGravity()
	{
		if (grounded && _jump)
		{
			// the square root of H * -2 * G = how much velocity needed to reach desired height
			_verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}
		else
		{
			// if we are not grounded, do not jump
			_jump = false;
		}

		// apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
		if (_verticalVelocity < terminalVelocity)
			_verticalVelocity += gravity * Time.deltaTime;
	}

	public void Move()
	{
		float hor = Input.GetAxis("Horizontal");
		float vert = Input.GetAxis("Vertical");

		Debug.Log($"Move values: x:{hor}, z:{vert}");

		Vector3 direction = new Vector3(hor, 0, vert);

		direction = direction.x * transform.right + direction.z * transform.forward;

		// set target speed based on move speed, sprint speed and if sprint is pressed
		float targetSpeed = _sprint ? sprintSpeed : moveSpeed;

		// move the player
		_controller.Move(direction.normalized * (targetSpeed * Time.deltaTime) + new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);
	}

	public void LookRotation()
	{
		float yRot = Input.GetAxis("Mouse X") * rotationSpeed;
		float xRot = Input.GetAxis("Mouse Y") * rotationSpeed;

		_characterTargetRot *= Quaternion.Euler(0f, yRot, 0f);
		_cameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);

		_cameraTargetRot = ClampRotationAroundXAxis(_cameraTargetRot);

		transform.localRotation = _characterTargetRot;
		look.localRotation = _cameraTargetRot;
	}

	Quaternion ClampRotationAroundXAxis(Quaternion q)
	{
		q.x /= q.w;
		q.y /= q.w;
		q.z /= q.w;
		q.w = 1.0f;

		float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
		angleX = Mathf.Clamp(angleX, minCameraAngle, maxCameraAngle);

		q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

		return q;
	}
}
