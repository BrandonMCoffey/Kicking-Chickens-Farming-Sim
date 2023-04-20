using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	private static List<ValidGroundPlane> _planes = new List<ValidGroundPlane>();
    
	[SerializeField] private ParticleSystem _heartParticles;
	[SerializeField] private int _heartsPerClick = 1;
	[SerializeField] private Transform _chickenParent;
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
	
	[Button]
	public void Spawn100RandomChickens()
	{
		for (int i = 0; i < 100; i++) SpawnRandomChicken();
	}
	
	public void SpawnChicken(Chicken prefab)
	{
		var chicken = Instantiate(prefab, _chickenParent);
		
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
	
	public static void EmitHearts(Vector3 pos, Vector3 rot)
	{
		Instance._heartParticles.transform.SetPositionAndRotation(pos, Quaternion.Euler(rot));
		Instance._heartParticles.Emit(Instance._heartsPerClick);
	}
}
