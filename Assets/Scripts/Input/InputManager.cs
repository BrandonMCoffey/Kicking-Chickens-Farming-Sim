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
	public static float UpDown { get; private set; }
	public static Vector3 Movement => new Vector3(MoveDir.x, UpDown, MoveDir.y);
	public static Vector2 LookDir { get; private set; }
	public static bool HoldingScreen;
	public static System.Action TapScreen = delegate { };
	public static Vector2 ScreenPos { get; private set; }
	
	private bool TapThisFrame;
	
	private void Update()
	{
		if (TapThisFrame)
		{
			Log("Tap");
			TapScreen?.Invoke();
		}
		TapThisFrame = false;
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
	
	private void OnMoveUpDown(InputValue value)
	{
		UpDown = value.Get<float>();
		Log("UpDown: " + UpDown, true);
	}
	
	private void OnLook(InputValue value)
	{
		LookDir = value.Get<Vector2>();
		Log("Look: " + LookDir, true);
	}
	
	private void OnUpdateScreenPos(InputValue value)
	{
		ScreenPos = value.Get<Vector2>();
		Log("Touch: " + ScreenPos, true);
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
				TapThisFrame = true;
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
