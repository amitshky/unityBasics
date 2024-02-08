using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
	[SerializeField]
	TextMeshProUGUI counterUI;

	[SerializeField, Range(0.1f, 2.0f)]
	float sampleDuration = 0.4f;

	float _duration = 0.0f;
	int _frames = 0;

	void Update()
	{
		_duration += Time.unscaledDeltaTime;
		_frames += 1;

		if (_duration >= sampleDuration)
		{
			int fps = (int)(_frames / _duration);
			counterUI.SetText("FPS\n{}", fps);
			_duration = 0.0f;
			_frames = 0;
		}
	}
}
