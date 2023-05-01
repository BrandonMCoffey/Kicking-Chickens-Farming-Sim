using UnityEngine;

public class EggPool : MonoBehaviour
{
	public void SpawnEgg(SO_ChickenDataBase chickenData, Transform parent, float random = 0)
	{
		var offset = parent.forward * (Random.value * 2 - 1) + parent.right * (Random.value * 2 - 1);
		var egg = Instantiate(chickenData.EggPrefab, parent.position + offset * random, parent.rotation, transform);
		egg.SetData(chickenData);
		egg.Hatch();
	}
}
