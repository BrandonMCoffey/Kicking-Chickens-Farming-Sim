using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ArGroundPlane : ValidGroundPlane
{
	[SerializeField] private ARPlane _plane;
	
	public override Vector3 GetNormal() => _plane.normal;
	
	public override Vector3 GetPointOnPlane()
	{
		var pos = _plane.centerInPlaneSpace;
		pos.x += _plane.extents.x * Random.Range(-1f, 1f);
		pos.y += _plane.extents.y * Random.Range(-1f, 1f);
		return transform.TransformPoint(new Vector3(pos.x, 0, pos.y));
	}
	
	private void OnValidate()
	{
		if (!_plane) _plane = GetComponent<ARPlane>();
	}
}
