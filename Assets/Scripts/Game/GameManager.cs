using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
	[SerializeField] private Transform _groundPlane;
	[SerializeField] private List<Chicken> _chickenPrefabs;
	
	[Header("Debug")]
	[SerializeField, ReadOnly] private List<Chicken> _spawnedChickens;

    public static void SetGroundPlane(Vector3 pos, Quaternion rot) => Instance._groundPlane.SetPositionAndRotation(pos, rot);
	public static Transform GroundPlane => Instance._groundPlane;
	
    private void Awake()
	{
		if (Instance && Instance != this) Destroy(this);
	    Instance = this;
	    _spawnedChickens = new List<Chicken>();
    }
    
	[Button]
	public void SpawnRandomChicken()
	{
		var chicken = _chickenPrefabs[Random.Range(0, _chickenPrefabs.Count)];
		SpawnChicken(chicken);
	}
	
	public void SpawnChicken(Chicken prefab)
	{
		var chicken = Instantiate(prefab, _groundPlane);
		
		// TODO: Actual definied positions based on player tap location
		var offset = Random.insideUnitCircle * 2;
		chicken.transform.localPosition += new Vector3(offset.x, 0, offset.y);
		
		_spawnedChickens.Add(chicken);
	}
}
