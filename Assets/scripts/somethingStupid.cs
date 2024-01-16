using UnityEngine;

class SomethingStupid : MonoBehaviour
{
	[SerializeField, Range(0.0f, 10.0f)]
	float speed = 3.0f;

	[SerializeField, Range(0.0f, 10.0f)]
	float offset = 0.0f;

	[SerializeField, Range(0.0f, 10.0f)]
	float radius = 1.0f;

	void Update()
	{
		Vector3 position = new Vector3(radius * Mathf.Sin(speed * Time.time) + offset, radius * Mathf.Cos(speed * Time.time) + offset, 0.0f);
		transform.position = position;
	}
}
