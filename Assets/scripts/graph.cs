using UnityEngine;

public class Graph : MonoBehaviour
{
	[SerializeField]
	Transform pointPrefab;

	float GraphFuntion(float x)
	{
		return 0.2f * (x * x * x) - 1.64f;
	}

	void Awake()
	{
		Transform point;
		Vector3 scale = Vector3.one / 5.0f;

		for (int i = 0; i < 10; ++i)
		{
			float x = ((float)i + 0.5f) / 5.0f - 1.0f;
			point = Instantiate<Transform>(pointPrefab);
			point.localPosition = new Vector3(x, GraphFuntion(x), 0.0f);
			point.localScale = scale;
		}
	}
}
