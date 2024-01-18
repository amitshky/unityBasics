using UnityEngine;


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
			_points[i].SetParent(transform, false);

			int x = i % resolution;
			int z = i / resolution;
			position.x = ((float)x + 0.5f) * step - 1.0f;
			position.z = ((float)z + 0.5f) * step - 1.0f;

			_points[i].localPosition = position;
			_points[i].localScale = scale;
		}
	}

	void Update()
	{
		Vector3 position = Vector3.zero;
		for (int i = 0; i < _points.Length; ++i)
		{
			position.x = _points[i].localPosition.x;
			position.z = _points[i].localPosition.z;
			position.y = FunctionLibrary.GetFunction(selectFunction)(position.x, position.z, Time.time);

			_points[i].localPosition = position;
		}
	}
}
