﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
	[SerializeField] private SO_ChickenDataBase _data;
	[SerializeField] private Transform _chickenArt;
	
	[Header("Debug")]
	[SerializeField, ReadOnly] private float _layEggTimer;
	[SerializeField, ReadOnly] private float _layEggTime;
	[SerializeField, ReadOnly] private Vector3 _center;
	[SerializeField, ReadOnly] private Vector3 _goal;
	[SerializeField, ReadOnly] private bool _hasNotReachedGoal;
	[SerializeField, ReadOnly] private float _waitTimer;
	[SerializeField, ReadOnly] private float _waitTime;
	
	private void Start()
	{
		_center = transform.localPosition;
		_goal = _center;
		_layEggTime = _data.eggLayTime;
		_waitTime = _data.WaitTime;
	}
	
	private void Update()
	{
		ChickenUpdate();
		LayEggUpdate();
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
				_goal = _data.RandomGoalOffset(_center, transform.localPosition);
				_hasNotReachedGoal = true;
			}
		}
	}
	
	private void MoveAndRotateChicken()
	{
		var currRot = transform.localRotation;
		transform.LookAt(_goal, Vector3.up);
		transform.localRotation = Quaternion.Lerp(currRot, transform.localRotation, _data.RotateSpeed * Time.deltaTime);
		
		// TODO: This can be better (Local only)
		var move = Vector3.ProjectOnPlane(transform.forward, GameManager.GroundPlane.up);
		transform.position += move * _data.MoveSpeed * Time.deltaTime;
	}
	
	private void LayEggUpdate()
	{
		_layEggTimer += Time.deltaTime;
		if (_layEggTimer > _layEggTime)
		{
			_layEggTimer = 0;
			_layEggTime = _data.eggLayTime;
			
			// TODO: Spawn Egg
			var egg = Instantiate(_data.EggPrefab, transform.position, Quaternion.identity);
			egg.Hatch(_data.EggHatchTime);
		}
	}
}
