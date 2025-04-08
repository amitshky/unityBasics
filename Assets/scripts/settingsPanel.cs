using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsPanel : MonoBehaviour
{
  [SerializeField] CameraController _cameraController;
	[SerializeField] Graph _graph;

  [SerializeField] Slider _mouseSensitivitySlider;
  [SerializeField] Slider _movementSpeedSlider;
	[SerializeField] TMP_Dropdown _graphFunctionDropdown;

  void Awake()
  {
		_mouseSensitivitySlider.value = _cameraController.GetMouseSensitivity();
		_mouseSensitivitySlider.onValueChanged.AddListener(
			(val) => _cameraController.SetMouseSensitivity(val)
		);

		_movementSpeedSlider.value = _cameraController.GetMovementSpeed();
		_movementSpeedSlider.onValueChanged.AddListener(
			(val) => _cameraController.SetMovementSpeed(val)
		);

		// populate the options with names in the FunctionSelecter enum
		string[] functionsEnum = Enum.GetNames(typeof(FunctionLibrary.FunctionSelecter));
		List<string> functions = new List<string>(functionsEnum);
		_graphFunctionDropdown.AddOptions(functions);

		_graphFunctionDropdown.value = (int)_graph.GetGraphFunction();
		_graphFunctionDropdown.onValueChanged.AddListener(
			(int val) => _graph.SetGraphFunction((FunctionLibrary.FunctionSelecter)val)
		);
  }
}
