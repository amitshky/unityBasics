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
		return Mathf.Sin(Mathf.PI * (x * z + t));
	}

	public static float MultiWave(float x, float z, float t)
	{
		float y = Mathf.Sin(Mathf.PI * (x * z + t));
		y += 0.50f * Mathf.Sin(2.0f * Mathf.PI * (x * z + t));
		y += 0.25f * Mathf.Sin(4.0f * Mathf.PI * (x * z + t));

		return y * 0.8192020972f; // dividing by 1.2207 and normalizing the result from -1 to 1
	}

	public static float Ripple(float x, float z, float t)
	{
		float distanceX = Mathf.Abs(x);
		float distanceZ = Mathf.Abs(z);
		float y = Mathf.Sin(Mathf.PI * (4.0f * distanceX * distanceZ - t)) / (1.0f + 10.0f * distanceX * distanceZ);

		return y;
	}
}
