using UnityEngine;

public static class FunctionLibrary
{
	public enum FunctionSelector : uint
	{
		Wave, MultiWave, Ripple
	}

	public delegate float Function(float x, float t);

	private static Function[] functions = { Wave, MultiWave, Ripple };

	public static Function GetFunction(FunctionSelector index)
	{
		return functions[(uint)index];
	}

	public static float Wave(float x, float t)
	{
		return Mathf.Sin(Mathf.PI * (x + t));
	}

	public static float MultiWave(float x, float t)
	{
		float y = Mathf.Sin(Mathf.PI * (x + t));
		y += 0.50f * Mathf.Sin(2.0f * Mathf.PI * (x + t));
		y += 0.25f * Mathf.Sin(4.0f * Mathf.PI * (x + t));

		return y * 0.8192020972f; // dividing by 1.2207 and normalizing the result from -1 to 1
	}

	public static float Ripple(float x, float t)
	{
		float distance = Mathf.Abs(x);
		float y = Mathf.Sin(Mathf.PI * (4.0f * distance - t)) / (1.0f + 10.0f * distance);

		return y;
	}
}
