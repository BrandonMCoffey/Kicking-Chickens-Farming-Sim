using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
	[SerializeField] private SO_ChickenDataBase _data;
	
	
	[SerializeField, ReadOnly] private Vector3 _center;
	[SerializeField, ReadOnly] private Vector3 _goal;
	[SerializeField, ReadOnly] private bool _hasNotReachedGoal; 
	[SerializeField, ReadOnly] private float _waitTimer; 
	
	private void Start()
	{
		_center = transform.localPosition;
	}
	
	private void Update()
	{
		if (_hasNotReachedGoal)
		{
			MoveAndRotate();
			var dist = Vector3.Distance(transform.localPosition, _goal);
			if (dist <= _data.GoalReachedRange)
			{
				_hasNotReachedGoal = false;
				_waitTimer = 0;
			}
		}
		else
		{
			_waitTimer += Time.deltaTime;
			if (_waitTimer > _data.WaitTime)
			{
				_goal = _data.RandomGoalOffset(_center, transform.localPosition);
				_hasNotReachedGoal = true;
			}
		}
	}
	
	private void MoveAndRotate()
	{
		var currRot = transform.localRotation;
		transform.LookAt(_goal, Vector3.up);
		transform.localRotation = Quaternion.Lerp(currRot, transform.localRotation, _data.RotateSpeed * Time.deltaTime);
		
		// TODO: This can be better (Local only)
		var move = Vector3.ProjectOnPlane(transform.forward, GameManager.GroundPlane.up);
		transform.position += move * _data.MoveSpeed * Time.deltaTime;
	}
}
