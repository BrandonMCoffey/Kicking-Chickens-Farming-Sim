using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audio;

public class Chicken : MonoBehaviour, IInteractable
{
	[SerializeField] private SO_ChickenDataBase _data;
	[SerializeField] private Transform _chickenArt;
	
	[Header("Debug")]
	[SerializeField, ReadOnly] private ValidGroundPlane _groundPlane;
	[SerializeField, ReadOnly] private float _layEggTimer;
	[SerializeField, ReadOnly] private float _layEggTime;
	[SerializeField, ReadOnly] private Vector3 _center;
	[SerializeField, ReadOnly] private Vector3 _goal;
	[SerializeField, ReadOnly] private bool _hasNotReachedGoal;
	[SerializeField, ReadOnly] private float _waitTimer;
	[SerializeField, ReadOnly] private float _waitTime;

	[Header("SFX")]
	[SerializeField] private AudioClip _chickenNoise;
	[SerializeField] private AudioClip _eggLayNoise;

	private void Start()
	{
		_center = transform.localPosition;
		_goal = _center;
		_layEggTime = _data.eggLayTime;
		_waitTime = _data.WaitTime;
		
		InvokeRepeating(nameof(PlayChickenSound), 5.0f, Random.Range(15.0f, 50.0f));
	}
	
	private void Update()
	{
		CheckGroundPlane();
		if (!_groundPlane) return;
		ChickenUpdate();
		LayEggUpdate();
	}
	
	private void CheckGroundPlane()
	{
		if (_groundPlane) return;
		SetGroundPlane(GameManager.GetRandomGrondPlane());
	}
	
	public void SetGroundPlane(ValidGroundPlane plane)
	{
		_chickenArt.gameObject.SetActive(plane);
		_groundPlane = plane;
		if (plane)
		{
			transform.position = plane.GetPointOnPlane();
			_goal = plane.GetPointOnPlane();
			transform.LookAt(_goal, plane.GetNormal());
		}
	}
	
	private void ChickenUpdate()
	{
		if (_hasNotReachedGoal)
		{
			MoveAndRotateChicken();
			var dist = Vector3.Distance(transform.localPosition, _goal);
			if (dist <= _data.GoalReachedRange)
			{
				_hasNotReachedGoal = false;
				_waitTimer = 0;
				_waitTime = _data.WaitTime;
			}
		}
		else
		{
			_waitTimer += Time.deltaTime;
			if (_waitTimer > _waitTime)
			{
				_goal = _groundPlane.GetPointOnPlane();
				_hasNotReachedGoal = true;
			}
		}
	}
	
	private void MoveAndRotateChicken()
	{
		var currRot = transform.localRotation;
		transform.LookAt(_goal, _groundPlane.GetNormal());
		transform.localRotation = Quaternion.Lerp(currRot, transform.localRotation, _data.RotateSpeed * Time.deltaTime);
		
		// TODO: This can be better (Local only)
		// TODO: This can be better (Local only)
		// TODO: This can be better (Local only)
		var move = Vector3.ProjectOnPlane(transform.forward, _groundPlane.GetNormal());
		transform.position += move * _data.MoveSpeed * Time.deltaTime;
	}
	
	private void LayEggUpdate()
	{
		_layEggTimer += Time.deltaTime;
		if (_layEggTimer > _layEggTime)
		{
			_layEggTimer = 0;
			_layEggTime = _data.eggLayTime;
			
			GameManager.Instance.SpawnEgg(_data.EggPrefab, transform);
			AudioManager.PlayClip3D(_eggLayNoise, 0.1f);
		}
	}
	
	private void PlayChickenSound()
	{
		AudioManager.PlayClip3D(_chickenNoise, 0.1f);
	}
	
	[Button]
	public void Interact()
	{
		GameManager.EmitHearts(transform.position, transform.eulerAngles);
	}
}
