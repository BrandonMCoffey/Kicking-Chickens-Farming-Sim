﻿using UnityEngine;

public class Chicken : MonoBehaviour, IInteractable
{
	[SerializeField] private SO_ChickenDataBase _data;
	[SerializeField] private ValidGroundPlane _groundPlane;
	[SerializeField] private float _layEggTimer;
	[SerializeField] private float _layEggTime;
	[SerializeField] private Vector3 _center;
	[SerializeField] private Vector3 _goal;
	[SerializeField] private bool _hasNotReachedGoal;
	[SerializeField] private float _waitTimer;
	[SerializeField] private float _waitTime;

	public void SetChicken(SO_ChickenDataBase data)
	{
		_data = data;
	}
	
	private void Start()
	{
		_center = transform.localPosition;
		_goal = _center;
		_layEggTime = _data.EggLayTime;
		_waitTime = _data.WaitTime;
		
		InvokeRepeating(nameof(PlayChickenSound), 5.0f, Random.Range(15.0f, 50.0f));
	}
	
	private void PlayChickenSound() => _data.PlayChickenNoiseSfx(transform);
	
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
		SetGroundPlane(GameManager.GetRandomGroundPlane());
	}
	
	public void SetGroundPlane(ValidGroundPlane plane)
	{
		_groundPlane = plane;
		if (_groundPlane)
		{
			transform.position = GetValidGoal();
			_goal = GetValidGoal();
			transform.LookAt(_goal, _groundPlane.GetNormal());
		}
	}
	
	private Vector3 GetValidGoal()
	{
		Vector3 pos = Vector3.zero;
		for (int i = 0; i < 10; i++)
		{
			pos = _groundPlane.GetPointOnPlane();
			var dir = (pos - transform.position).normalized;

			if (Physics.Raycast(transform.position, dir, out var hit, 100, GameManager.CoopLayer))
			{
				continue;
			}
			return pos;
		}
		Debug.LogWarning("Could not find valid goal for chicken", gameObject);
		return pos;
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
				_goal = GetValidGoal();
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
		var move = Vector3.ProjectOnPlane(transform.forward, _groundPlane.GetNormal());
		transform.position += move * (_data.MoveSpeed * Time.deltaTime);
	}
	
	private void LayEggUpdate()
	{
		_layEggTimer += Time.deltaTime;
		if (_layEggTimer > _layEggTime)
		{
			_layEggTimer = 0;
			_layEggTime = _data.EggLayTime;
			
			GameManager.SpawnEgg(_data.EggPrefab, transform);
			_data.PlayEggLaySfx(transform);
		}
	}
	
	[Button]
	public void Interact()
	{
		GameManager.EmitChickenPetVfx(transform.position, transform.eulerAngles, 1);
	}
}
