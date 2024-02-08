using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Clock : MonoBehaviour
{
	[SerializeField]
	Transform hourHandPivot;
	[SerializeField]
	Transform minHandPivot;
	[SerializeField]
	Transform secHandPivot;

	const float _hrHandDegreesPerSec = -(1.0f / 120.0f);
	const float _minHandDegreesPerSec = -(1.0f / 10.0f);
	const float _secHandDegreesPerSec = -6.0f;

	void UpdateTime()
	{
		DateTime time = DateTime.Now;
		hourHandPivot.localRotation = Quaternion.Euler(0.0f, 0.0f, (time.Hour * 3600.0f + time.Minute * 60.0f + time.Second) * _hrHandDegreesPerSec);
		minHandPivot.localRotation = Quaternion.Euler(0.0f, 0.0f, (time.Minute * 60.0f + time.Second) * _minHandDegreesPerSec);
		secHandPivot.localRotation = Quaternion.Euler(0.0f, 0.0f, _secHandDegreesPerSec * time.Second);
	}

	void Awake()
	{
		UpdateTime();
	}

	void Update()
	{
		if (Keyboard.current.escapeKey.wasPressedThisFrame)
			Application.Quit();

		UpdateTime();
	}
}
