using UnityEngine;

public class DesktopArCameraMovement : MonoBehaviour
{
	[SerializeField] private float _moveSpeed = 2;
	[SerializeField] private Vector2 _upDownClamp = new Vector2(1, 6);
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
		var m = InputManager.Movement * _moveSpeed * Time.deltaTime;
		var goal = transform.position + m.x * transform.right + m.y * Vector3.up + m.z * transform.forward;
		goal.y = Mathf.Clamp(goal.y, _upDownClamp.x, _upDownClamp.y);
		transform.position = goal;
	}
}
