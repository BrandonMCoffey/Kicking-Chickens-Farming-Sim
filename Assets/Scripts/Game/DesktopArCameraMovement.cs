using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopArCameraMovement : MonoBehaviour
{
	[SerializeField] private float _moveSpeed = 2;
	[SerializeField] private float _lookSpeed = 20;
	[SerializeField] private Vector2 _pitchClamp = new Vector2(-15, 60);
	[SerializeField] private Transform _cameraTransform;
	
	[SerializeField, ReadOnly] private float _pitch;
	
	private void Awake()
	{
		_pitch = _cameraTransform.localEulerAngles.x;
	}
	
	private void Update()
	{
		if (InputManager.HoldingScreen)
		{
			// Look
			var look = InputManager.LookDir * _lookSpeed * Time.deltaTime;
			transform.Rotate(new Vector3(0, look.x, 0));
			_pitch -= look.y;
			_pitch = Mathf.Clamp(_pitch, _pitchClamp.x, _pitchClamp.y);
			_cameraTransform.localRotation = Quaternion.Euler(new Vector3(_pitch, 0, 0));
			
		}
		// Move
		var move = InputManager.MoveDir * _moveSpeed * Time.deltaTime;
		transform.position += move.y * transform.forward + move.x * transform.right;
	}
}
