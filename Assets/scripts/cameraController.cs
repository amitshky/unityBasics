using UnityEngine;
using UnityEngine.InputSystem;

public class camera : MonoBehaviour
{
	[SerializeField]
	Transform cameraTransform;

	[SerializeField]
	float mouseSensitivity = 5f;

	float yaw = 0.0f;
	float pitch = 0.0f;

	bool isCursorLocked = true;

	void LockCursor(bool isLocked)
	{
		if (isLocked)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		else
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}

	void Start()
	{
		LockCursor(isCursorLocked);
	}

	void Update()
	{
		float mouseAxisX = Mouse.current.delta.x.ReadValue();
		float mouseAxisY = Mouse.current.delta.y.ReadValue();
		float mouseX = mouseAxisX * mouseSensitivity * Time.deltaTime;
		float mouseY = mouseAxisY * mouseSensitivity * Time.deltaTime;

		yaw += mouseX;
		pitch -= mouseY;
		transform.localRotation = Quaternion.Euler(pitch, yaw, 0.0f);

		if (Keyboard.current.altKey.IsPressed())
		{
			isCursorLocked = !isCursorLocked;
			LockCursor(isCursorLocked);
		}
	}
}
