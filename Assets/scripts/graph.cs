using UnityEngine;

public class Graph : MonoBehaviour
{
	[SerializeField]
	Transform pointPrefab;

	void Awake()
	{
		for (int i = -10; i < 10; ++i)
		{
			Transform point = Instantiate<Transform>(pointPrefab);
			point.localPosition = new Vector3((float)i, (float)(0.2f * (i * i * i)) -1.64f, 0.0f);
		}
	}
}
