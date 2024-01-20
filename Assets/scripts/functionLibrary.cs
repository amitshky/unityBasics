using UnityEngine;

public static class FunctionLibrary
{
	public delegate Vector3 Function(float u, float v, float t);

	private static Function[] _functions = { Wave, MultiWave, Ripple, Sphere, Torus };
	public enum FunctionSelecter : uint
	{
		Wave, MultiWave, Ripple, Sphere, Torus
	}

	public static Function GetFunction(FunctionSelecter index)
	{
		return _functions[(uint)index];
	}

	public static Vector3 Wave(float u, float v, float t)
	{
		return new Vector3(u, Mathf.Sin(Mathf.PI * (u + v + t)), v);
	}

	public static Vector3 MultiWave(float u, float v, float t)
	{
		Vector3 p;
		p.x = u;
		p.z = v;

		p.y = Mathf.Sin(Mathf.PI * (u + 0.5f * t));
		p.y += 0.50f * Mathf.Sin(2.0f * Mathf.PI * (v + t));
		p.y += Mathf.Sin(Mathf.PI * (u + v + 0.25f * t));
		p.y /= 2.5f;

		return p;
	}

	public static Vector3 Ripple(float u, float v, float t)
	{
		float distance = Mathf.Sqrt(u * u + v * v);

		Vector3 p;
		p.x = u;
		p.y = Mathf.Sin(Mathf.PI * (4.0f * distance - t)) / (1.0f + 10.0f * distance);
		p.z = v;

		return p;
	}

	public static Vector3 Sphere(float u, float v, float t)
	{
		// parametric equation of a sphere
		float radius = Mathf.Sin(0.5f * Mathf.PI * t);

		Vector3 p;
		p.x = radius * Mathf.Cos(Mathf.PI * u) * Mathf.Sin(Mathf.PI * v);
		p.y = radius * Mathf.Cos(Mathf.PI * v);
		p.z = radius * Mathf.Sin(Mathf.PI * u) * Mathf.Sin(Mathf.PI * v);

		return p;
	}

	public static Vector3 Torus(float u, float v, float t)
	{
		// parametric equation of a torus
		float externalRadius = 1.0f;
		float internalRadius = 0.25f;

		Vector3 p;
		p.x = (externalRadius + internalRadius * Mathf.Cos(Mathf.PI * u)) * Mathf.Cos(Mathf.PI * v);
		p.y = internalRadius * Mathf.Sin(Mathf.PI * u);
		p.z = (externalRadius + internalRadius * Mathf.Cos(Mathf.PI * u)) * Mathf.Sin(Mathf.PI * v);
		
		return p;
	}
}
