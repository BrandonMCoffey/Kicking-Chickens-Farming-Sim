using System.Collections;
using Economy;
using Audio;
using UnityEngine;

public class Egg : MonoBehaviour, IInteractable
{
	[SerializeField] private SO_ChickenDataBase _data;
	[SerializeField, ReadOnly] private float _lifeTime;
	[SerializeField, ReadOnly] private bool _hatched;

	[Header("VFX")]
	[SerializeField] private int _particlesOnCollect = 10;

	[Header("SFX")]
	[SerializeField] private SfxReference _eggCollectSound;

	public void Hatch()
	{
		StartCoroutine(HatchRoutine(_data.HatchTime));
	}
	
	private IEnumerator HatchRoutine(float time)
	{
		_hatched = false;
		float mult = 1f / time;
		for (float delta = 0; delta < 1; delta += time * Time.deltaTime)
		{
			transform.localScale = Vector3.one * delta;
			yield return null;
		}
		transform.localScale = Vector3.one;
		_hatched = true;
	}
	
	public void Interact()
	{
		EconomyManager.Instance.AddEggs(1);
		GameManager.EmitEggCollectVfx(transform.position, transform.eulerAngles, _particlesOnCollect);
		_eggCollectSound.PlayAtPosition(transform.position);
		Destroy(gameObject);
	}
	
	private void Update()
	{
		if (!_hatched) return;
		_lifeTime += Time.deltaTime;
		if (_lifeTime > _data.LifeSpan)
		{
			EconomyManager.Instance.AddEggs(_data.EggValue);
			Destroy(gameObject);
		}
	}
}
