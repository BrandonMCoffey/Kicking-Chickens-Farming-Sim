using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	private static List<ValidGroundPlane> _planes = new List<ValidGroundPlane>();
    
	[SerializeField] private List<Chicken> _chickenPrefabs;
	
	[Header("Debug")]
	[SerializeField, ReadOnly] private List<Chicken> _spawnedChickens;
	
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
		var chicken = Instantiate(prefab);
		
		// TODO: Actual defined positions based on player tap location
		var offset = Random.insideUnitCircle * 2;
		chicken.transform.localPosition += new Vector3(offset.x, 0, offset.y);
		
		_spawnedChickens.Add(chicken);
	}
	
	public static ValidGroundPlane GetRandomGrondPlane()
	{
		return _planes[Random.Range(0, _planes.Count)];
	}
	
	public static void AddPlane(ValidGroundPlane plane)
	{
		if (!_planes.Contains(plane)) _planes.Add(plane);
	}
	
	public static void RemovePlane(ValidGroundPlane plane)
	{
		_planes.Remove(plane);
	}
}
