using UnityEngine;
using UnityEngine.InputSystem;

public class camera : MonoBehaviour
{
	[SerializeField]
	float mouseSensitivity = 5f;
	[SerializeField]
	float movementSpeed = 10f;


	bool isCursorLocked = true;
	float yaw = 0.0f;
	float pitch = 0.0f;

	Vector3 position;


	void LockCursor(bool isLocked)
	{
		position = transform.position;
		if (isLocked)
			Cursor.lockState = CursorLockMode.Locked;
		else
			Cursor.lockState = CursorLockMode.None;
	}

	void Start()
	{
		LockCursor(isCursorLocked);
	}

	void Update()
	{
		if (Keyboard.current.altKey.IsPressed())
		{
			isCursorLocked = !isCursorLocked;
			LockCursor(isCursorLocked);
		}

		// rotate camera
		float mouseAxisX = Mouse.current.delta.x.ReadValue();
		float mouseAxisY = Mouse.current.delta.y.ReadValue();
		float mouseX = mouseAxisX * mouseSensitivity * Time.deltaTime;
		float mouseY = mouseAxisY * mouseSensitivity * Time.deltaTime;

		yaw += mouseX;
		pitch -= mouseY;
		pitch = Mathf.Clamp(pitch, -90.0f, 90.0f);

		transform.localRotation = Quaternion.Euler(pitch, yaw, 0.0f);

		// move camera
		if (Keyboard.current.wKey.IsPressed()) // forward
			position += transform.forward * movementSpeed * Time.deltaTime;
		else if (Keyboard.current.sKey.IsPressed()) // backward
			position -= transform.forward * movementSpeed * Time.deltaTime;
		
		if (Keyboard.current.aKey.IsPressed()) // left
			position -= transform.right * movementSpeed * Time.deltaTime;
		else if (Keyboard.current.dKey.IsPressed()) // right
			position += transform.right * movementSpeed * Time.deltaTime;
		
		if (Keyboard.current.qKey.IsPressed()) // down
			position -= transform.up * movementSpeed * Time.deltaTime;
		else if (Keyboard.current.eKey.IsPressed()) // up
			position += transform.up * movementSpeed * Time.deltaTime;

		transform.localPosition = position;
	}
}
