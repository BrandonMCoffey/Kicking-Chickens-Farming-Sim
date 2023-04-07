using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
	[SerializeField] private float _maxHoldForTap = 0.2f;
	[SerializeField] private bool _debug;
	[SerializeField] private bool _debugMovement;
	
	private bool _tapping;
	private float _tapDuration;
	
	public static Vector2 MoveDir { get; private set; }
	public static Vector2 LookDir { get; private set; }
	public static bool HoldingScreen;
	public static System.Action TapScreen = delegate { };
	
	private void Update()
	{
		if (_tapping)
		{
			_tapDuration += Time.deltaTime;
			HoldingScreen = _tapDuration > _maxHoldForTap;
		}
	}
	
	private void OnMove(InputValue value)
	{
		MoveDir = value.Get<Vector2>();
		Log("Move: " + MoveDir, true);
	}
	
	private void OnLook(InputValue value)
	{
		LookDir = value.Get<Vector2>();
		Log("Look: " + LookDir, true);
	}
	
	private void OnFire(InputValue value)
	{
		if (value.isPressed)
		{
			_tapping = true;
			Log("Begin Hold");
		}
		else
		{
			if (_tapDuration <= _maxHoldForTap)
			{
				Log("Tap");
				TapScreen?.Invoke();
			}
			else Log("End Hold");
			_tapping = false;
			HoldingScreen = false;
		}
		_tapDuration = 0;
	}
	
	private void Log(string message, bool movement = false)
	{
		#if UNITY_EDITOR
		if (movement && _debugMovement || !movement && _debug) Debug.Log(message, gameObject);
		#endif
	}
}
