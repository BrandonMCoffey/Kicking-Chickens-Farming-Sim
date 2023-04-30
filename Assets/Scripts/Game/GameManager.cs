using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	private static List<ValidGroundPlane> _planes = new List<ValidGroundPlane>();
    
	[SerializeField] private EggPool _eggController;
	[SerializeField] private Transform _chickenParent;
	[SerializeField] private List<Chicken> _chickenPrefabs;
	
	[Header("VFX")]
	[SerializeField] private ParticleSystem _petChickenParticles;
	[SerializeField] private ParticleSystem _eggCollectParticles;
	
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
	
	public void SpawnEgg(Egg eggPrefab, Transform parent)
	{
		_eggController.SpawnEgg(eggPrefab, parent);
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
	
	public static void EmitChickenPetVfx(Vector3 pos, Vector3 rot, int count) => EmitVfx(Instance._petChickenParticles, pos, rot, count);
	public static void EmitEggCollectVfx(Vector3 pos, Vector3 rot, int count) => EmitVfx(Instance._eggCollectParticles, pos, rot, count);
	private static void EmitVfx(ParticleSystem particles, Vector3 pos, Vector3 rot, int count)
	{
		if (!particles) return;
		particles.transform.SetPositionAndRotation(pos, Quaternion.Euler(rot));
		particles.Emit(count);
	}
}
