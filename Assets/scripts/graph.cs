using UnityEngine;

public class Graph : MonoBehaviour
{
	[SerializeField]
	Transform pointPrefab;

	[SerializeField, Range(10, 100)]
	int resolution = 50;

	Transform[] _points;

	float Sin(float x)
	{
		return Mathf.Sin(Mathf.PI * x + Time.time);
	}

	void Awake()
	{
		_points = new Transform[resolution];
		float step = 2.0f / (float)resolution;
		Vector3 scale = Vector3.one * step;
		Vector3 position = Vector3.zero;

		for (int i = 0; i < resolution; ++i)
		{
			_points[i] = Instantiate<Transform>(pointPrefab);
			_points[i].SetParent(transform, false);

			float x = ((float)i + 0.5f) * step - 1.0f;
			position.x = x;
			position.y = Sin(x);

			_points[i].localPosition = position;
			_points[i].localScale = scale;
		}
	}

	void Update()
	{
		Vector3 position = Vector3.zero;
		for (int i = 0; i < resolution; ++i)
		{
			position.x = _points[i].localPosition.x;
			position.y = Sin(position.x);

			_points[i].localPosition = position;
		}
	}
}
