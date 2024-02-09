using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
	[SerializeField, Range(0.1f, 5.0f)]
	float mouseSensitivity = 2.5f;
	[SerializeField, Range(0.1f, 10.0f)]
	float movementSpeed = 5.0f;

	float _yaw = 0.0f;
	float _pitch = 0.0f;
	Vector3 _position;
	Vector3 _originalPosition;
	Quaternion _originalRotation;

	// getters and setters for UI
	public void SetMouseSensitivity(float value) { mouseSensitivity = value; }
	public float GetMouseSensitivity() { return mouseSensitivity; }
	
	public void SetMovementSpeed(float value) { movementSpeed = value; }
	public float GetMovementSpeed() { return movementSpeed; }

	void Start()
	{
		_originalPosition = transform.position;
		_originalRotation = transform.rotation;
		_position = transform.position;
		_yaw = transform.localRotation.eulerAngles.y;
		_pitch = transform.localRotation.eulerAngles.x;
	}

	void Update()
	{
		// press "R" to reset the camera
		if (Keyboard.current.rKey.wasPressedThisFrame)
		{
			transform.position = _originalPosition;
			transform.rotation = _originalRotation;
			_position = _originalPosition;
			_yaw = transform.localRotation.eulerAngles.y;
			_pitch = transform.localRotation.eulerAngles.x;
		}

		// unlock the cursor if right mouse button is released
		if (Mouse.current.rightButton.wasReleasedThisFrame)
			Cursor.lockState = CursorLockMode.None;

		// move and/or rotate mouse if left button is pressed
		if (!Mouse.current.rightButton.IsPressed())
			return;

		// lock the cursor if right mouse button is pressed
		if (Mouse.current.rightButton.wasPressedThisFrame)
			Cursor.lockState = CursorLockMode.Locked;

		// rotate camera
		float mouseAxisX = Mouse.current.delta.x.ReadValue();
		float mouseAxisY = Mouse.current.delta.y.ReadValue();
		float mouseX = mouseAxisX * mouseSensitivity / 100.0f;
		float mouseY = mouseAxisY * mouseSensitivity / 100.0f;

		_yaw += mouseX;
		_pitch -= mouseY;
		_pitch = Mathf.Clamp(_pitch, -90.0f, 90.0f);

		transform.localRotation = Quaternion.Euler(_pitch, _yaw, 0.0f);

		// move camera
		if (Keyboard.current.wKey.IsPressed()) // forward
			_position += transform.forward * movementSpeed * Time.deltaTime;
		else if (Keyboard.current.sKey.IsPressed()) // backward
			_position -= transform.forward * movementSpeed * Time.deltaTime;

		if (Keyboard.current.aKey.IsPressed()) // left
			_position -= transform.right * movementSpeed * Time.deltaTime;
		else if (Keyboard.current.dKey.IsPressed()) // right
			_position += transform.right * movementSpeed * Time.deltaTime;

		if (Keyboard.current.qKey.IsPressed()) // down
			_position -= transform.up * movementSpeed * Time.deltaTime;
		else if (Keyboard.current.eKey.IsPressed()) // up
			_position += transform.up * movementSpeed * Time.deltaTime;

		transform.localPosition = _position;
	}
}
