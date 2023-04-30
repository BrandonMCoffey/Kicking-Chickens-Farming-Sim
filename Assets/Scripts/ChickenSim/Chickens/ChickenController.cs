using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
	[SerializeField, ReadOnly] private List<Chicken> _spawnedChickens;
	
	private void Awake()
	{
		_spawnedChickens = new List<Chicken>();
		foreach (Transform child in transform)
		{
			var chicken = child.GetComponent<Chicken>();
			if (chicken) _spawnedChickens.Add(chicken);
		}
	}
	
    public void SpawnChicken(SO_ChickenDataBase chickenData)
    {
        var obj = Instantiate(chickenData.ChickenArt, transform);
        var chicken = obj.AddComponent<Chicken>();
        chicken.SetChicken(chickenData);
		
        // TODO: Actual defined positions based on player tap location
        var offset = Random.insideUnitCircle * 2;
        chicken.transform.localPosition += new Vector3(offset.x, 0, offset.y);
		
        _spawnedChickens.Add(chicken);
    }
}
