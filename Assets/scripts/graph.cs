using UnityEngine;
using UnityEngine.InputSystem;


public class Graph : MonoBehaviour
{
	[SerializeField]
	Transform pointPrefab;

	[SerializeField, Range(10, 100)]
	int resolution = 50;

	[SerializeField]
	FunctionLibrary.FunctionSelecter selectFunction = FunctionLibrary.FunctionSelecter.Wave;

	Transform[] _points;

	void Awake()
	{
		_points = new Transform[resolution * resolution];
		float step = 2.0f / (float)resolution;
		Vector3 scale = Vector3.one * step;
		Vector3 position = Vector3.zero;

		for (int i = 0; i < _points.Length; ++i)
		{
			_points[i] = Instantiate<Transform>(pointPrefab);
			_points[i].localPosition = position;
			_points[i].localScale = scale;
			_points[i].SetParent(transform, false);
		}
	}

	void Update()
	{
		if (Keyboard.current.escapeKey.wasPressedThisFrame)
			Application.Quit();

		Vector3 position = Vector3.zero;
		float step = 2.0f / (float)resolution;

		for (int i = 0; i < _points.Length; ++i)
		{
			int x = i % resolution;
			int z = i / resolution;
			float u = ((float)x + 0.5f) * step - 1.0f;
			float v = ((float)z + 0.5f) * step - 1.0f;
			position = FunctionLibrary.GetFunction(selectFunction)(u, v, Time.time);

			_points[i].localPosition = position;
		}
	}
}
