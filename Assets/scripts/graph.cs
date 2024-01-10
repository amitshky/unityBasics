using UnityEngine;

public class Graph : MonoBehaviour
{
	[SerializeField]
	Transform pointPrefab;
	[SerializeField, Range(10, 100)]
	int resolution = 10;


	float GraphFuntion(float x)
	{
		return x * x * x;
	}

	void Awake()
	{
		float step = 2.0f / (float)resolution;
		Vector3 scale = Vector3.one * step;
		Vector3 position = Vector3.zero;
		Transform point;

		for (int i = 0; i < resolution; ++i)
		{
			point = Instantiate<Transform>(pointPrefab);
			point.SetParent(transform, false);

			float x = ((float)i + 0.5f) * step - 1.0f;
			position.x = x;
			position.y = GraphFuntion(x);

			point.localPosition = position;
			point.localScale = scale;
		}
	}
}
