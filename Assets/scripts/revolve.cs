using UnityEngine;

public class Revolve: MonoBehaviour
{
	[SerializeField, Range(0.0f, 10.0f)]
	float radius = 1.0f;

	[SerializeField, Range(0.0f, 10.0f)]
	float xOffset = 0.0f;

	[SerializeField, Range(0.0f, 10.0f)]
	float yOffset = 0.0f;

	void Update()
	{
		Vector3 position = new Vector3(
			radius * Mathf.Sin(Mathf.PI * Time.time / radius) + xOffset, 
			radius * Mathf.Cos(Mathf.PI * Time.time / radius) + yOffset, 
			0.0f
		);
		transform.position = position;
	}
}
