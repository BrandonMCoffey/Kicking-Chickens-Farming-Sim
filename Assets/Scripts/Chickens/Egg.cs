using System.Collections;
using Economy;
using Audio;
using UnityEngine;

public class Egg : MonoBehaviour, IInteractable
{
	[SerializeField] private float _lifeSpan = 10;
	[SerializeField, ReadOnly] private float _lifeTime;
	[SerializeField, ReadOnly] private bool _hatched;
	
	[Header("VFX")]
	[SerializeField] private GameObject _eggCollectEffect;

	[Header("SFX")]
	[SerializeField] private AudioClip _eggLaySound;

	public void Hatch(float time)
	{
		StartCoroutine(HatchRoutine(time));
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
		Instantiate(_eggCollectEffect, transform.position, Quaternion.identity);
		AudioManager.PlayClip3D(_eggLaySound, 0.1f);
		Destroy(gameObject);
	}
	
	private void Update()
	{
		if (!_hatched) return;
		_lifeTime += Time.deltaTime;
		if (_lifeTime > _lifeSpan)
		{
			EconomyManager.Instance.AddEggs(1);
			Destroy(gameObject);
		}
	}
}
