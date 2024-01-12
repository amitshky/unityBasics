using UnityEngine;
using UnityEngine.InputSystem;

public class camera : MonoBehaviour
{
	[SerializeField, Range(0.1f, 10.0f)]
	float mouseSensitivity = 2.5f;
	[SerializeField, Range(0.1f, 20.0f)]
	float movementSpeed = 2f;


	float _yaw = 0.0f;
	float _pitch = 0.0f;
	Vector3 _position;


	void LockCursor(bool isLocked)
	{
		if (isLocked)
			Cursor.lockState = CursorLockMode.Locked;
		else
			Cursor.lockState = CursorLockMode.None;
	}

	void Start()
	{
		_position = transform.position;
	}

	void Update()
	{
		if (Mouse.current.leftButton.wasReleasedThisFrame)
			LockCursor(false);

		// move and/or rotate mouse if left button is pressed
		if (!Mouse.current.leftButton.IsPressed())
			return;

		if (Mouse.current.leftButton.wasPressedThisFrame)
			LockCursor(true);

		// rotate camera
		float mouseAxisX = Mouse.current.delta.x.ReadValue();
		float mouseAxisY = Mouse.current.delta.y.ReadValue();
		float mouseX = mouseAxisX * mouseSensitivity * Time.deltaTime;
		float mouseY = mouseAxisY * mouseSensitivity * Time.deltaTime;

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
