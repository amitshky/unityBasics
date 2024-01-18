using UnityEngine;

public static class FunctionLibrary
{
	public delegate float Function(float x, float z, float t);

	private static Function[] _functions = { Wave, MultiWave, Ripple };

	public enum FunctionSelecter : uint
	{
		Wave, MultiWave, Ripple
	}

	public static Function GetFunction(FunctionSelecter index)
	{
		return _functions[(uint)index];
	}

	public static float Wave(float x, float z, float t)
	{
		return Mathf.Sin(Mathf.PI * (x + z + t));
	}

	public static float MultiWave(float x, float z, float t)
	{
		float y = Mathf.Sin(Mathf.PI * (x + 0.5f * t));
		y += 0.50f * Mathf.Sin(2.0f * Mathf.PI * (z + t));
		y += Mathf.Sin(Mathf.PI * (x + z + 0.25f * t));

		return y / 2.5f; // dividing by 1.2207 and normalizing the result from -1 to 1
	}

	public static float Ripple(float x, float z, float t)
	{
		float distance = Mathf.Sqrt(x * x + z * z);
		float y = Mathf.Sin(Mathf.PI * (4.0f * distance - t)) / (1.0f + 10.0f * distance);

		return y;
	}
}
