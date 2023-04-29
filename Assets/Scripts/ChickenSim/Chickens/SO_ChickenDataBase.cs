using UnityEngine;

[CreateAssetMenu(fileName = "SO_ChickenData", menuName = "FarmScriptableObjects/Chicken", order = 0)]
public class SO_ChickenDataBase : ScriptableObject
{
	public string chickenName;
    
	[Header("Eggs")]
	[SerializeField] private Egg _egg;
	[SerializeField] private float _eggHatchTime = 2f;
    [Tooltip("The number of ticks between lay events")]
    [SerializeField] private Vector2 _eggLayTimeMinMax = new Vector2(8, 12);
	[Tooltip("The number of eggs per lay event")]
	[SerializeField] private Vector2Int _eggsPerLayMinMax;
	
	public Egg EggPrefab => _egg;
	public float EggHatchTime => _eggHatchTime;
	public float eggLayTime => Random.Range(_eggLayTimeMinMax.x, _eggLayTimeMinMax.y);
	public int EggsPerLay => Random.Range(_eggsPerLayMinMax.x, _eggsPerLayMinMax.y);
	
	
	[Header("Chicken")]
	[SerializeField] private Vector2 _chickenMatureTimeMinMax = new Vector2(4f, 6f);
	
	public float ChickenMatureTime => Random.Range(_chickenMatureTimeMinMax.x, _chickenMatureTimeMinMax.y);
    
    
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
