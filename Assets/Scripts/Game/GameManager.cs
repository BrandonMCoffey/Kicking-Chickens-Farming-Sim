using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	private static List<ValidGroundPlane> _planes = new List<ValidGroundPlane>();

	[SerializeField] private EconomyManager _economy;

	public static EconomyManager Economy => Instance._economy;

	[Header("Game References")]
	[SerializeField] private Coop _coopController;
	[SerializeField] private LayerMask _coopLayer = 0;
	[SerializeField] private ChickenController _chickenController;
	[SerializeField] private EggPool _eggController;
	
	public static LayerMask CoopLayer => Instance._coopLayer;
	
	[Header("VFX")]
	[SerializeField] private ParticleSystem _petChickenParticles;
	[SerializeField] private ParticleSystem _eggCollectParticles;
	
    private void Awake()
	{
		if (Instance && Instance != this) Destroy(this);
	    Instance = this;
    }

    private void OnValidate()
    {
	    if (!_coopController) _coopController = GetComponentInChildren<Coop>();
	    if (!_chickenController) _chickenController = GetComponentInChildren<ChickenController>();
	    if (!_eggController) _eggController = GetComponentInChildren<EggPool>();
    }

    // Grond Planes
    public static void AddPlane(ValidGroundPlane plane)
    {
	    if (!_planes.Contains(plane)) _planes.Add(plane);
    }
    public static void RemovePlane(ValidGroundPlane plane)
    {
	    _planes.Remove(plane);
    }
	
    public static ValidGroundPlane GetRandomGroundPlane()
    {
	    return _planes[Random.Range(0, _planes.Count)];
    }
    
    // Game Actions
    public static void SetFeed(SO_FeedDataBase feedData) => Instance._coopController.SetFeed(feedData);
    public static void SpawnChicken(SO_ChickenDataBase chickenData) => Instance._chickenController.SpawnChicken(chickenData);
    public static void SpawnEgg(Egg eggPrefab, Transform parent) => Instance._eggController.SpawnEgg(eggPrefab, parent);

    // VFX
	public static void EmitChickenPetVfx(Vector3 pos, Vector3 rot, int count) => EmitVfx(Instance._petChickenParticles, pos, rot, count);
	public static void EmitEggCollectVfx(Vector3 pos, Vector3 rot, int count) => EmitVfx(Instance._eggCollectParticles, pos, rot, count);
	private static void EmitVfx(ParticleSystem particles, Vector3 pos, Vector3 rot, int count)
	{
		if (!particles) return;
		particles.transform.SetPositionAndRotation(pos, Quaternion.Euler(rot));
		particles.Emit(count);
	}
}
