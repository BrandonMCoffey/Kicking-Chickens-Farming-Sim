using UnityEngine;
using CoffeyUtils;

[CreateAssetMenu(fileName = "SO_ChickenData", menuName = "FarmScriptableObjects/Chicken", order = 0)]
public class SO_ChickenDataBase : ScriptableObject
{
	[SerializeField] private string _chickenName;
	[SerializeField] private GameObject _chickenArt;
	[SerializeField] private int _chickenCost = 1;
	[SerializeField] private SfxReference _chickenNoise;

	public string ChickenName => _chickenName;
	public GameObject ChickenArt => _chickenArt;
	public int ChickenCost => _chickenCost;
	public void PlayChickenNoiseSfx(Transform t) => _chickenNoise.PlayAtParentAndFollow(t);
    
	[Header("Eggs")]
	[SerializeField, HighlightIfNull] private Egg _egg;
    [Tooltip("The number of ticks between lay events")]
    [SerializeField] private Vector2 _eggLayTimeMinMax = new Vector2(8, 12);
    [SerializeField] private SfxReference _eggLaySfx;
	[SerializeField] private float _hatchTime = 1;
	[SerializeField] private float _lifeSpan = 10;
	[SerializeField] private int _eggValue = 1;
	
	public Egg EggPrefab => _egg;
	public float EggLayTime => Random.Range(_eggLayTimeMinMax.x, _eggLayTimeMinMax.y);
	public void PlayEggLaySfx(Transform t) => _eggLaySfx.PlayAtParentAndFollow(t);
	public float HatchTime => _hatchTime;
	public float LifeSpan => _lifeSpan;
	public int EggValue => _eggValue;
	
	[Header("Movement")]
	[SerializeField] private float _moveSpeed = 5f;
	[SerializeField] private float _rotateSpeed = 20f;
	[SerializeField] private float _goalReachedRange = 0.5f;
	[SerializeField] private Vector2 _waitTimeMinMax = new Vector2(2f, 4f);
	
	public float MoveSpeed => _moveSpeed;
	public float RotateSpeed => _rotateSpeed;
	public float GoalReachedRange => _goalReachedRange;
	public float WaitTime => Random.Range(_waitTimeMinMax.x, _waitTimeMinMax.y);
}
