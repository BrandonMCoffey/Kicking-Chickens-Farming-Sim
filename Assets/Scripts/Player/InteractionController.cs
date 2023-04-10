using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
	[SerializeField] private float _maxInteractDistance = 10;
	[SerializeField] private LayerMask _interactLayerMask = 1;
	
	[Header("Camera References")]
	[SerializeField] private List<Camera> _cameras;
	[SerializeField, ReadOnly] private Camera _activeCamera;
	
	private bool _active;
	
	private void Awake()
	{
		ARManagerSwitcher.OnArInitialized += EnableInteraction;
	}
	
	private void OnEnable()
	{
		InputManager.TapScreen += Interact;
	}
	
	private void OnDisable()
	{
		InputManager.TapScreen -= Interact;
	}
	
	private void EnableInteraction()
	{
		_activeCamera = null;
		foreach (var cam in _cameras)
		{
			if (cam.gameObject.activeInHierarchy)
			{
				_activeCamera = cam;
				break;
			}
		}
		_active = _activeCamera != null;
	}
	
	private void Interact()
	{
		if (!_active) return;
		Ray ray = _activeCamera.ScreenPointToRay(InputManager.ScreenPos);
		if (Physics.Raycast(ray, out var hit, _maxInteractDistance, _interactLayerMask))
		{
			#if UNITY_EDITOR
			Debug.Log("Tapped " + hit.collider.gameObject.name, gameObject);
			Debug.DrawRay(ray.origin, ray.direction.normalized * hit.distance, Color.red, 8f);
			#endif
		}
	}
}
