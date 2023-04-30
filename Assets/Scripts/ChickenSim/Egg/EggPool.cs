using UnityEngine;

public class EggPool : MonoBehaviour
{
	public void SpawnEgg(Egg eggPrefab, Transform parent)
	{
		var egg = Instantiate(eggPrefab, parent.position, parent.rotation, transform);
		egg.Hatch();
	}
}
