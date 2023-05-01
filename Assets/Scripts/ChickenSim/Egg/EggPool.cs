using UnityEngine;

public class EggPool : MonoBehaviour
{
	public void SpawnEgg(SO_ChickenDataBase chickenData, Transform parent)
	{
		var egg = Instantiate(chickenData.EggPrefab, parent.position, parent.rotation, transform);
		egg.SetData(chickenData);
		egg.Hatch();
	}
}
