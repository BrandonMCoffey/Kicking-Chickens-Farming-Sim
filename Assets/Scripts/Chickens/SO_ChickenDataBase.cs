using UnityEngine;

[CreateAssetMenu(fileName = "SO_ChickenData", menuName = "FarmScriptableObjects/Chicken", order = 0)]
public class SO_ChickenDataBase : ScriptableObject
{
	public string chickenName;
    
	[Tooltip("The material the chicken will use")]
	public Material chickenMaterial;
    
    
    
	[Header("Eggs")]
	[SerializeField] private Egg _egg;
	[SerializeField] private float _eggHatchTime = 2f;
    [Tooltip("The number of ticks between lay events")]
	[SerializeField] private float _eggLayTime = 10f;
	[Tooltip("The number of eggs per lay event")]
	[SerializeField] private Vector2Int _eggsPerLayMinMax;
	
	public Egg EggPrefab => _egg;
	public float EggHatchTime => _eggHatchTime;
	public float eggLayTime => _eggLayTime;
	public int EggsPerLay => Random.Range(_eggsPerLayMinMax.x, _eggsPerLayMinMax.y);
	
	
	
	[Header("Chicken")]
	[SerializeField] private Vector2 _chickenMatureTimeMinMax = new Vector2(4f, 6f);
	
	public float ChickenMatureTime => Random.Range(_chickenMatureTimeMinMax.x, _chickenMatureTimeMinMax.y);
    
    
    
	[Header("Movement")]
	[SerializeField] private float _moveSpeed = 5f;
	[SerializeField] private float _rotateSpeed = 20f;
	[SerializeField] private float _goalRange = 3f;
	[SerializeField] private float _chickenMoveRange = 1f;
	[SerializeField] private float _goalReachedRange = 0.5f;
	[SerializeField] private Vector2 _waitTimeMinMax = new Vector2(2f, 4f);
	
	public float MoveSpeed => _moveSpeed;
	public float RotateSpeed => _rotateSpeed;
	public float GoalReachedRange => _goalReachedRange;
	public float WaitTime => Random.Range(_waitTimeMinMax.x, _waitTimeMinMax.y);
	public Vector3 RandomGoalOffset(Vector3 goalCenter, Vector3 chickenCenter)
	{
		var offset = Random.insideUnitCircle * _goalRange;
		var goal = goalCenter + new Vector3(offset.x, 0, offset.y);
		
		var dist = Vector3.Distance(goal, chickenCenter);
		if (dist > _chickenMoveRange)
		{
			var delta = (dist - _chickenMoveRange) / dist;
			goal = Vector3.Lerp(goal, chickenCenter, delta + 0.01f);
		}
		
		return goal;
	}
}
