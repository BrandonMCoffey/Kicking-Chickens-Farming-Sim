using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopGroundPlane : ValidGroundPlane
{
	[SerializeField] private Vector2 _extents = Vector2.one * 10;
	
	public override Vector3 GetNormal() => transform.up;
	
	public override Vector3 GetPointOnPlane()
	{
		var pos = new Vector2(_extents.x * Random.Range(-1f, 1f), _extents.y * Random.Range(-1f, 1f));
		return transform.TransformPoint(new Vector3(pos.x, 0, pos.y));
	}
}
