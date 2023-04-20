using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public abstract class ValidGroundPlane : MonoBehaviour
{
	public abstract Vector3 GetNormal();
	public abstract Vector3 GetPointOnPlane();
	
	private void OnEnable()
	{
		GameManager.AddPlane(this);
	}
	
	private void OnDisable()
	{
		GameManager.RemovePlane(this);
	}
}
