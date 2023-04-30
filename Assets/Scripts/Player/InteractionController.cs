using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
	[SerializeField] private bool _debug;
	[SerializeField] private float _maxInteractDistance = 10;
	[SerializeField] private LayerMask _interactLayerMask = 1;
	
	[Header("Camera References")]
	[SerializeField] private List<Camera> _cameras = new List<Camera>();
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
		var ray = _activeCamera.ScreenPointToRay(InputManager.ScreenPos);
		var hits = Physics.RaycastAll(ray ,_maxInteractDistance, _interactLayerMask);
		foreach (var hit in hits)
		{
			var interactable = hit.collider.GetComponent<IInteractable>();
			if (interactable != null) interactable.Interact();
			
			#if UNITY_EDITOR
			if (_debug)
			{
				Debug.Log("Tapped " + hit.collider.gameObject.name, gameObject);
				Debug.DrawRay(ray.origin, ray.direction.normalized * hit.distance, Color.red, 8f);
			}
			#endif
		}
	}
}
